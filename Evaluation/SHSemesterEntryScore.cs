using System.Collections.Generic;
using System.Xml;
using FISCA.DSAUtil;
using K12.Data;
using K12.Data.Utility;
using System.Linq;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生學期分項成績類別，提供方法用來取得、新增、修改及刪除學生學期分項成績資訊
    /// </summary>
    public class SHSemesterEntryScore
    {
        private const string SELECT_SERVICENAME = "SmartSchool.Score.GetSemesterEntryScore";
        private const string DELETE_SERVICENAME = "SmartSchool.Score.DeleteSemesterEntryScore";

        /// <summary>
        /// 根據條件取得學生學期分項成績物件紀錄列表
        /// </summary>
        /// <param name="IDs">學生學期分項成績編號</param>
        /// <param name="StudentIDs">學生編號列表</param>
        /// <param name="EntryGroup">分項群組</param>
        /// <param name="SchoolYearSemesters">學年度學期紀錄物件列表</param>
        /// <returns>List&lt;SHSemesterEntryScoreRecord&gt;，代表多筆學生學期分項紀錄物件。</returns>
        public static List<SHSemesterEntryScoreRecord> Select(IEnumerable<string> IDs, IEnumerable<string> StudentIDs, string EntryGroup, IEnumerable<SchoolYearSemester> SchoolYearSemesters)
        {
            return Select(IDs,StudentIDs,EntryGroup,SchoolYearSemesters,true);
        }

        /// <summary>
        /// 根據條件取得學生學期分項成績物件紀錄列表
        /// </summary>
        /// <param name="IDs">學生學期分項成績編號</param>
        /// <param name="StudentIDs">學生編號列表</param>
        /// <param name="EntryGroup">分項群組</param>
        /// <param name="SchoolYearSemesters">學年度學期紀錄物件列表</param>
        /// <param name="FilterRepeat">是否過濾重讀</param>
        /// <returns>List&lt;SHSemesterEntryScoreRecord&gt;，代表多筆學生學期分項紀錄物件。</returns>
        public static List<SHSemesterEntryScoreRecord> Select(IEnumerable<string> IDs, IEnumerable<string> StudentIDs, string EntryGroup, IEnumerable<SchoolYearSemester> SchoolYearSemesters,bool FilterRepeat)
        {   
            //取得學生的學期科目成績
            List<SHSemesterEntryScoreRecord> records = Select<SHSemesterEntryScoreRecord>(IDs, StudentIDs, EntryGroup, SchoolYearSemesters);

            if (FilterRepeat)
            {
                //針對每位學生
                foreach (string StudentID in StudentIDs)
                {
                    //取得學生所有學期成績（科目或分項）
                    List<SHSemesterEntryScoreRecord> ScoreList = records
                        .FindAll(x => x.RefStudentID.Equals(StudentID));

                    //將該生所有學期成績按年級、學期、學年度遞增排序
                    ScoreList = ScoreList
                        .OrderBy(x=>x.GradeYear)
                        .ThenBy(x=>x.Semester)
                        .ThenBy(x=>x.SchoolYear)
                        .ToList();

                    #region 以年級學期為鍵值，鍵值為學期成績
                    Dictionary<string,SHSemesterEntryScoreRecord> ApplyGradeSemesterToSchoolYear = new Dictionary<string, SHSemesterEntryScoreRecord>();
                    List<SHSemesterEntryScoreRecord> removeList = new List<SHSemesterEntryScoreRecord>();

                    //針對每筆成績
                    foreach (SHSemesterEntryScoreRecord Score in ScoreList)
                    {
                        //鍵值為年級學期
                        string GradeSemester = Score.GradeYear + "_" + Score.Semester;

                        //若該年級及學期未包含，則加入鍵值及學期成績
                        if (!ApplyGradeSemesterToSchoolYear.ContainsKey(GradeSemester))
                            ApplyGradeSemesterToSchoolYear.Add(GradeSemester,Score);
                        else //否則將目前學期成績加到移除清單中，並將年級學期換成目前學期成績
                        {
                            removeList.Add(ApplyGradeSemesterToSchoolYear[GradeSemester]);
                            ApplyGradeSemesterToSchoolYear[GradeSemester] = Score;
 
                        }
                    }

                    foreach (SHSemesterEntryScoreRecord scoreInfo in removeList)
                        records.Remove(scoreInfo);
                    #endregion

                }
            }

            return records;
        }

        [FISCA.Authentication.AutoRetryOnWebException()]
        protected static List<T> Select<T>(IEnumerable<string> IDs, IEnumerable<string> StudentIDs, string EntryGroup,IEnumerable<SchoolYearSemester> SchoolYearSemesters) where T : SHSemesterEntryScoreRecord, new()
        {
            DSXmlHelper helper = new DSXmlHelper("GetSemesterEntryScore");
            helper.AddElement("Field");
            helper.AddElement("Field", "ID");
            helper.AddElement("Field", "RefStudentId");
            helper.AddElement("Field", "SchoolYear");
            helper.AddElement("Field", "Semester");
            helper.AddElement("Field", "GradeYear");
            helper.AddElement("Field", "EntryGroup");
            helper.AddElement("Field", "ScoreInfo");
            helper.AddElement("Field","ClassRating");
            helper.AddElement("Field","DeptRating");
            helper.AddElement("Field","YearRating");

            helper.AddElement("Condition");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(IDs))
            {
                helper.AddElement("Condition","IDList");

                foreach (string ID in IDs)
                    if (!string.IsNullOrEmpty(ID))
                       helper.AddElement("Condition", "IDList/ID",ID);
            }

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(StudentIDs))
            {
                helper.AddElement("Condition", "StudentIDList");
                foreach (var StudentID in StudentIDs)
                    if (!string.IsNullOrEmpty(StudentID))
                    helper.AddElement("Condition/StudentIDList", "ID", StudentID);
            }

            if (!string.IsNullOrEmpty(EntryGroup))
                helper.AddElement("Condition", "EntryGroup", EntryGroup);

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(SchoolYearSemesters))
            {                
                helper.AddElement("Condition", "Or");

                foreach (SchoolYearSemester each in SchoolYearSemesters)
                {
                    helper.AddElement("Condition/Or","And");
                    helper.AddElement("Condition/Or/And","SchoolYear",""+ each.SchoolYear);
                    helper.AddElement("Condition/Or/And", "Semester", ""+each.Semester);
                }
            }

            DSResponse rsp = DSAServices.CallService(SELECT_SERVICENAME, new DSRequest(helper));

            List<T> Types = new List<T>();

            foreach (XmlElement element in rsp.GetContent().GetElements("SemesterEntryScore"))
            {
                T Type = new T();
                Type.Load(element);
                Types.Add(Type);
            }

            return Types;
        }

        /// <summary>
        /// 刪除單筆學生學期分項成績記錄
        /// </summary>
        /// <param name="SemesterEntryScoreRecord">學生學期分項成績記錄物件</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHSemesterEntryScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHSemesterEntryScoreRecord SemesterEntryScoreRecord)
        {
            return Delete(SemesterEntryScoreRecord.ID);
        }

        /// <summary>
        /// 刪除單筆學生學期分項成績記錄
        /// </summary>
        /// <param name="SemesterEntryScoreID">學生學期分項成績編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(string SemesterEntryScoreID)
        {
            List<string> Keys = new List<string>();

            Keys.Add(SemesterEntryScoreID);

            return Delete(Keys);
        }


        /// <summary>
        /// 刪除多筆學生學期成績記錄
        /// </summary>
        /// <param name="SemesterEntryScoreRecords">多筆學生學期成績記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SemesterEntryScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHSemesterEntryScoreRecord> SemesterEntryScoreRecords)
        {
            List<string> Keys = new List<string>();

            foreach (SHSemesterEntryScoreRecord record in SemesterEntryScoreRecords)
                Keys.Add(record.ID);

            return Delete(Keys);
        }

        /// <summary>
        /// 刪除多筆學生學期分項成績記錄
        /// </summary>
        /// <param name="SemesterEntryScoreIDs">多筆學生學期分項成績編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        static public int Delete(IEnumerable<string> SemesterEntryScoreIDs)
        {
            int result = 0;

            MultiThreadWorker<string> worker = new MultiThreadWorker<string>();
            worker.MaxThreads = 3;
            worker.PackageSize = 100;
            worker.PackageWorker += delegate(object sender, PackageWorkEventArgs<string> e)
            {
                //<DeleteRequest>
                //   <SemesterEntryScore>
                //      <ID>142435</ID>
                //   </SemesterEntryScore>
                //</DeleteRequest>

                DSXmlHelper helper = new DSXmlHelper("DeleteRequest");

                foreach (string Key in e.List)
                {
                    helper.AddElement("SemesterEntryScore");
                    helper.AddElement("SemesterEntryScore", "ID", Key);
                }

                result = int.Parse(DSAServices.CallService(DELETE_SERVICENAME, new DSRequest(helper.BaseElement)).GetContent().GetElement("ExecuteCount").InnerText);
            };

            List<PackageWorkEventArgs<string>> packages = worker.Run(SemesterEntryScoreIDs);

            foreach (PackageWorkEventArgs<string> each in packages)
                if (each.HasException)
                    throw each.Exception;

            //if (AfterDelete != null)
            //    AfterDelete(null, new DataChangedEventArgs(SemesterEntryScoreIDs, ChangedSource.Local));

            return result;
        }
    }
}