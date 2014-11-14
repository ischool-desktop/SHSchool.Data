using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 標籤設定類別，提供方法用來取得、新增、修改及刪除標籤設定
    /// </summary>
    public class SHTagConfig : K12.Data.TagConfig
    {
        /// <summary>
        /// 取得所有標籤設定列表。
        /// </summary>
        /// <returns>List&lt;SHTagConfigRecord&gt;，代表多筆標籤設定物件。</returns>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHTagConfigRecord&gt; records = SHTagConfig.SelectAll();
        ///     
        ///     foreach(SHTagConfigRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks></remarks>        
        [SelectMethod("SHSchool.SHTagConfig.SelectAll", "學籍.類別設定")]
        public static List<SHTagConfigRecord> SelectAll()
        {
            return K12.Data.TagConfig.SelectAll<SHTagConfigRecord>();
        }

        /// <summary>
        /// 根據單筆標籤設定編號取得標籤設定物件。
        /// </summary>
        /// <param name="TagConfigRecordID">標籤設定編號</param>
        /// <returns>SHTagConfigRecord，代表單筆標籤設定物件。</returns>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHTagConfigRecord record = SHTagConfig.SelectByID(TagConfigID);
        ///     
        ///    if (record != null)
        ///        System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>若是TagConfigID不則在則會傳回null</remarks>
        public static SHTagConfigRecord SelectByID(string TagConfigRecordID)
        {
            return K12.Data.TagConfig.SelectByID<SHTagConfigRecord>(TagConfigRecordID);
        }

        /// <summary>
        /// 根據多筆標籤設定編號取得標籤設定物件。
        /// </summary>
        /// <param name="TagConfigIDs">多筆標籤設定編號</param>
        /// <returns>List&lt;SHTagConfigRecord&gt;，代表多筆標籤設定物件。</returns>
        /// <seealso cref="SHTagConfigRecord"/> 
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHTagConfigRecord&gt; records = SHTagConfig.SelectByIDs(TagConfigIDs);
        ///     
        ///     foreach(SHTagConfigRecord record in records)
        ///         Console.WrlteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆ID，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static List<SHTagConfigRecord> SelectByIDs(IEnumerable<string> TagConfigIDs)
        {
            return K12.Data.TagConfig.SelectByIDs<SHTagConfigRecord>(TagConfigIDs);
        }

        /// <summary>
        /// 根據標籤設定所屬分類( TagCategory )，取得該分類的標籤設定
        /// </summary>
        /// <param name="TagCategory">標籤設定所屬分類，參考 TagCategory 列舉型別。</param>
        /// <returns>List&lt;SHTagConfigRecord&gt;，指定標籤分類中的所有標籤設定</returns>
        /// <seealso cref="TagCategory"/>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHTagConfigRecord&gt; records = SHTagConfig.SelectByCategory(TagCategory.Student);
        ///     
        ///     foreach(SHTagConfigRecord record in records)
        ///         Console.WrlteLine(record.Name);
        ///     </code>
        ///</example>
        ///<remarks>傳入的參數可為TagCategory.Student、TagCategory.Class、TagCategory、Teacher、TagCategory.Course</remarks>
        public static new List<SHTagConfigRecord> SelectByCategory(K12.Data.TagCategory TagCategory)
        {
            return K12.Data.TagConfig.SelectByCategory<SHTagConfigRecord>(TagCategory);
        }

        /// <summary>
        /// 根據標籤設定所屬分類( TagCategory )以及標籤設定類別（Prefix），取得該分類的標籤設定
        /// </summary>
        /// <param name="TagCategory">標籤設定所屬分類，參考 TagCategory 列舉型別。</param>
        /// <param name="Prefix">標籤設定類別（Prefix）</param>
        /// <returns>List&lt;SHTagConfigRecord&gt;，多筆標籤設定</returns>
        /// <seealso cref="TagCategory"/>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;string&gt; records = SHTagConfig.SelectPrefixByCategory(TagCategory.Student);
        ///     
        ///         foreach(string record in records)
        ///             Console.WrlteLine(record);
        ///     </code>
        /// </example>
        public static new List<SHTagConfigRecord> SelectByCategoryAndPrefix(K12.Data.TagCategory TagCategory, string Prefix)
        {
            return K12.Data.TagConfig.SelectByCategoryAndPrefix<SHTagConfigRecord>(TagCategory, Prefix);
        }

        /// <summary>
        /// 新增單筆標籤設定記錄
        /// </summary>
        /// <param name="TagConfigRecord">標籤設定記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHTagConfigRecord newrecord = new SHTagConfigRecord();
        ///         newrecord.Prefix = (new System.Random()).NextDouble().ToString();
        ///         newrecord.Name = (new System.Random()).NextDouble().ToString();
        ///         newrecord.Category = "student";
        ///         strng NewID = SHTagConfig.Insert(newrecord)
        ///         SHTagConfigRecord record = SHTagConfig.SelectByID(NewID);
        ///         System.Console.Writeln(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 新增一律傳回新增物件的編號。
        /// </remarks>
        public static string Insert(SHTagConfigRecord TagConfigRecord)
        {
            return K12.Data.TagConfig.Insert(TagConfigRecord);
        }

        /// <summary>
        /// 新增多筆標籤設定記錄
        /// </summary>
        /// <param name="TagConfigRecords">多筆標籤設定記錄物件</param> 
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHTagConfigRecord record = new SHTagConfigRecord();
        ///         record.Prefix = (new System.Random()).NextDouble().ToString();
        ///         record.Name = (new System.Random()).NextDouble().ToString();
        ///         record.Category = "student";
        ///         List&lt;SHTagConfigRecord&gt; records = new List&lt;SHTagConfigRecord&gt;();
        ///         records.Add(record);
        ///         List&lt;string&gt; NewID = SHTagConfig.Insert(records);
        ///     </code>
        /// </example>
        public static List<string> Insert(IEnumerable<SHTagConfigRecord> TagConfigRecords)
        {
            return K12.Data.TagConfig.Insert(K12.Data.Utility.Utility.GetBaseList<K12.Data.TagConfigRecord, SHTagConfigRecord>(TagConfigRecords));
        }

        /// <summary>
        /// 更新單筆標籤設定記錄
        /// </summary>
        /// <param name="TagConfigRecord">標籤設定記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHTagConfigRecord record = SHTagConfig.SelectByID(TagConfigID);
        ///     record.Name = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHTagConfig.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHTagConfigRecord TagConfigRecord)
        {
            return K12.Data.TagConfig.Update(TagConfigRecord);
        }

        /// <summary>
        /// 更新多筆標籤設定記錄
        /// </summary>
        /// <param name="TagConfigRecords">多筆標籤設定記錄</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHTagConfigRecord record = SHTagConfig.SelectByID(TagConfigID);
        ///     record.Name = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHTagConfigRecord&gt; records = new List&lt;SHTagConfigRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHTagConfig.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHTagConfigRecord> TagConfigRecords)
        {
            return K12.Data.TagConfig.Update(K12.Data.Utility.Utility.GetBaseList<K12.Data.TagConfigRecord, SHTagConfigRecord>(TagConfigRecords));
        }

        /// <summary>
        /// 刪除多筆標籤設定記錄
        /// </summary>
        /// <param name="TagConfigRecords">多筆標籤設定記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHTagConfigRecord&gt; records = SHTagConfig.SelectByIDs(TagConfigIDs);
        ///       int DeleteCount = SHTagConfig.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(IEnumerable<SHTagConfigRecord> TagConfigRecords)
        {
            return K12.Data.TagConfig.Delete(K12.Data.Utility.Utility.GetBaseList<K12.Data.TagConfigRecord, SHTagConfigRecord>(TagConfigRecords));
        }

        /// <summary>
        /// 刪除單筆標籤設定記錄
        /// </summary>
        /// <param name="TagConfigRecord">標籤設定記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHTagConfigRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       SHTagConfigRecord record = SHTagConfig.SelectByID(TagConfigID);
        ///       int DeleteCount = SHTagConfig.Delete(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHTagConfigRecord TagConfigRecord)
        {
            return K12.Data.TagConfig.Delete(TagConfigRecord);
        }

        /// <summary>
        /// 刪除單筆標籤設定記錄
        /// </summary>
        /// <param name="TagConfigID">標籤設定記錄編號</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHTagConfig.Delete(TagConfigID);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(string TagConfigID)
        {
            return K12.Data.TagConfig.Delete(TagConfigID);
        }

        /// <summary>
        /// 刪除多筆標籤設定記錄
        /// </summary>
        /// <param name="List&lt;string&gt;">多筆標籤設定記錄編號</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHTagConfig.Delete(TagConfigIDs);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(IEnumerable<string> TagConfigIDs)
        {
            return K12.Data.TagConfig.Delete(TagConfigIDs);
        }
    }
}