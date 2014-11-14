using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 評分樣板類別，提供方法用來取得、新增、修改及刪除評分樣板資訊
    /// </summary>
    public class SHAEInclude : K12.Data.AEInclude
    {
        /// <summary>
        /// 取得所有評分樣板列表。
        /// </summary>
        /// <returns>List&lt;SHAEIncludeRecord&gt;，代表多筆評分樣板記錄物件。</returns>
        /// <seealso cref="SHAEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHAEIncludeRecord&gt; records = SHAEInclude.SelectAll();
        /// </example>
        [SelectMethod("SHSchool.SHAEInclude.SelectAll", "成績.評分樣板")]
        public static new List<SHAEIncludeRecord> SelectAll()
        {
            return SelectAll<SHAEIncludeRecord>();
        }


        /// <summary>
        /// 根據多筆評分樣板編號取得評分樣板列表。
        /// </summary>
        /// <param name="AEIncludeIDs">多筆評分樣板編號</param>
        /// <returns>List&lt;SHAEIncludeRecord&gt;，代表多筆評分樣板記錄物件。</returns>
        /// <seealso cref="SHAEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHAEIncludeRecord&gt; records = SHAEInclude.SelectByIDs(AEIncludeIDs);
        /// </example>
        public static new List<SHAEIncludeRecord> SelectByIDs(IEnumerable<string> AEIncludeIDs)
        {
            return SelectByIDs<SHAEIncludeRecord>(AEIncludeIDs);
        }

        /// <summary>
        /// 根據單筆評量設定編號取得評分樣板列表。
        /// </summary>
        /// <param name="AssessmentSetupID">單筆評量設定編號</param>
        /// <returns>List&lt;AEIncludeRecord&gt;，代表多筆評分樣板記錄物件。</returns>
        /// <seealso cref="AEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;AEIncludeRecord&gt; aeincluderecords = AEInclude.SelectByIDs(AEIncludeIDs);
        /// </example>
        public static new List<SHAEIncludeRecord> SelectByAssessmentSetupID(string AssessmentSetupID)
        {
            return SelectByAssessmentSetupID<SHAEIncludeRecord>(AssessmentSetupID);
        }

        /// <summary>
        /// 根據多筆單筆評量設定編號取得評分樣板列表。
        /// </summary>
        /// <param name="AssessmentSetupIDs">多筆評量設定編號</param>
        /// <returns>List&lt;AEIncludeRecord&gt;，代表多筆評分樣板記錄物件。</returns>
        /// <seealso cref="AEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;AEIncludeRecord&gt; aeincluderecords = AEInclude.SelectByIDs(AEIncludeIDs);
        /// </example>
        public static new List<SHAEIncludeRecord> SelectByAssessmentSetupIDs(IEnumerable<string> AssessmentSetupIDs)
        {
            return SelectByAssessmentSetupIDs<SHAEIncludeRecord>(AssessmentSetupIDs);
        }

        /// <summary>
        /// 新增單筆評分樣板記錄
        /// </summary>
        /// <param name="AEIncludeRecord">評分樣板記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHAEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        public static string Insert(SHAEIncludeRecord AEIncludeRecord)
        {
            return K12.Data.AEInclude.Insert(AEIncludeRecord);
        }

        /// <summary>
        /// 新增多筆評分樣板記錄
        /// </summary>
        /// <param name="AEIncludeRecords">多筆評分樣板記錄物件</param> 
        /// <returns>List&lt;string&gt，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHAEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static List<string> Insert(IEnumerable<SHAEIncludeRecord> AEIncludeRecords)
        {
            List<K12.Data.AEIncludeRecord> AEIncludes = new List<K12.Data.AEIncludeRecord>();

            foreach (SHAEIncludeRecord AEIncludeRecord in AEIncludes)
                AEIncludes.Add(AEIncludeRecord);

            return K12.Data.AEInclude.Insert(AEIncludes);
        }

        /// <summary>
        /// 更新單筆評分樣板記錄
        /// </summary>
        /// <param name="AEIncludeRecord">評分樣板記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHAEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(SHAEIncludeRecord AEIncludeRecord)
        {
            return K12.Data.AEInclude.Update(AEIncludeRecord);
        }

        /// <summary>
        /// 更新多筆評分樣板記錄
        /// </summary>
        /// <param name="AEIncludeRecords">多筆評分樣板記錄</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHAEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(IEnumerable<SHAEIncludeRecord> AEIncludeRecords)
        {
            List<K12.Data.AEIncludeRecord> AEIncludes = new List<K12.Data.AEIncludeRecord>();

            foreach (SHAEIncludeRecord AEIncludeRecord in AEIncludes)
                AEIncludes.Add(AEIncludeRecord);

            return K12.Data.AEInclude.Update(AEIncludes);
        }

        /// <summary>
        /// 刪除單筆評分樣板記錄
        /// </summary>
        /// <param name="AEIncludeRecord">評分樣板記錄物件</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHAEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHAEIncludeRecord AEIncludeRecord)
        {
            return K12.Data.AEInclude.Delete(AEIncludeRecord);
        }

        /// <summary>
        /// 刪除單筆評分樣板記錄
        /// </summary>
        /// <param name="AEIncludeRecordID">評分樣板記錄編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(string AEIncludeRecordID)
        {
            return K12.Data.AEInclude.Delete(AEIncludeRecordID);
        }

        /// <summary>
        /// 刪除多筆評分樣板記錄
        /// </summary>
        /// <param name="AEIncludeRecords">多筆評分樣板記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHAEIncludeRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHAEIncludeRecord> AEIncludeRecords)
        {
            List<K12.Data.AEIncludeRecord> AEIncludes = new List<K12.Data.AEIncludeRecord>();

            foreach (SHAEIncludeRecord AEIncludeRecord in AEIncludes)
                AEIncludes.Add(AEIncludeRecord);

            return K12.Data.AEInclude.Delete(AEIncludes);
        }

        /// <summary>
        /// 刪除多筆評分樣板記錄
        /// </summary>
        /// <param name="AEIncludeRecordIDs">多筆評分樣板記錄編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(IEnumerable<string> AEIncludeRecordIDs)
        {
            return K12.Data.AEInclude.Delete(AEIncludeRecordIDs);
        }
    }
}
