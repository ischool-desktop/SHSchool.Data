using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生異動記錄類別，提供方法用來取得、新增、修改及刪除學生異動記錄
    /// </summary>
    public class SHUpdateRecord:K12.Data.UpdateRecord 
    {
        /// <summary>
        /// 取得所有學生異動記錄列表。
        /// </summary>
        /// <returns>List&lt;SHUpdateRecordRecord&gt;，代表多筆學生異動記錄物件。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHUpdateRecordRecord&gt; records = SHUpdateRecord.SelectAll();
        ///     
        ///     foreach(SHUpdateRecordRecord record in records)
        ///         Console.WrlteLine(record.StudentName);
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHUpdateRecord.SelectAll", "學籍.異動記錄")]
        public static new List<SHUpdateRecordRecord> SelectAll()
        {
            return K12.Data.UpdateRecord.SelectAll<SHUpdateRecordRecord>();
        }

        /// <summary>
        /// 根據單筆學生編號取得學生異動記錄列表。
        /// </summary>
        /// <param name="StudentID">學生記錄編號</param>
        /// <returns>List&lt;SHUpdateRecordRecord&gt;，代表多筆學生異動記錄列表。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHUpdateRecordRecord&gt; record = SHUpdateRecord.SelectByStudentID(StudentID);
        ///     
        ///     if (record != null)
        ///        System.Console.WriteLine(record.StudentName);
        ///     </code>
        /// </example>
        /// <remarks>若是StudentID不則在則會傳回null</remarks>
        public static new List<SHUpdateRecordRecord> SelectByStudentID(string StudentID)
        {
            return K12.Data.UpdateRecord.SelectByStudentID<SHUpdateRecordRecord>(StudentID);
        }

        /// <summary>
        /// 根據單筆學生編號取得學生異動記錄列表。
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <returns>List&lt;SHUpdateRecordRecord&gt;，代表多筆學生異動記錄列表。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHUpdateRecordRecord&gt; record = SHUpdateRecord.SelectByStudent(Student);
        ///     
        ///     if (record != null)
        ///        System.Console.WriteLine(record.StudentName);
        ///     </code>
        /// </example>
        public static List<SHUpdateRecordRecord> SelectByStudent(SHStudentRecord Student)
        {
            return K12.Data.UpdateRecord.SelectByStudent<SHUpdateRecordRecord>(Student);
        }

        /// <summary>
        /// 根據多筆學生編號取得學生異動記錄列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHUpdateRecordRecord&gt;，代表多筆學生異動記錄物件。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHUpdateRecordRecord&gt; records = SHUpdateRecord.SelectByStudentIDs(StudentIDs);
        ///     
        ///     foreach(SHUpdateRecordRecord record in records)
        ///         System.Console.WriteLine(record.StudentName);
        ///     </code>
        /// </example>
        public static new List<SHUpdateRecordRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.UpdateRecord.SelectByStudentIDs<SHUpdateRecordRecord>(StudentIDs);
        }

        /// <summary>
        /// 根據多筆學生物件取得學生異動記錄列表。
        /// </summary>
        /// <param name="Students">多筆學生記錄物件</param>
        /// <returns>List&lt;SHUpdateRecordRecord&gt;，代表多筆學生異動記錄物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHUpdateRecordRecord&gt; records = SHUpdateRecord.SelectByStudents(Students);
        ///     
        ///     foreach(SHUpdateRecordRecord record in records)
        ///         System.Console.WriteLine(record.StudentName);
        ///     </code>
        /// </example>
        public static List<SHUpdateRecordRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students)
        {
            return K12.Data.UpdateRecord.SelectByStudents<SHUpdateRecordRecord>(K12.Data.Utility.Utility.GetBaseList<K12.Data.StudentRecord,SHStudentRecord>(Students));
        }

        /// <summary>
        /// 根據多筆異動記錄編號取得學生異動記錄列表。
        /// </summary>
        /// <param name="IDs">多筆異動記錄編號</param>
        /// <returns>List&lt;SHUpdateRecordRecord&gt;，代表多筆學生異動記錄物件。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHUpdateRecordRecord&gt; records = SHUpdateRecord.SelectByIDs(IDs);
        ///     
        ///     foreach(SHUpdateRecordRecord record in records)
        ///         System.Console.WriteLine(record.StudentName);
        ///     </code>
        /// </example>
        public new static List<SHUpdateRecordRecord> SelectByIDs(IEnumerable<string> IDs)
        {
            return SelectByIDs<SHUpdateRecordRecord>(IDs);
        }

        /// <summary>
        /// 根據異動代碼取得學生異動記錄列表。
        /// </summary>
        /// <param name="UpdateCodes">多個異動代碼</param>
        /// <returns>List&lt;SHUpdateRecordRecord&gt;，代表多筆學生異動記錄物件。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHUpdateRecordRecord&gt; records = SHUpdateRecord.SelectByUpdateCodes(UpdateCodes);
        ///     </code>
        /// </example>
        public static new List<SHUpdateRecordRecord> SelectByUpdateCodes(IEnumerable<string> UpdateCodes)
        {
            return SelectByUpdateCodes<SHUpdateRecordRecord>(UpdateCodes);
        }

        /// <summary>
        /// 新增單筆學生異動記錄
        /// </summary>
        /// <param name="UpdateRecordRecord">學生異動記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHUpdateRecordRecord newrecord = new SHUpdateRecordRecord();
        ///         newrecord.StudentID = StudentID;
        ///         newrecord.UpdateDate = "2009/9/9";
        ///         strng NewID = SHUpdateRecord.Insert(newrecord)
        ///         SHUpdateRecordRecord record = SHUpdateRecord.SelectByID(NewID);
        ///         System.Console.Writeln(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增一律傳回新增物件的編號。
        /// 2.新增必填欄位為學生編號及異動日期。
        /// </remarks>
        public static string Insert(SHUpdateRecordRecord UpdateRecordRecord)
        {
            return K12.Data.UpdateRecord.Insert(UpdateRecordRecord);
        }

        /// <summary>
        /// 新增多筆學生異動記錄
        /// </summary>
        /// <param name="UpdateRecordRecords">多筆學生異動記錄物件</param> 
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHUpdateRecordRecord record = new SHUpdateRecordRecord();
        ///         record.StudentID = StudentID;
        ///         record.UpdateDate = "2009/9/9";
        ///         List&lt;SHUpdateRecordRecord&gt; records = new List&lt;SHUpdateRecordRecord&gt;();
        ///         records.Add(record);
        ///         List&lt;string&gt; NewID = SHUpdateRecord.Insert(records)
        ///     </code>
        /// </example>
        public static List<string> Insert(IEnumerable<SHUpdateRecordRecord> UpdateRecordRecords)
        {
            return K12.Data.UpdateRecord.Insert(K12.Data.Utility.Utility.GetBaseList<K12.Data.UpdateRecordRecord, SHUpdateRecordRecord>(UpdateRecordRecords));  
        }

        /// <summary>
        /// 更新單筆學生異動記錄
        /// </summary>
        /// <param name="UpdateRecordRecord">學生異動記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHUpdateRecordRecord record = SHUpdateRecord.SelectByID(ClassID);
        ///     record.StudentName = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHUpdateRecord.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHUpdateRecordRecord UpdateRecordRecord)
        {
            return K12.Data.UpdateRecord.Update(UpdateRecordRecord);
        }

        /// <summary>
        /// 更新多筆學生異動記錄
        /// </summary>
        /// <param name="UpdateRecordRecords">多筆學生異動記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHUpdateRecordRecord record = SHUpdateRecord.SelectByID(UpdateRecordID);
        ///     record.StudentName = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHUpdateRecordRecord&gt; records = new List&lt;SHUpdateRecordRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHUpdateRecord.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHUpdateRecordRecord> UpdateRecordRecords)
        {
            return K12.Data.UpdateRecord.Update(K12.Data.Utility.Utility.GetBaseList<K12.Data.UpdateRecordRecord, SHUpdateRecordRecord>(UpdateRecordRecords));  
        }

        /// <summary>
        /// 刪除多筆學生異動記錄
        /// </summary>
        /// <param name="UpdateRecordRecords">多筆學生異動記錄編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///    <code>
        ///    int DeleteCount = SHUpdateRecord.Delete(UpdateRecordRecords);
        ///    </code>
        /// </example>
        static public int Delete(IEnumerable<SHUpdateRecordRecord> UpdateRecordRecords)
        {
            return K12.Data.UpdateRecord.Delete(K12.Data.Utility.Utility.GetBaseList<K12.Data.UpdateRecordRecord, SHUpdateRecordRecord>(UpdateRecordRecords));  
        }

        /// <summary>
        /// 刪除多筆學生異動記錄
        /// </summary>
        /// <param name="UpdateRecordIDs">多筆學生異動記錄編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///    <code>
        ///    int DeleteCount = SHUpdateRecord.Delete(UpdateRecordIDs);
        ///    </code>
        /// </example>
        static public new int Delete(IEnumerable<string> UpdateRecordIDs)
        {
            return K12.Data.UpdateRecord.Delete(UpdateRecordIDs); 
        }

        /// <summary>
        /// 刪除單筆學生異動記錄
        /// </summary>
        /// <param name="UpdateRecordRecord">單筆學生異動記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHUpdateRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       SHUpdateRecordRecord&gt; record = SHUpdateRecord.SelectByID(UpdateRecordID);
        ///       int DeleteCount = SHUpdateRecord.Delete(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHUpdateRecordRecord UpdateRecordRecord)
        {
            return K12.Data.UpdateRecord.Delete(UpdateRecordRecord);
        }

        /// <summary>
        /// 刪除單筆學生異動記錄
        /// </summary>
        /// <param name="UpdateRecordID">單筆學生異動記錄編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHUpdateRecord.Delete(UpdateRecordID);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(string UpdateRecordID)
        {
            return K12.Data.UpdateRecord.Delete(UpdateRecordID);
        }
    }
}