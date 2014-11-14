using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生電話類別，提供方法用來取得及修改學生電話資訊
    /// </summary>
    public class SHPhone : K12.Data.Phone
    {
        /// <summary>
        /// 取得所有學生電話記錄物件。
        /// </summary>
        /// <returns>List&lt;SHPhoneRecord&gt;，代表多筆學生電話記錄物件。</returns>
        /// <seealso cref="SHPhoneRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHPhoneRecord&gt; records = SHPhone.SelectAll();
        ///     
        ///     foreach(SHPhoneRecord record in records)
        ///         Console.WrlteLine(record.Permanent);
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHPhone.SelectAll", "學籍.學生電話")]
        public new static List<SHPhoneRecord> SelectAll()
        {
            return SelectAll<SHPhoneRecord>();
        }

        /// <summary>
        /// 根據單筆學生記錄編號取得學生電話記錄物件。
        /// </summary>
        /// <param name="StudentID">學生記錄編號</param>
        /// <returns>SHPhoneRecord，代表學生電話記錄物件。</returns>
        /// <seealso cref="SHPhoneRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHPhoneRecord record = SHPhone.SelectByStudentID(StudentID);
        ///     
        ///    if (record != null)
        ///        System.Console.WriteLine(record.Permanent);
        ///     </code>
        /// </example>
        /// <remarks>若是Student不則在則會傳回null</remarks>
        public static new SHPhoneRecord SelectByStudentID(string StudentID)
        {
            return K12.Data.Phone.SelectByStudentID<SHPhoneRecord>(StudentID);
        }

        /// <summary>
        /// 根據單筆學生記錄物件取得學生電話記錄物件。
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <returns>SHPhoneRecord，代表學生電話記錄物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <seealso cref="SHPhoneRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHPhoneRecord record = SHPhone.SelectByStudent(Student);
        ///     
        ///      if (record != null)
        ///        System.Console.WriteLine(record.Permanent);
        ///     </code>
        /// </example>
        /// <remarks>若是Student不則在則會傳回null</remarks>
        public static SHPhoneRecord SelectByStudent(SHStudentRecord Student)
        {
            return K12.Data.Phone.SelectByStudent<SHPhoneRecord>(Student);
        }

        /// <summary>
        /// 根據多筆學生記錄物件取得學生電話記錄物件列表。
        /// </summary>
        /// <param name="Students">多筆學生記錄物件</param>
        /// <returns>List&lt;SHPhoneRecord&gt;，代表多筆學生電話記錄物件。</returns>
        /// <seealso cref="SHPhoneRecord"/>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHPhoneRecord&gt; records = SHPhone.SelectByStudents(Students);
        ///     
        ///     foreach(SHPhoneRecord record in records)
        ///         Console.WrlteLine(record.Permanent);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆學生，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static List<SHPhoneRecord> SelectByStudents(List<SHStudentRecord> Students)
        {
            return K12.Data.Phone.SelectByStudents<SHPhoneRecord>(K12.Data.Utility.Utility.GetBaseList<StudentRecord,SHStudentRecord>(Students));
        }

        /// <summary>
        /// 根據多筆學生記錄編號取得學生電話記錄物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHPhoneRecord&gt;，代表多筆學生電話記錄物件。</returns>
        /// <seealso cref="SHPhoneRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHPhoneRecord&gt; records = SHPhone.SelectByStudentIDs(StudentIDs);
        ///     
        ///     foreach(SHPhoneRecord record in records)
        ///         Console.WrlteLine(record.Permanent);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆學生，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static new List<SHPhoneRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.Phone.SelectByStudentIDs<SHPhoneRecord>(StudentIDs);
        }

        /// <summary>
        /// 更新單筆學生電話記錄
        /// </summary>
        /// <param name="PhoneRecord">學生電話記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHPhoneRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHPhoneRecord record = SHPhone.SelectByStudentID(StudentID);
        ///     record.Permanent = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHPhone.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHPhoneRecord PhoneRecord)
        {
            return K12.Data.Phone.Update(PhoneRecord);
        }

        /// <summary>
        /// 更新多筆學生電話記錄
        /// </summary>
        /// <param name="PhoneRecords">多筆學生電話記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHPhoneRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHPhoneRecord record = SHPhone.SelectByStudentID(StudentID);
        ///     record.Permanent = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHPhoneRecord&gt; records = new List&lt;SHPhoneRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHPhone.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHPhoneRecord> PhoneRecords)
        {
            return K12.Data.Phone.Update(K12.Data.Utility.Utility.GetBaseList<PhoneRecord,SHPhoneRecord>(PhoneRecords));
        }
    }
}