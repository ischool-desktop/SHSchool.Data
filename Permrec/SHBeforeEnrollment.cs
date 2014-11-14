using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生前級畢業資訊類別，提供方法用來取得及修改學生前級畢業資訊。
    /// </summary>
    public class SHBeforeEnrollment : K12.Data.BeforeEnrollment
    {
        /// <summary>
        /// 取得所有學生前級畢業資訊物件列表。
        /// </summary>
        /// <returns>List&lt;SHBeforeEnrollmentRecord&gt;，代表多筆學生前級畢業資訊物件。</returns>
        /// <seealso cref="SHBeforeEnrollmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHBeforeEnrollmentRecord&gt; records = SHBeforeEnrollment.SelectAll();
        ///     
        ///     foreach(SHBeforeEnrollmentRecord record in records)
        ///         Console.WrlteLine(record.Reason);
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHBeforeEnrollment.SelectAll", "學籍.前級畢業資訊")]
        public new static List<SHBeforeEnrollmentRecord> SelectAll()
        {
            return SelectAll<SHBeforeEnrollmentRecord>();
        }

        /// <summary>
        /// 根據單筆學生記錄物件取得學生前級畢業資訊物件。
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <returns>JHLeaveInfoRecord，代表學生前級畢業資訊物件。</returns>
        /// <seealso cref="JHStudentRecord"/>
        /// <seealso cref="SHBeforeEnrollmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHBeforeEnrollmentRecord record = SHBeforeEnrollment.SelectByStudent(Student);
        ///     
        ///    if (record != null)
        ///        System.Console.WriteLine(record.Memo);
        ///     </code>
        /// </example>
        /// <remarks>若是Student不則在則會傳回null</remarks>
        public static SHBeforeEnrollmentRecord SelectByStudent(SHStudentRecord Student)
        {
            return K12.Data.BeforeEnrollment.SelectByStudent<SHBeforeEnrollmentRecord>(Student);
        }

        /// <summary>
        /// 根據單筆學生記錄編號取得學生前級畢業資訊物件。
        /// </summary>
        /// <param name="StudentID">學生記錄編號</param>
        /// <returns>SHBeforeEnrollmentRecord，代表學生前級畢業資訊物件。</returns>
        /// <seealso cref="SHBeforeEnrollmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHBeforeEnrollmentRecord record = SHBeforeEnrollment.SelectByStudentID(StudentID);
        ///     
        ///     if (record != null)
        ///        System.Console.WriteLine(record.Reason);
        ///     </code>
        /// </example>
        /// <remarks>若是StudentID不則在則會傳回null</remarks>
        public static new SHBeforeEnrollmentRecord SelectByStudentID(string StudentID)
        {
            return K12.Data.BeforeEnrollment.SelectByStudentID<SHBeforeEnrollmentRecord>(StudentID);
        }

        /// <summary>
        /// 根據多筆學生記錄物件取得學生前級畢業資訊物件列表。
        /// </summary>
        /// <param name="Students">多筆學生記錄物件</param>
        /// <returns>List&lt;SHBeforeEnrollmentRecord&gt;，代表多筆學生前級畢業資訊物件。</returns>
        /// <seealso cref="SHBeforeEnrollmentRecord"/>
        /// <seealso cref="JHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHBeforeEnrollmentRecord&gt; records = SHBeforeEnrollment.SelectByStudents(Students);
        ///     
        ///     foreach(SHBeforeEnrollmentRecord record in records)
        ///         Console.WrlteLine(record.Reason);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆學生，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static List<SHBeforeEnrollmentRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students)
        {
            return K12.Data.BeforeEnrollment.SelectByStudents<SHBeforeEnrollmentRecord>(K12.Data.Utility.Utility.GetBaseList<K12.Data.StudentRecord, SHStudentRecord>(Students));
        }

        /// <summary>
        /// 根據多筆學生記錄編號取得學生前級畢業資訊物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHBeforeEnrollmentRecord&gt;，代表多筆學生前級畢業資訊物件。</returns>
        /// <seealso cref="SHBeforeEnrollmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHBeforeEnrollmentRecord&gt; records = SHBeforeEnrollment.SelectByStudentIDs(StudentIDs);
        ///     
        ///     foreach(SHBeforeEnrollmentRecord record in records)
        ///         Console.WrlteLine(record.Reason);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆學生，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static new List<SHBeforeEnrollmentRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.BeforeEnrollment.SelectByStudentIDs<SHBeforeEnrollmentRecord>(StudentIDs);
        }

        /// <summary>
        /// 更新單筆學生離校資訊
        /// </summary>
        /// <param name="BeforeEnrollmentRecord">學生前級畢業資訊物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHBeforeEnrollmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHBeforeEnrollmentRecord record = SHBeforeEnrollment.SelectByStudentID(StudentID);
        ///     record.Reason = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHBeforeEnrollment.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHBeforeEnrollmentRecord BeforeEnrollmentRecord)
        {
            return K12.Data.BeforeEnrollment.Update(BeforeEnrollmentRecord);
        }

        /// <summary>
        /// 更新多筆學生離校資訊
        /// </summary>
        /// <param name="BeforeEnrollmentRecords">多筆學生離校資訊物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHBeforeEnrollmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHBeforeEnrollmentRecord record = SHBeforeEnrollment.SelectByStudentID(StudentID);
        ///     record.Memo = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHBeforeEnrollment&gt; records = new List&lt;SHBeforeEnrollment&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHBeforeEnrollment.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHBeforeEnrollmentRecord> BeforeEnrollmentRecords)
        {
            return K12.Data.BeforeEnrollment.Update(K12.Data.Utility.Utility.GetBaseList<K12.Data.BeforeEnrollmentRecord, SHBeforeEnrollmentRecord>(BeforeEnrollmentRecords));
        }
    }
}