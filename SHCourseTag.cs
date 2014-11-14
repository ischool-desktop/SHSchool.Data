using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 課程標籤類別，提供方法用來取得、新增、修改及刪除課程標籤資訊
    /// </summary>
    public class SHCourseTag : K12.Data.CourseTag
    {
        /// <summary>
        /// 取得所有課程標籤列表。
        /// </summary>
        /// <returns>List&lt;SHCourseTagRecord&gt;，代表多筆課程標籤物件。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHCourseTagRecord&gt; records = SHCourseTag.SelectAll();
        ///         foreach(SHCourseTagRecord record in records)
        ///             System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks></remarks>
        [SelectMethod("SHSchool.SHCourseTag.SelectAll", "學籍.課程類別")]
        public static new List<SHCourseTagRecord> SelectAll()
        {
            return K12.Data.CourseTag.SelectAll<SHCourseTagRecord>();
        }

        public static List<SHCourseTagRecord> Select(IEnumerable<string> CourseIDs, IEnumerable<string> TagCourseIDs)
        {
            return K12.Data.CourseTag.Select<SHCourseTagRecord>(CourseIDs, TagCourseIDs);
        }

        /// <summary>
        /// 根據單筆課程編號取得課程標籤列表。
        /// </summary>
        /// <param name="CourseID">課程編號</param>
        /// <returns>List&lt;SHCourseTagRecord&gt;，代表多筆課程標籤物件。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHCourseTagRecord&gt; records = SHCourseTag.SelectByCourseID(CourseID);
        ///       
        ///       foreach(SHCourseTagRecord record in records)
        ///           System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks></remarks>
        public static new List<SHCourseTagRecord> SelectByCourseID(string CourseID)
        {
            return K12.Data.CourseTag.SelectByCourseID<SHCourseTagRecord>(CourseID);
        }

        /// <summary>
        /// 根據多筆課程編號取得課程標籤列表。
        /// </summary>
        /// <param name="CourseIDs">多筆課程編號</param>
        /// <returns>List&lt;SHCourseTagRecord&gt;，代表多筆課程標籤物件。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHCourseTagRecord&gt; records = SHCourseTag.SelectByCourseIDs(CourseIDs);
        ///         
        ///         forech(SHCourseTagRecord record in records)
        ///             System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks></remarks>

        public static new List<SHCourseTagRecord> SelectByCourseIDs(IEnumerable<string> CourseIDs)
        {
            return K12.Data.CourseTag.SelectByCourseIDs<SHCourseTagRecord>(CourseIDs);
        }

        /// <summary>
        /// 新增單筆課程標籤記錄
        /// </summary>
        /// <param name="CourseTagRecord">課程標籤記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///    <code>
        ///     SHCourseTagRecord  record = new SHCourseTagRecord(CourseID, TagConfigID); 
        ///     string NewID = SHCourseTag.Insert(record);  
        ///    </code>
        /// </example>
        /// <remarks>
        /// 1.新增傳入的參數為課程編號以及標籤編號。
        /// 2.回傳值為新增物件的系統編號。
        /// </remarks> 
        public static string Insert(SHCourseTagRecord CourseTagRecord)
        {
            return K12.Data.CourseTag.Insert(CourseTagRecord);
        }

        /// <summary>
        /// 新增多筆課程標籤記錄
        /// </summary>
        /// <param name="CourseTagRecords">多筆課程記錄物件</param> 
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHCourseTagRecord record = new SHCourseTagRecord(CourseID, TagConfigID); 
        ///     List&lt;SHCourseTagRecord&gt; records = new List&lt;SHCourseTagRecord&gt;();
        ///     records.Add(record);
        ///     List&lt;string&gt; NewIDs = SHCourseTag.Insert(records);  
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增傳入的參數為課程編號以及標籤編號。
        /// 2.回傳值為新增物件的系統編號。
        /// </remarks>        
        public static List<string> Insert(IEnumerable<SHCourseTagRecord> CourseTagRecords)
        {
            return K12.Data.CourseTag.Insert(K12.Data.Utility.Utility.GetBaseList<K12.Data.CourseTagRecord, SHCourseTagRecord>(CourseTagRecords));
        }

        /// <summary>
        /// 更新單筆課程標籤記錄
        /// </summary>
        /// <param name="CourseTagRecord">課程標籤記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHCourseTagRecord&gt; records = SHCourseTag.SelectByCourseID(CourseID);
        ///         records[0].RefEntityID = CourseID;
        ///         records[0].RefTagID = TagConfigID;
        ///         int UpdateCount = SHCourseTag.Update(record[0]);
        ///     </code>
        /// </example>
        public static int Update(SHCourseTagRecord CourseTagRecord)
        {
            return K12.Data.CourseTag.Update(CourseTagRecord);
        }

        /// <summary>
        /// 更新多筆課程標籤記錄
        /// </summary>
        /// <param name="CourseTagRecords">多筆課程標籤記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHCourseTagRecord&gt; records = SHCourseTag.SelectByCourseID(CourseID);
        ///         records[0].RefEntityID = CourseID;
        ///         records[0].RefTagID = TagConfigID;
        ///         int UpdateCount = SHCourseTag.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.更新的欄位值只有CourseID及TagConfigID，其它為唯讀欄位。
        /// 2.傳回值為成功更新的筆數。
        /// </remarks>
        public static int Update(IEnumerable<SHCourseTagRecord> CourseTagRecords)
        {
            return K12.Data.CourseTag.Update(K12.Data.Utility.Utility.GetBaseList<K12.Data.CourseTagRecord, SHCourseTagRecord>(CourseTagRecords));
        }

        /// <summary>
        /// 刪除多筆課程標籤記錄
        /// </summary>
        /// <param name="CourseTagRecords">多筆班級課程記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHCourseTagRecord&gt; records = SHCourseTag.SelectByCourseID(CourseID);
        ///         int DeleteCount = SHCourseTag.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(IEnumerable<SHCourseTagRecord> CourseTagRecords)
        {
            return K12.Data.CourseTag.Delete(K12.Data.Utility.Utility.GetBaseList<K12.Data.CourseTagRecord, SHCourseTagRecord>(CourseTagRecords));
        }

        /// <summary>
        /// 刪除單筆課程標籤記錄
        /// </summary>
        /// <param name="CourseTagRecord">課程標籤記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHCourseTagRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHCourseTagRecord&gt; records = SHCourseTag.SelectByCourseID(CourseID);
        ///         int DeleteCount = SHCourseTag.Delete(records[0]);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHCourseTagRecord CourseTagRecord)
        {
            return K12.Data.CourseTag.Delete(CourseTagRecord);
        }
    }
}