using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學期歷程類別，提供方法用來取得及修改學期歷程資訊
    /// </summary>
    public class SHSemesterHistory : K12.Data.SemesterHistory
    {
        /// <summary>
        /// 取得所有學生學期歷程細項列表。
        /// </summary>
        /// <returns></returns>
        [SelectMethod("SHSchool.SHSemesterHistory.SelectAllDetail", "學籍.學期歷程")]
        public new static List<SemesterHistoryItem> SelectAllDetail()
        {
            return K12.Data.SemesterHistory.SelectAllDetail();
        }

        /// <summary>
        /// 取得所有學生學期歷程列表。
        /// </summary>
        /// <returns>List&lt;SHSemesterHistoryRecord&gt;，代表多筆學期歷程物件。</returns>
        /// <seealso cref="SHSemesterHistoryRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHSemesterHistoryRecord&gt; records = SHSemesterHistory.SelectAll();
        ///         
        ///         foreach(SHSemesterHistoryRecord record in records)
        ///             System.Console.Writeln(record.SchoolYear); 
        ///     </code>
        /// </example>
        public new static List<SHSemesterHistoryRecord> SelectAll()
        {
            return SelectAll<SHSemesterHistoryRecord>();
        }

        /// <summary>
        /// 根據學生編號取得學期歷程。
        /// </summary>
        /// <param name="StudentID">學生編號</param>
        /// <returns>SHSemesterHistoryRecord，代表學期歷程物件。</returns>
        /// <seealso cref="SHSemesterHistoryRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHSemesterHistoryRecord record = SHSemesterHistory.SelectByStudentID(StudentID);
        ///     
        ///     if (record != null)
        ///     {
        ///        System.Console.WriteLine(record.SchoolYear);
        ///        System.Console.WriteLine(record.Semester);
        ///     }
        ///     </code>
        /// </example>
        /// <remarks>若是StudentID不存在則會傳回null</remarks>
        public static new SHSemesterHistoryRecord SelectByStudentID(string StudentID)
        {
            return K12.Data.SemesterHistory.SelectByStudentID<SHSemesterHistoryRecord>(StudentID);
        }

        /// <summary>
        /// 根據學生物件取得學期歷程。
        /// </summary>
        /// <param name="Student">學生物件</param>
        /// <returns>SHSemesterHistoryRecord，代表學期歷程物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <seealso cref="SHSemesterHistoryRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <sample>
        ///     <code>
        ///     SHSemesterHistoryRecord record = SHSemesterHistory.SelectByStudent(Student);
        ///     
        ///     if (record != null)
        ///     {
        ///        System.Console.WriteLine(record.SchoolYear);
        ///        System.Console.WriteLine(record.Semester);
        ///     }
        ///     </code>
        ///</sample>
        /// <remarks>若是StudentID不存在則會傳回null</remarks>
        public static SHSemesterHistoryRecord SelectByStudent(SHStudentRecord Student)
        {
            return K12.Data.SemesterHistory.SelectByStudent<SHSemesterHistoryRecord>(Student);
        }

        /// <summary>
        /// 根據多筆學生物件取得學期歷程列表。
        /// </summary>
        /// <param name="Students">多筆學生物件</param>
        /// <returns>List&lt;SHSemesterHistoryRecord&gt;，代表多筆學期歷程物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <seealso cref="SHSemesterHistoryRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHSemesterHistoryRecord&gt; records = SHSemesterHistory.SelectByStudents(Students);
        ///         
        ///         foreach(SHSemesterHistoryRecord record in records)
        ///             System.Console.Writeln(record.SchoolYear); 
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆ID，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static List<SHSemesterHistoryRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students)
        {
            return K12.Data.SemesterHistory.SelectByStudents<SHSemesterHistoryRecord>(K12.Data.Utility.Utility.GetBaseList<K12.Data.StudentRecord, SHStudentRecord>(Students));
        }


        /// <summary>
        /// 根據多筆學生編號取得學期歷程列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHSemesterHistoryRecord&gt;，代表多筆學期歷程物件。</returns>
        /// <seealso cref="SHSemesterHistoryRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHSemesterHistoryRecord&gt; records = SHSemesterHistory.SelectByStudentIDs(StudentIDs);
        ///         
        ///         foreach(SHSemesterHistoryRecord record in records)
        ///             System.Console.Writeln(record.SchoolYear); 
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆ID，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static new List<SHSemesterHistoryRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.SemesterHistory.SelectByStudentIDs<SHSemesterHistoryRecord>(StudentIDs);
        }

        /// <summary>
        /// 更新單筆學期歷程記錄
        /// </summary>
        /// <param name="SemesterHistoryRecord">學期歷程記錄</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHSemesterHistoryRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHSemesterHistoryRecord record = SHSmesterHistory.SelectByStudentID(StudentID);
        ///     record.SchoolYear = 100;
        ///     int UpdateCount = SHSmesterHistory.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHSemesterHistoryRecord SemesterHistoryRecord)
        {
            return K12.Data.SemesterHistory.Update(SemesterHistoryRecord);
        }

        /// <summary>
        /// 更新多筆學期歷程記錄
        /// </summary>
        /// <param name="SemesterHistoryRecords">多筆學期歷程記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHSemesterHistoryRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHSemesterHistoryRecord record = SHSemesterHistory.SelectByStudentID(StudentID);
        ///     record.SchoolYear = 100;
        ///     List&lt;SHSemesterHistoryRecord&gt; records = new List&lt;SHSemesterHistoryRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHSemesterHistory.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHSemesterHistoryRecord> SemesterHistoryRecords)
        {
            return K12.Data.SemesterHistory.Update(K12.Data.Utility.Utility.GetBaseList<K12.Data.SemesterHistoryRecord, SHSemesterHistoryRecord>(SemesterHistoryRecords));
        }
    }
}