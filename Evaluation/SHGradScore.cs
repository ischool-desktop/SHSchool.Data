using System;
using System.Collections.Generic;
using System.Xml;
using FISCA.DSAUtil;
using K12.Data;
using K12.Data.Utility;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生畢業成績類別，提供方法用來取得及修改學生畢業成績資訊
    /// </summary>
    public class SHGradScore
    {
        private const string SELECT_SERVICENAME = "SmartSchool.Student.GetDetailList";
        private const string UPDATE_SERVICENAME = "SmartSchool.Student.Update";

        /// <summary>
        /// 取得所有學生畢業成績項目列表。
        /// </summary>
        /// <returns>List&lt;SHGradScoreRecord&gt;，代表多筆學生畢業成績記錄物件。</returns>
        /// <seealso cref="SHGradScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHGradScoreRecord&gt; records = SHGradeScore.SelectAll();
        ///     </code>
        /// </example>
        public static List<SHGradScoreRecord> SelectAll()
        {
            return SelectAll<SHGradScoreRecord>();
        }

        /// <summary>
        /// 取得所有學生畢業成績項目列表。
        /// </summary>
        /// <returns>List&lt;SHGradScoreRecord&gt;，代表多筆學生畢業成績記錄物件。</returns>
        /// <seealso cref="SHGradScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHGradScoreRecord&gt; records = SHGradeScore.SelectAll();
        ///     </code>
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        public static List<T> SelectAll<T>() where T : SHGradScoreRecord, new()
        {
            List<T> Types = new List<T>();

            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Field");
            helper.AddElement("Field", "ID");
            helper.AddElement("Field", "GradScore");

            DSResponse rsp = DSAServices.CallService(SELECT_SERVICENAME, new DSRequest(helper));

            foreach (XmlElement each in rsp.GetContent().GetElements("Student"))
            {
                T Type = new T();
                Type.Load(each);
                Types.Add(Type);
            }

            return Types;
        }

        /// <summary>
        /// 根據單筆學生記錄編號取得學生畢業成績記錄物件。
        /// </summary>
        /// <param name="StudentID">單筆學生記錄編號</param>
        /// <returns>SHGradScoreRecord，代表單筆學生畢業成績記錄物件。</returns>
        /// <seealso cref="SHGradScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHGradScoreRecord record = SHGradeScore.SelectByID(StudentID);
        ///     </code>
        /// </example>
        public static SHGradScoreRecord SelectByID(string StudentID)
        {
            return SelectByID<SHGradScoreRecord>(StudentID);
        }

        /// <summary>
        /// 根據單筆學生記錄編號取得學生畢業成績記錄物件。
        /// </summary>
        /// <param name="StudentID">單筆學生記錄編號</param>
        /// <returns>SHGradScoreRecord，代表單筆學生畢業成績記錄物件。</returns>
        /// <seealso cref="SHGradScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHGradScoreRecord record = SHGradeScore.SelectByID(StudentID);
        ///     </code>
        /// </example>
        public static T SelectByID<T>(string StudentID) where T : SHGradScoreRecord, new()
        {
            List<string> IDs = new List<string>();

            IDs.Add(StudentID);

            List<T> GradScoreRecords = SelectByIDs<T>(IDs);

            if (GradScoreRecords.Count > 0)
                return GradScoreRecords[0];
            else
                return null;
        }

        /// <summary>
        /// 根據多筆學生記錄編號取得學生畢業成績記錄。
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHGradScoreRecord&gt;，代表多筆學生畢業成績記錄物件。</returns>
        /// <seealso cref="SHGradScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHGradScoreRecord&gt; records = SHGradeScore.SelectByIDs(StudentIDs);
        ///     </code>
        /// </example>
        public static List<SHGradScoreRecord> SelectByIDs(IEnumerable<string> StudentIDs)
        {
            return SelectByIDs<SHGradScoreRecord>(StudentIDs);
        }

        /// <summary>
        /// 根據多筆學生記錄編號取得學生畢業成績記錄。
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHGradScoreRecord&gt;，代表多筆學生畢業成績記錄物件。</returns>
        /// <seealso cref="SHGradScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHGradScoreRecord&gt; records = SHGradeScore.SelectByIDs(StudentIDs);
        ///     </code>
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        public static List<T> SelectByIDs<T>(IEnumerable<string> StudentIDs) where T : SHGradScoreRecord, new()
        {
            DSXmlHelper helper = new DSXmlHelper("Request");
            helper.AddElement("Field");
            helper.AddElement("Field", "ID");
            helper.AddElement("Field", "GradScore");
            helper.AddElement("Condition");
            foreach (var each in StudentIDs)
                if (!string.IsNullOrEmpty(each))
                    helper.AddElement("Condition", "ID", each);

            DSResponse rsp = DSAServices.CallService(SELECT_SERVICENAME, new DSRequest(helper));

            List<T> Types = new List<T>();

            foreach (XmlElement each in rsp.GetContent().GetElements("Student"))
            {
                T Type = new T();
                Type.Load(each);
                Types.Add(Type);
            }

            return Types;
        }

        /// <summary>
        /// 更新單筆學生畢業成績記錄
        /// </summary>
        /// <param name="GradScoreRecord">學生畢業成績記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="GradScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     
        ///     </code>
        /// </example>
        public static int Update(SHGradScoreRecord GradScoreRecord)
        {
            List<SHGradScoreRecord> Params = new List<SHGradScoreRecord>();

            Params.Add(GradScoreRecord);

            return Update(Params);
        }

        /// <summary>
        /// 更新多筆學生畢業成績記錄
        /// </summary>
        /// <param name="GradScoreRecords">多筆學生畢業成績記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="GradScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     
        ///     </code>
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        public static int Update(IEnumerable<SHGradScoreRecord> GradScoreRecords)
        {
            int result = 0;

            List<string> IDs = new List<string>();

            MultiThreadWorker<SHGradScoreRecord> worker = new MultiThreadWorker<SHGradScoreRecord>();
            worker.MaxThreads = 3;
            worker.PackageSize = 100;
            worker.PackageWorker += delegate(object sender, PackageWorkEventArgs<SHGradScoreRecord> e)
            {
                DSXmlHelper updateHelper = new DSXmlHelper("UpdateStudentList");

                foreach (var editor in e.List)
                {
                    DSXmlHelper partialUpdateHelper = new DSXmlHelper("Student");
                    partialUpdateHelper.AddElement("Field");
                    partialUpdateHelper.AddElement("Field", "GradScore");
                    partialUpdateHelper.AddElement("Field/GradScore", "GradScore");

                    foreach (var entry in editor.Entries.Values)
                    {
                        XmlElement entryElement = partialUpdateHelper.AddElement("Field/GradScore/GradScore", "EntryScore");
                        entryElement.SetAttribute("Entry", entry.Entry);
                        entryElement.SetAttribute("Score", "" + entry.Score);
                    }

                    //<GradScore>
                    //    <EntryScore Entry="學業" Score="71.0" />
                    //    <EntryScore Entry="德行" Score="83.8" />
                    //</GradScore>

                    partialUpdateHelper.AddElement("Condition");
                    partialUpdateHelper.AddElement("Condition", "ID", editor.RefStudentID);

                    updateHelper.AddElement(".", partialUpdateHelper.BaseElement);

                    IDs.Add(editor.RefStudentID);
                }

                result = int.Parse(DSAServices.CallService(UPDATE_SERVICENAME, new DSRequest(updateHelper.BaseElement)).GetContent().GetElement("ExecuteCount").InnerText);

            };

            List<PackageWorkEventArgs<SHGradScoreRecord>> packages = worker.Run(GradScoreRecords);

            foreach (PackageWorkEventArgs<SHGradScoreRecord> each in packages)
                if (each.HasException)
                    throw each.Exception;

            if (AfterUpdate != null)
                AfterUpdate(null, new DataChangedEventArgs(IDs, ChangedSource.Local));

            return result;
        }

        static public event EventHandler<DataChangedEventArgs> AfterUpdate;
    }
}