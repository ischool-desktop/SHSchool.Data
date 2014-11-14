using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 教師標籤類別，提供方法用來取得、新增、修改及刪除班級標籤資訊
    /// </summary>
    public class SHTeacherTag : K12.Data.TeacherTag
    {
        /// <summary>
        /// 取得所有教師標籤列表。
        /// </summary>
        /// <returns>List&lt;SHTeacherTagRecord&gt;，代表多筆教師標籤物件。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHTeacherTagRecord&gt; records = SHTeacherTag.SelectAll();
        ///        
        ///         foreach(SHTeacherTagRecord record in records)
        ///             System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHTeacherTag.SelectAll", "學籍.教師類別")]
        public new static List<SHTeacherTagRecord> SelectAll()
        {
            return K12.Data.TeacherTag.SelectAll<SHTeacherTagRecord>();
        }

        /// <summary>
        /// 根據單筆教師編號取得教師標籤列表。
        /// </summary>
        /// <param name="TeacherID">教師編號</param>
        /// <returns>List&lt;SHTeacherTagRecord&gt;，代表多筆教師標籤物件。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <sample>
        ///     <code>
        ///         List&lt;SHTeacherTagRecord&gt; records = SHTeacherTag.SelectByTeacherID(TeacherID);
        ///        
        ///         foreach(SHTeacherTagRecord record in records)
        ///           System.Console.WriteLine(record.Name);
        ///     </code>
        /// </sample>
        public new static List<SHTeacherTagRecord> SelectByTeacherID(string TeacherID)
        {
            return K12.Data.TeacherTag.SelectByTeacherID<SHTeacherTagRecord>(TeacherID);
        }

        /// <summary>
        /// 根據多筆教師編號取得教師標籤列表。
        /// </summary>
        /// <param name="TeacherIDs">多筆教師編號</param>
        /// <returns>List&lt;SHTeacherTagRecord&gt;，代表多筆教師標籤物件。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHTeacherTagRecord&gt; records = SHTeacherTag.SelectByTeacherIDs(TeacherIDs);
        ///    
        ///     forech(SHTeacherTagRecord record in records)
        ///         System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        public static List<SHTeacherTagRecord> SelectByTeacherIDs(IEnumerable<string> TeacherIDs)
        {
            return K12.Data.TeacherTag.SelectByTeacherIDs<SHTeacherTagRecord>(TeacherIDs);
        }

        /// <summary>
        /// 新增單筆教師標籤記錄
        /// </summary>
        /// <param name="TeacherTagRecord">教師標籤記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHTeacherTagRecord  record = new SHTeacherTagRecord(TeacherID, TagConfigID);
        ///     string NewID = SHTeacherTag.Insert(record); 
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增傳入的參數為教師編號以及標籤編號。
        /// 2.回傳值為新增物件的系統編號。
        /// </remarks>
        public static string Insert(SHTeacherTagRecord TeacherTagRecord)
        {
            return K12.Data.TeacherTag.Insert(TeacherTagRecord);
        }

        /// <summary>
        /// 新增多筆教師標籤記錄
        /// </summary>
        /// <param name="TeacherTagRecords">多筆教師標籤記錄物件</param> 
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHTeacherTagRecord record = new SHTeacherTagRecord(TeacherID, TagConfigID);
        ///     List&lt;SHTeacherTagRecord&gt; records = new List&lt;SHTeacherTagRecord&gt;();
        ///     records.Add(record);
        ///     List&lt;string&gt; NewIDs = SHTeacherTag.Insert(records); 
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增傳入的參數為教師編號以及標籤編號。
        /// 2.回傳值為新增物件的系統編號。
        /// </remarks>
        public static List<string> Insert(IEnumerable<SHTeacherTagRecord> TeacherTagRecords)
        {
            return K12.Data.TeacherTag.Insert(K12.Data.Utility.Utility.GetBaseList<K12.Data.TeacherTagRecord, SHTeacherTagRecord>(TeacherTagRecords));
        }

        /// <summary>
        /// 更新單筆教師標籤記錄
        /// </summary>
        /// <param name="TeacherTagRecord">教師標籤記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHTeacherTagRecord&gt; records = SHTeacherTag.SelectByTeacherID(TeacherID);       
        ///         records[0].RefEntityID = TeacherID;
        ///         records[0].RefTagID = TagConfigID;
        ///         int UpdateCount = SHTeacherTag.Update(record[0]);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.更新的欄位值只有TeacherID及TagConfigID，其它為唯讀欄位。
        /// 2.傳回值為成功更新的筆數。
        /// </remarks>       
        public static int Update(SHTeacherTagRecord TeacherTagRecord)
        {
            return K12.Data.TeacherTag.Update(TeacherTagRecord);
        }

        /// <summary>
        /// 更新多筆教師標籤記錄
        /// </summary>
        /// <param name="TeacherTagRecords">多筆教師標籤記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHTeacherTagRecord&gt; records = SHTeacherTag.SelectByTeacherID(TeacherID);       
        ///         records[0].RefEntityID = TeacherID;
        ///         records[0].RefTagID = TagConfigID;
        ///         int UpdateCount = SHTeacherTag.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.更新的欄位值只有TeacherID及TagConfigID，其它為唯讀欄位。
        /// 2.傳回值為成功更新的筆數。
        /// </remarks>
        public static int Update(IEnumerable<SHTeacherTagRecord> TeacherTagRecords)
        {
            return K12.Data.TeacherTag.Update(K12.Data.Utility.Utility.GetBaseList<K12.Data.TeacherTagRecord, SHTeacherTagRecord>(TeacherTagRecords));
        }

        /// <summary>
        /// 刪除多筆教師標籤記錄
        /// </summary>
        /// <param name="TeacherTagRecords">多筆教師標籤記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHTeacherTagRecord&gt; records = SHTeacherTag.SelectByTeacherID(TeacherID);
        ///         int DeleteCount = SHTeacherTag.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 傳回值為成功刪除的筆數。
        /// </remarks>
        static public int Delete(IEnumerable<SHTeacherTagRecord> TeacherTagRecords)
        {
            return K12.Data.TeacherTag.Delete(K12.Data.Utility.Utility.GetBaseList<K12.Data.TeacherTagRecord, SHTeacherTagRecord>(TeacherTagRecords));
        }

        /// <summary>
        /// 刪除單筆教師標籤記錄
        /// </summary>
        /// <param name="TeacherTagRecord">教師標籤記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHTeacherTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHTeacherTagRecord&gt; records = SHTeacherTag.SelectByTeacherID(TeacherID);
        ///         int DeleteCount = SHTeacherTag.Delete(records[0]);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHTeacherTagRecord TeacherTagRecord)
        {
            return K12.Data.TeacherTag.Delete(TeacherTagRecord);
        }
    }
}