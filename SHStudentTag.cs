using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生標籤類別，提供方法用來取得、新增、修改及刪除學生標籤資訊
    /// </summary>
    public class SHStudentTag : K12.Data.StudentTag
    {
        /// <summary>
        /// 取得所有學生標籤列表。
        /// </summary>
        /// <returns>List&lt;SHStudentTagRecord&gt;，代表多筆學生標籤物件。</returns>
        /// <seealso cref="SHStudentTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHStudentTagRecord&gt; records = SHStudentTag.SelectAll();
        ///         
        ///         foreach(SHStudentTagRecord record in records)
        ///             System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHStudentTag.SelectAll", "學籍.學生類別")]
        public static new List<SHStudentTagRecord> SelectAll()
        {
            return K12.Data.StudentTag.SelectAll<SHStudentTagRecord>();
        }

        /// <summary>
        /// 根據單筆學生編號取得學生標籤列表。
        /// </summary>
        /// <param name="StudentID">學生編號</param>
        /// <returns>List&lt;SHStudentTagRecord&gt;，代表多筆學生標籤物件。</returns>
        /// <seealso cref="SHStudentTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHStudentTagRecord&gt; records = SHStudentTag.SelectByStudentID(StudentID);
        ///         
        ///         foreach(SHStudentTagRecord record in records)
        ///           System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        public static new List<SHStudentTagRecord> SelectByStudentID(string StudentID)
        {
            return K12.Data.StudentTag.SelectByStudentID<SHStudentTagRecord>(StudentID);
        }

        /// <summary>
        /// 根據多筆學生編號取得學生標籤列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHStudentTagRecord&gt;，代表多筆學生標籤物件。</returns>
        /// <seealso cref="SHStudentTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHStudentTagRecord&gt; records = SHStudentTag.SelectByStudentIDs(StudentIDs);
        ///     
        ///     forech(SHStudentTagRecord record in records)
        ///         System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        public static new List<SHStudentTagRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.StudentTag.SelectByStudentIDs<SHStudentTagRecord>(StudentIDs);
        }

        /// <summary>
        /// 新增單學生標籤記錄
        /// </summary>
        /// <param name="StudentTagRecord">學生標籤記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHStudentTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHStudentTagRecord  record = new SHStudentTagRecord(StudentID, TagConfigID); 
        ///     string NewID = SHStudentTag.Insert(record);  
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增傳入的參數為學生編號以及標籤編號。
        /// 2.回傳值為新增物件的系統編號。
        /// </remarks> 
        public static string Insert(SHStudentTagRecord StudentTagRecord)
        {
            return K12.Data.StudentTag.Insert(StudentTagRecord);
        }

        /// <summary>
        /// 新增多筆學生標籤記錄
        /// </summary>
        /// <param name="StudentTagRecords">多筆學生標籤記錄物件</param> 
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHStudentTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHStudentTagRecord record = new SHStudentTagRecord(StudentID, TagConfigID); 
        ///     List&lt;SHStudentTagRecord&gt; records = new List&lt;SHStudentTagRecord&gt;();
        ///     records.Add(record);
        ///     List&lt;string&gt; NewIDs = SHStudentTag.Insert(records);  
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增傳入的參數為學生編號以及標籤編號。
        /// 2.回傳值為新增物件的系統編號。
        /// </remarks>
        public static List<string> Insert(IEnumerable<SHStudentTagRecord> StudentTagRecords)
        {
            return K12.Data.StudentTag.Insert(K12.Data.Utility.Utility.GetBaseList<K12.Data.StudentTagRecord, SHStudentTagRecord>(StudentTagRecords));
        }

        /// <summary>
        /// 更新單筆學生標籤記錄
        /// </summary>
        /// <param name="StudentTagRecord">學生標籤記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHStudentTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHStudentTagRecord&gt; records = SHStudentTag.SelectByStudentID(StudentID);        
        ///         records[0].RefEntityID = StudentID;
        ///         records[0].RefTagID = TagConfigID;
        ///         int UpdateCount = SHStudentTag.Update(record[0]);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.更新的欄位值只有StudentID及TagConfigID，其它為唯讀欄位。
        /// 2.傳回值為成功更新的筆數。
        /// </remarks>
        public static int Update(SHStudentTagRecord StudentTagRecord)
        {
            return K12.Data.StudentTag.Update(StudentTagRecord);
        }

        /// <summary>
        /// 更新多筆學生標籤記錄
        /// </summary>
        /// <param name="StudentTagRecords">多筆學生標籤記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHStudentTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHStudentTagRecord&gt; records = SHStudentTag.SelectByStudentID(StudentID);        
        ///         records[0].RefEntityID = StudentID;
        ///         records[0].RefTagID = TagConfigID;
        ///         int UpdateCount = SHStudentTag.Update(records);
        ///     </code>
        /// </example>
        public static int Update(IEnumerable<SHStudentTagRecord> StudentTagRecords)
        {
            return K12.Data.StudentTag.Update(K12.Data.Utility.Utility.GetBaseList<K12.Data.StudentTagRecord, SHStudentTagRecord>(StudentTagRecords));
        }

        /// <summary>
        /// 刪除多筆學生標籤記錄
        /// </summary>
        /// <param name="StudentTagRecords">多筆標籤記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHStudentTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHStudentTagRecord&gt; records = SHStudentTag.SelectByStudentID(StudentID);
        ///         int DeleteCount = StudentTag.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 傳回值為成功刪除的筆數。
        /// </remarks>        
        static public int Delete(IEnumerable<SHStudentTagRecord> StudentTagRecords)
        {
            return K12.Data.StudentTag.Delete(K12.Data.Utility.Utility.GetBaseList<K12.Data.StudentTagRecord, SHStudentTagRecord>(StudentTagRecords));
        }

        /// <summary>
        /// 刪除單筆學生記錄
        /// </summary>
        /// <param name="StudentTagRecord">學生記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="JHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHStudentTagRecord&gt; records = SHStudentTag.SelectByStudentID(StudentID);
        ///         int DeleteCount = SHStudentTag.Delete(records[0]);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHStudentTagRecord StudentTagRecord)
        {
            return K12.Data.StudentTag.Delete(StudentTagRecord);
        }
    }
}