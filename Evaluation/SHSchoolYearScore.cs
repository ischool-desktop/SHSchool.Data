using System;
using System.Collections.Generic;
using System.Xml;
using FISCA.DSAUtil;
using K12.Data;
using K12.Data.Utility;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生學年成績類別，提供方法用來取得、新增、修改及刪除學生學期成績資訊
    /// </summary>
    public class SHSchoolYearScore
    {
        private const string SELECT_SERVICENAME = "SmartSchool.Score.GetSchoolYearSubjectScore";
        private const string UPDATE_SERVICENAME = "SmartSchool.Score.UpdateSchoolYearSubjectScore";
        private const string DELETE_SERVICENAME = "SmartSchool.Score.DeleteSchoolYearSubjectScore";

        /// <summary>
        /// 根據多筆學生編號取得學生學年科目成績列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHSchoolYearScoreRecord&gt;，代表多筆學生學年科目成績記錄物件。</returns>
        /// <seealso cref="SHSchoolYearScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///    <code>
        ///     List&lt;SHSchoolYearScoreRecord&gt; records = SHSchoolYearScoreRecord.SelectByStudentIDs(StudentIDs);
        ///    </code>
        /// </example>
        public static List<SHSchoolYearScoreRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return SelectByStudentIDs<SHSchoolYearScoreRecord>(StudentIDs);
        }

        /// <summary>
        /// 根據多筆學生編號取得學生學年科目成績列表。
        /// </summary>
        /// <typeparam name="T">學生學年科目成績記錄物件型別</typeparam>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHSchoolYearScoreRecord&gt;，代表多筆學生學年科目成績記錄物件。</returns>
        /// <seealso cref="SHSchoolYearScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHSchoolYearScoreRecord&gt; records = SHSchoolYearScore.SelectByStudentIDs&lt;SHSchoolYearScoreRecord&gt;(StudentIDs);
        ///     </code>
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        protected static List<T> SelectByStudentIDs<T>(IEnumerable<string> StudentIDs) where T : SHSchoolYearScoreRecord, new()
        {
            DSXmlHelper helper = new DSXmlHelper("GetSchoolYearSubjectScore");
            helper.AddElement("Field");
            helper.AddElement("Field", "ID");
            helper.AddElement("Field", "RefStudentId");
            helper.AddElement("Field", "SchoolYear");
            helper.AddElement("Field", "Semester");
            helper.AddElement("Field", "GradeYear");
            helper.AddElement("Field", "ScoreInfo");
            helper.AddElement("Condition");
            helper.AddElement("Condition", "StudentIDList");
            foreach (var each in StudentIDs)
                helper.AddElement("Condition/StudentIDList", "ID", each);

            DSResponse rsp = DSAServices.CallService(SELECT_SERVICENAME, new DSRequest(helper));

            List<T> Types = new List<T>();


            foreach (XmlElement element in rsp.GetContent().GetElements("SchoolYearSubjectScore"))
            {
                T Type = new T();
                Type.Load(element);
                Types.Add(Type);
            }

            return Types;
        }

        /// <summary>
        /// 更新單筆學生學年科目成績記錄
        /// </summary>
        /// <param name="SchoolYearScoreRecord">學生學年科目成績記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SchoolYearScoreRecord"/>
        /// <example>
        ///     
        /// </example>
        public static int Update(SHSchoolYearScoreRecord SchoolYearScoreRecord)
        {
            List<SHSchoolYearScoreRecord> Params = new List<SHSchoolYearScoreRecord>();

            Params.Add(SchoolYearScoreRecord);

            return Update(Params);
        }

        /// <summary>
        /// 更新多筆學生學年科目成績記錄
        /// </summary>
        /// <param name="SchoolYearScoreRecords">多筆學生學期科目成績記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// </exception>
        /// <example>
        ///     
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        public static int Update(IEnumerable<SHSchoolYearScoreRecord> SchoolYearScoreRecords)
        {
            int result = 0;
            List<string> IDs = new List<string>();

            MultiThreadWorker<SHSchoolYearScoreRecord> worker = new MultiThreadWorker<SHSchoolYearScoreRecord>();
            worker.MaxThreads = 3;
            worker.PackageSize = 100;
            worker.PackageWorker += delegate(object sender, PackageWorkEventArgs<SHSchoolYearScoreRecord> e)
            {
                DSXmlHelper helper = new DSXmlHelper("UpdateRequest");

                foreach (var editor in e.List)
                {
                    DSXmlHelper updatehelper = new DSXmlHelper("SchoolYearSubjectScore");

                    IDs.Add(editor.ID);

                    updatehelper.AddElement("Field");
                    updatehelper.AddElement("Field", "RefStudentId", editor.RefStudentID);
                    updatehelper.AddElement("Field", "SchoolYear", "" + editor.SchoolYear);
                    updatehelper.AddElement("Field", "GradeYear", "" + editor.GradeYear);
                    updatehelper.AddElement("Field", "ScoreInfo");
                    updatehelper.AddElement("Field/ScoreInfo", "SchoolYearSubjectScore");                    

                    foreach (var Subject in editor.Subjects)
                        updatehelper.AddElement("Field/ScoreInfo/SchoolYearSubjectScore", Subject.ToXml());

                    updatehelper.AddElement("Condition");
                    updatehelper.AddElement("Condition", "ID", editor.ID);

                    helper.AddElement(".", updatehelper.BaseElement);
                }

                result = int.Parse(DSAServices.CallService(UPDATE_SERVICENAME, new DSRequest(helper.BaseElement)).GetContent().GetElement("ExecuteCount").InnerText);
            };

            List<PackageWorkEventArgs<SHSchoolYearScoreRecord>> packages = worker.Run(SchoolYearScoreRecords);

            foreach (PackageWorkEventArgs<SHSchoolYearScoreRecord> each in packages)
                if (each.HasException)
                    throw each.Exception;

            //if (AfterUpdate != null)
            //    AfterUpdate(null, new DataChangedEventArgs(IDs, ChangedSource.Local));

            return result;
        }

        /// <summary>
        /// 刪除單筆學生學年科目成績記錄
        /// </summary>
        /// <param name="SchoolYearScoreRecord">學生學年科目成績記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SchoolYearScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHSchoolYearScoreRecord SchoolYearScoreRecord)
        {
            return Delete(SchoolYearScoreRecord.ID);
        }

        /// <summary>
        /// 刪除單筆學生學年科目成績記錄
        /// </summary>
        /// <param name="SchoolYearScoreID">學生學年科目成績編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(string SchoolYearScoreID)
        {
            List<string> Keys = new List<string>();

            Keys.Add(SchoolYearScoreID);

            return Delete(Keys);
        }

        /// <summary>
        /// 刪除多筆學生學年科目成績記錄
        /// </summary>
        /// <param name="SchoolYearSubjectScoreRecords">多筆學生學年科目成績記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SchoolYearSubjectScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHSchoolYearScoreRecord> SchoolYearSubjectScoreRecords)
        {
            List<string> Keys = new List<string>();

            foreach (SHSchoolYearScoreRecord record in SchoolYearSubjectScoreRecords)
                Keys.Add(record.ID);

            return Delete(Keys);
        }

        /// <summary>
        /// 刪除多筆學生學年科目成績記錄
        /// </summary>
        /// <param name="SchoolYearSubjectIDs">多筆學生學年科目成績編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        static public int Delete(IEnumerable<string> SchoolYearSubjectIDs)
        {
            int result = 0;

            MultiThreadWorker<string> worker = new MultiThreadWorker<string>();
            worker.MaxThreads = 3;
            worker.PackageSize = 100;
            worker.PackageWorker += delegate(object sender, PackageWorkEventArgs<string> e)
            {
                DSXmlHelper helper = new DSXmlHelper("DeleteRequest");

                foreach (string Key in e.List)
                {
                    helper.AddElement("SchoolYearSubjectScore");
                    helper.AddElement("SchoolYearSubjectScore", "ID", Key);
                }

                result = int.Parse(DSAServices.CallService(DELETE_SERVICENAME, new DSRequest(helper.BaseElement)).GetContent().GetElement("ExecuteCount").InnerText);

            };

            List<PackageWorkEventArgs<string>> packages = worker.Run(SchoolYearSubjectIDs);

            foreach (PackageWorkEventArgs<string> each in packages)
                if (each.HasException)
                    throw each.Exception;

            //if (AfterDelete != null)
            //    AfterDelete(null, new DataChangedEventArgs(SchoolYearSubjectIDs, ChangedSource.Local));

            return result;
        }
    }
}