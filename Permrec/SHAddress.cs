using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生地址類別，提供方法用來取得及修改學生地址資訊
    /// </summary>
    public class SHAddress : K12.Data.Address
    {
        /// <summary>
        /// 取得所有學生地址記錄物件列表。
        /// </summary>
        /// <returns>List&lt;SHAddressRecord&gt;，代表多筆學生地址記錄物件。</returns>
        /// <seealso cref="SHAddressRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHAddressRecord&gt; records = SHAddress.SelectAll();
        ///     
        ///     foreach(SHAddressRecord record in records)
        ///         System.Console.WriteLine(record.Name); 
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHAddress.SelectAll", "學籍.學生地址")]
        public new static List<SHAddressRecord> SelectAll()
        {
            return SelectAll<SHAddressRecord>();
        }

        /// <summary>
        /// 根據單筆學生記錄物件取得學生地址記錄物件。
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <returns>SHAddressRecord，代表學生地址物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <seealso cref="SHAddressRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHAddressRecord record = SHAddress.SelectByStudent(Student);
        ///         
        ///         if (record!=null)
        ///             System.Console.WriteLine(record.Permanent.ZipCode); 
        ///     </code>
        /// </example>
        /// <remarks>若是Student不存在則會傳回null</remarks>
        public static SHAddressRecord SelectByStudent(SHStudentRecord Student)
        {
            return K12.Data.Address.SelectByStudent<SHAddressRecord>(Student);
        }

        /// <summary>
        /// 根據單筆學生記錄編號取得學生地址記錄物件。
        /// </summary>
        /// <param name="StudentID">學生記錄編號</param>
        /// <returns>SHAddressRecord，代表學生地址記錄物件。</returns>
        /// <seealso cref="SHAddressRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHAddressRecord record = SHAddress.SelectByStudentID(StudentID);
        ///         
        ///         if (record!=null)
        ///         System.Console.WriteLine(record.Permanent.ZipCode); 
        ///     </code>
        /// </example>
        /// <remarks>若是StudentID不存在則會傳回null</remarks>
        public static new SHAddressRecord SelectByStudentID(string StudentID)
        {
            return K12.Data.Address.SelectByStudentID<SHAddressRecord>(StudentID);
        }

        /// <summary>
        /// 根據多筆學生記錄物件取得地址記錄物件列表。
        /// </summary>
        /// <param name="Students">多筆學生記錄物件</param>
        /// <returns>List&lt;SHAddressRecord&gt;，代表多筆學生地址記錄物件。</returns>
        /// <seealso cref="SHAddressRecord"/>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHAddressRecord&gt; records = SHAddress.SelectByStudents(Students);
        ///     
        ///     foreach(SHAddressRecord record in records)
        ///         System.Console.WriteLine(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆ID，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static List<SHAddressRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students)
        {
            return K12.Data.Address.SelectByStudents<SHAddressRecord>(K12.Data.Utility.Utility.GetBaseList<StudentRecord,SHStudentRecord>(Students));
        }

        /// <summary>
        /// 根據多筆學生記錄編號取得地址記錄物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHAddressRecord&gt;，代表多筆學生地址記錄物件。</returns>
        /// <seealso cref="SHAddressRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHAddressRecord&gt; records = SHAddress.SelectByStudentIDs(StudentIDs);
        ///     
        ///     foreach(SHAddressRecord record in records)
        ///         System.Console.WriteLine(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆ID，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static new List<SHAddressRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.Address.SelectByStudentIDs<SHAddressRecord>(StudentIDs);
        }

        /// <summary>
        /// 更新單筆學生地址記錄
        /// </summary>
        /// <param name="AddressRecord">學生地址記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHAddressRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHAddressRecord record = SHAddress.SelectByStudentID(StudentID);
        ///     record.PerPermanent.ZipCode = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHAddress.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHAddressRecord AddressRecord)
        {
            return K12.Data.Address.Update(AddressRecord);
        }

        /// <summary>
        /// 更新多筆學生地址記錄
        /// </summary>
        /// <param name="AddressRecords">多筆學生地址記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHAddressRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHAddressRecord record = SHAddress.SelectByStudentID(StudentID);
        ///     record.PerPermanent.ZipCode = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHAddressRecord&gt; records = new List&lt;SHAddressRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHAddress.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHAddressRecord> AddressRecords)
        {
            return K12.Data.Address.Update(K12.Data.Utility.Utility.GetBaseList<AddressRecord,SHAddressRecord>(AddressRecords));
        }
    }
}