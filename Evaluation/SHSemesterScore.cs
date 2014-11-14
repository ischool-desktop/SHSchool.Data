using System.Collections.Generic;
using System.Linq;
using FISCA.DSAUtil;
using K12.Data;
using K12.Data.Utility;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生學期成績類別，提供方法用來取得、新增、修改及刪除學生學期成績資訊
    /// </summary>
    public class SHSemesterScore : K12.Data.SemesterScore
    {
        private const string UPDATE_SERVICENAME = "SmartSchool.Score.UpdateSemesterSubjectScore";

        /// <summary>
        /// 取得所有科目成績
        /// </summary>
        /// <returns></returns>
        [SelectMethod("SHSchool.SHSemesterScore.SelectAllSubjectScore", "成績.科目成績")]
        public static new List<SHSubjectScore> SelectAllSubjectScore()
        {
            List<SHSubjectScore> Subjects = new List<SHSubjectScore>();

            foreach (SHSemesterScoreRecord Record in SelectAll())
                foreach (SHSubjectScore Subject in Record.Subjects.Values)
                    Subjects.Add(Subject);
            return Subjects;
        }

        /// <summary>
        /// 取得所有學生學期成績記錄物件。
        /// </summary>
        /// <returns>List&lt;SHSemesterScoreRecord&gt;</returns>
        public static new List<SHSemesterScoreRecord> SelectAll()
        {
            return K12.Data.SemesterScore.SelectAll<SHSemesterScoreRecord>();
        }

        /// <summary>
        /// 根據學生系統編號取得學期科目成績（預設過濾重讀）
        /// </summary>
        /// <param name="StudentID">學生系統編號</param>
        /// <returns>學期科目成績列表</returns>
        public static new List<SHSemesterScoreRecord> SelectByStudentID(string StudentID)
        {
            if (string.IsNullOrEmpty(StudentID))
                return new List<SHSemesterScoreRecord>();

            List<SHSemesterScoreRecord> Records = new List<SHSemesterScoreRecord>();

            Records = SelectByStudentIDs(new List<string>() { StudentID }, true);

            return Records;
        }

        /// <summary>
        /// 根據學生系統編號取得學期科目成績（預設過濾重讀）
        /// </summary>
        /// <param name="StudentID">學生系統編號</param>
        /// <param name="FilterRepeat">是否過濾重讀</param>
        /// <returns>學期科目成績列表</returns>
        public static List<SHSemesterScoreRecord> SelectByStudentID(string StudentID,bool FilterRepeat = true)
        {
            if (string.IsNullOrEmpty(StudentID))
                return new List<SHSemesterScoreRecord>();

            List<SHSemesterScoreRecord> Records = new List<SHSemesterScoreRecord>();

            Records = SelectByStudentIDs(new List<string>() { StudentID }, FilterRepeat);

            return Records;
        }

        /// <summary>
        /// 根據學生記錄物件取得學期科目成績（預設過濾重讀）
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <returns>學期科目成績列表</returns>
        public static List<SHSemesterScoreRecord> SelectByStudent(SHStudentRecord Student)
        {
            if (Student == null)
                return new List<SHSemesterScoreRecord>();

            return SelectByStudentID(Student.ID,true);
        }

        /// <summary>
        /// 根據學生記錄物件取得學期科目成績（預設過濾重讀）
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <returns>學期科目成績列表</returns>
        public static new List<SHSemesterScoreRecord> SelectByStudent(StudentRecord Student)
        {
            if (Student == null)
                return new List<SHSemesterScoreRecord>();

            return SelectByStudentID(Student.ID, true);
        }

        /// <summary>
        /// 根據學生記錄物件取得學期科目成績（預設過濾重讀）
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <param name="FilterRepeat">是否過濾重讀</param>
        /// <returns>學期科目成績列表</returns>
        public static List<SHSemesterScoreRecord> SelectByStudent(SHStudentRecord Student,bool FilterRepeat = true)
        {
            if (Student == null)
                return new List<SHSemesterScoreRecord>();

            return SelectByStudentID(Student.ID, FilterRepeat);
        }

        /// <summary>
        /// 根據學生記錄列表取得學期科目成績（預設過濾重讀）
        /// </summary>
        /// <param name="Students">學生記錄列表</param>
        /// <returns>學期科目成績列表</returns>
        public static new List<SHSemesterScoreRecord> SelectByStudents(IEnumerable<StudentRecord> Students)
        {
            List<SHSemesterScoreRecord> Records = new List<SHSemesterScoreRecord>();

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(Students))
                Records = SelectByStudentIDs(Students.Select(x => x.ID), true);

            return Records;
        }

        /// <summary>
        /// 根據學生記錄列表取得學期科目成績（預設過濾重讀）
        /// </summary>
        /// <param name="Students">學生記錄列表</param>
        /// <returns>學期科目成績列表</returns>
        public static List<SHSemesterScoreRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students)
        {
            return SelectByStudents(Students, true);
        }

        /// <summary>
        /// 根據學生記錄列表取得學期科目成績（預設過濾重讀）
        /// </summary>
        /// <param name="Students">學生記錄列表</param>
        /// <param name="FilterRepeat">是否過濾重讀</param>
        /// <returns>學期科目成績列表</returns>
        public static List<SHSemesterScoreRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students,bool FilterRepeat = true)
        {
            List<SHSemesterScoreRecord> Records = new List<SHSemesterScoreRecord>();

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(Students))
                Records = SelectByStudentIDs(Students.Select(x => x.ID), FilterRepeat);

            return Records;
        }

        /// <summary>
        /// 根據多筆學生編號取得學生學期成績列表（預設過濾重讀）。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHSemesterScoreRecord&gt;，代表多筆學生學期成績記錄物件。</returns>
        /// <seealso cref="SHSemesterScoreRecord"/>
        /// <example>
        ///     <code>
        ///         List&lt;SHSemesterScoreRecord&gt; records = SHSemesterScore.SelectByStudentIDs(StudentIDs);
        ///     </code>
        /// </example>
        public static new List<SHSemesterScoreRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return SelectByStudentIDs(StudentIDs, true);
        }

        /// <summary>
        /// 根據多筆學生編號取得學生學期成績列表（預設過濾重讀）。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        ///  <param name="FilterRepeat">是否過濾重讀</param>
        /// <returns>List&lt;SHSemesterScoreRecord&gt;，代表多筆學生學期成績記錄物件。</returns>
        /// <seealso cref="SHSemesterScoreRecord"/>
        /// <example>
        ///     <code>
        ///         List&lt;SHSemesterScoreRecord&gt; records = SHSemesterScore.SelectByStudentIDs(StudentIDs);
        ///     </code>
        /// </example>
        public static List<SHSemesterScoreRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs,bool FilterRepeat=true)
        {
            //取得學生的學期科目成績
            List<SHSemesterScoreRecord> records = K12.Data.SemesterScore.SelectByStudentIDs<SHSemesterScoreRecord>(StudentIDs);

            if (FilterRepeat)
            {
                //針對每位學生
                foreach (string StudentID in StudentIDs)
                {
                    //取得學生所有學期成績（科目或分項）
                    List<SHSemesterScoreRecord> ScoreList = records
                        .FindAll(x => x.RefStudentID.Equals(StudentID));

                    //將該生所有學期成績按年級、學期、學年度遞增排序
                    ScoreList = ScoreList
                        .OrderBy(x => x.GradeYear)
                        .ThenBy(x => x.Semester)
                        .ThenBy(x => x.SchoolYear)
                        .ToList();

                    #region 以年級學期為鍵值，鍵值為學期成績
                    Dictionary<string, SHSemesterScoreRecord> ApplyGradeSemesterToSchoolYear = new Dictionary<string, SHSemesterScoreRecord>();
                    List<SHSemesterScoreRecord> removeList = new List<SHSemesterScoreRecord>();

                    //針對每筆成績
                    foreach (SHSemesterScoreRecord Score in ScoreList)
                    {
                        //鍵值為年級學期
                        string GradeSemester = Score.GradeYear + "_" + Score.Semester;

                        //若該年級及學期未包含，則加入鍵值及學期成績
                        if (!ApplyGradeSemesterToSchoolYear.ContainsKey(GradeSemester))
                            ApplyGradeSemesterToSchoolYear.Add(GradeSemester, Score);
                        else //否則將目前學期成績加到移除清單中，並將年級學期換成目前學期成績
                        {
                            removeList.Add(ApplyGradeSemesterToSchoolYear[GradeSemester]);
                            ApplyGradeSemesterToSchoolYear[GradeSemester] = Score;

                        }
                    }

                    foreach (SHSemesterScoreRecord scoreInfo in removeList)
                        records.Remove(scoreInfo);
                    #endregion
                }
            }

            return records;

            #region 舊程式碼
            //重讀學生均以重讀後的成績為統計來源。
            //9801 有一年級的成績
            //9802 有一年級的成績
            //9901 有一年級的成績
            //9902 有一年級的成績 
            //應以9901、9902即重讀後，一年級的成績。

            //if (filterRepeat)            
            //    foreach (Customization.Data.StudentRecord student in studentList)
            //    {
            //        if (scoreDictionary.ContainsKey(student.StudentID))
            //        {
            //            List<Customization.Data.StudentExtension.SchoolYearEntryScoreInfo> scoreList = scoreDictionary[student.StudentID];
            //
            //            Dictionary<int, int> ApplySchoolYear = new Dictionary<int, int>();
            //            //先將此學生此時的學年度學期資料加入
            //            int gradeYear = 0;
            //            if (student.RefClass != null && int.TryParse(student.RefClass.GradeYear, out gradeYear))
            //            {
            //                ApplySchoolYear.Add(gradeYear,CurrentUser.Instance.SchoolYear);
            //            }
            //            else
            //                gradeYear = int.MaxValue;
            //
            //            //先掃一遍抓出每個年級最高的學年度
            //            foreach (SchoolYearEntryScore scoreInfo in scoreList)
            //            {
            //                //成績年級比現在大的不理會
            //                if (scoreInfo.GradeYear <= gradeYear)
            //                {
            //                    if (!ApplySchoolYear.ContainsKey(scoreInfo.GradeYear))

            //                        ApplySchoolYear.Add(scoreInfo.GradeYear, scoreInfo.SchoolYear);
            //                    if (scoreInfo.SchoolYear > ApplySchoolYear[scoreInfo.GradeYear])

            //                        ApplySchoolYear[scoreInfo.GradeYear] = scoreInfo.SchoolYear;
            //                }
            //            }
            //            //如果成績資料的年級學年度不在清單中就移掉

            //            List<Customization.Data.StudentExtension.SchoolYearEntryScoreInfo> removeList = new List<Customization.Data.StudentExtension.SchoolYearEntryScoreInfo>();
            //            foreach(Customization.Data.StudentExtension.SchoolYearEntryScoreInfo scoreInfo in scoreList)
            //            {
            //                //成績年級比現在大或成績的學年度部是最新的
            //                if (!ApplySchoolYear.ContainsKey(scoreInfo.GradeYear) || ApplySchoolYear[scoreInfo.GradeYear] != scoreInfo.SchoolYear)
            //                    removeList.Add(scoreInfo);
            //            }
            //            foreach (SchoolYearEntryScore scoreInfo in removeList)
            //            {
            //                scoreList.Remove(scoreInfo);
            //            }
            //        }
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// 更新單筆學生學期成績記錄
        /// </summary>
        /// <param name="SemesterScoreRecord">學生學期成績記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SemesterScoreRecord"/>
        /// <example>
        ///     
        /// </example>
        public static int Update(SHSemesterScoreRecord SemesterScoreRecord)
        {
            List<SHSemesterScoreRecord> Params = new List<SHSemesterScoreRecord>();

            Params.Add(SemesterScoreRecord);

            return Update(Params);
        }

        /// <summary>
        /// 更新多筆學生學期成績記錄
        /// </summary>
        /// <param name="SemesterScoreRecords">多筆學生學期成績記錄</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// </exception>
        /// <example>
        ///     
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        public static int Update(IEnumerable<SHSemesterScoreRecord> SemesterScoreRecords)
        {
            int result = 0;
            List<string> IDs = new List<string>();

            MultiThreadWorker<SHSemesterScoreRecord> worker = new MultiThreadWorker<SHSemesterScoreRecord>();
            worker.MaxThreads = 3;
            worker.PackageSize = 100;
            worker.PackageWorker += delegate(object sender, PackageWorkEventArgs<SHSemesterScoreRecord> e)
            {
                DSXmlHelper helper = new DSXmlHelper("UpdateRequest");

                foreach (var editor in e.List)
                {
                    DSXmlHelper updatehelper = new DSXmlHelper("SemesterSubjectScore");

                    IDs.Add(editor.ID);

                    updatehelper.AddElement("Field");
                    updatehelper.AddElement("Field", "RefStudentId", editor.RefStudentID);
                    updatehelper.AddElement("Field", "SchoolYear", "" + editor.SchoolYear);
                    updatehelper.AddElement("Field", "Semester", "" + editor.Semester);
                    updatehelper.AddElement("Field", "GradeYear", "" + editor.GradeYear);
                    updatehelper.AddElement("Field", "ScoreInfo");
                    updatehelper.AddElement("Field/ScoreInfo", "SemesterSubjectScoreInfo");

                    foreach (var Subject in editor.Subjects.Values)
                        updatehelper.AddElement("Field/ScoreInfo/SemesterSubjectScoreInfo", Subject.ToXML());

                    updatehelper.AddElement("Condition");
                    updatehelper.AddElement("Condition", "ID", editor.ID);

                    helper.AddElement(".", updatehelper.BaseElement);
                }

                result = int.Parse(DSAServices.CallService(UPDATE_SERVICENAME, new DSRequest(helper.BaseElement)).GetContent().GetElement("ExecuteCount").InnerText);

            };

            List<PackageWorkEventArgs<SHSemesterScoreRecord>> packages = worker.Run(SemesterScoreRecords);

            foreach (PackageWorkEventArgs<SHSemesterScoreRecord> each in packages)
                if (each.HasException)
                    throw each.Exception;

            //if (AfterUpdate != null)
            //    AfterUpdate(null, new DataChangedEventArgs(IDs, ChangedSource.Local));

            return result;
        }

        /// <summary>
        /// 刪除單筆學生學期成績記錄
        /// </summary>
        /// <param name="SemesterScoreRecord">學生學期成績記錄物件</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHSemesterScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHSemesterScoreRecord SemesterScoreRecord)
        {
            return K12.Data.SemesterScore.Delete(SemesterScoreRecord);
        }

        /// <summary>
        /// 刪除單筆學生學期成績記錄
        /// </summary>
        /// <param name="SemesterScoreID">學生學期成績編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(string SemesterScoreID)
        {
            return K12.Data.SemesterScore.Delete(SemesterScoreID);
        }


        /// <summary>
        /// 刪除多筆學生學期成績記錄
        /// </summary>
        /// <param name="SemesterScoreRecords">多筆學生學期成績記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHSemesterScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHSemesterScoreRecord> SemesterScoreRecords)
        {
            return K12.Data.SemesterScore.Delete(K12.Data.Utility.Utility.GetBaseList<K12.Data.SemesterScoreRecord, SHSemesterScoreRecord>(SemesterScoreRecords));
        }

        /// <summary>
        /// 刪除多筆學生學期成績記錄
        /// </summary>
        /// <param name="SemesterScoreIDs">多筆學生學期成績編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(IEnumerable<string> SemesterScoreIDs)
        {
            return K12.Data.SemesterScore.Delete(SemesterScoreIDs);
        }
    }
}