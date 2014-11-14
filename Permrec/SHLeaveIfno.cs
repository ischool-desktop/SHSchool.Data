using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生離校資訊類別，提供方法用來取得及修改學生地址資訊
    /// </summary>
    public class SHLeaveInfo : K12.Data.LeaveInfo
    {
        /// <summary>
        /// 取得所有學生離校資訊物件列表。
        /// </summary>
        /// <returns>List&lt;SHLeaveInfoRecord&gt;，代表多筆學生離校資訊物件。</returns>
        /// <seealso cref="SHLeaveInfoRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHLeaveInfoRecord&gt; records = SHLeaveInfo.SelectAll();
        ///     
        ///     foreach(SHLeaveInfoRecord record in records)
        ///         Console.WrlteLine(record.Reason);
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHLeaveInfo.SelectAll", "學籍.離校資訊")]
        public new static List<SHLeaveInfoRecord> SelectAll()
        {
            return SelectAll<SHLeaveInfoRecord>();
        }

        /// <summary>
        /// 根據單筆學生記錄物件取得學生離校資訊物件。
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <returns>SHLeaveInfoRecord，代表學生離校資訊物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <seealso cref="SHLeaveInfoRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHLeaveInfoRecord record = SHLeaveInfo.SelectByStudent(Student);
        ///     
        ///    if (record != null)
        ///        System.Console.WriteLine(record.Reason);
        ///     </code>
        /// </example>
        /// <remarks>若是Student不則在則會傳回null</remarks>
        public static SHLeaveInfoRecord SelectByStudent(SHStudentRecord Student)
        {
            return K12.Data.LeaveInfo.SelectByStudent<SHLeaveInfoRecord>(Student);
        }

        /// <summary>
        /// 根據單筆學生記錄編號取得學生離校資訊物件。
        /// </summary>
        /// <param name="StudentID">學生記錄編號</param>
        /// <returns>SHLeaveInfoRecord，代表學生離校資訊物件。</returns>
        /// <seealso cref="SHLeaveInfoRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHLeaveInfoRecord record = SHLeaveInfo.SelectByStudentID(StudentID);
        ///     
        ///     if (record != null)
        ///        System.Console.WriteLine(record.Reason);
        ///     </code>
        /// </example>
        /// <remarks>若是StudentID不則在則會傳回null</remarks>
        public static new SHLeaveInfoRecord SelectByStudentID(string StudentID)
        {
            return K12.Data.LeaveInfo.SelectByStudentID<SHLeaveInfoRecord>(StudentID);
        }

        /// <summary>
        /// 根據多筆學生記錄物件取得學生離校資訊物件列表。
        /// </summary>
        /// <param name="Students">多筆學生記錄物件</param>
        /// <returns>List&lt;SHLeaveInfoRecord&gt;，代表多筆學生離校資訊物件。</returns>
        /// <seealso cref="SHLeaveInfoRecord"/>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHLeaveInfoRecord&gt; records = SHLeaveInfo.SelectByStudents(Students);
        ///     
        ///     foreach(SHLeaveInfoRecord record in records)
        ///         Console.WrlteLine(record.Reason);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆學生，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static List<SHLeaveInfoRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students)
        {
            return K12.Data.LeaveInfo.SelectByStudents<SHLeaveInfoRecord>(K12.Data.Utility.Utility.GetBaseList<StudentRecord,SHStudentRecord>(Students));
        }

        /// <summary>
        /// 根據多筆學生記錄編號取得學生離校資訊物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHLeaveInfoRecord&gt;，代表多筆學生離校資訊物件。</returns>
        /// <seealso cref="SHLeaveInfoRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHLeaveInfoRecord&gt; records = SHLeaveInfo.SelectByStudentIDs(StudentIDs);
        ///     
        ///     foreach(SHLeaveInfoRecord record in records)
        ///         Console.WrlteLine(record.Reason);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆學生，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static new List<SHLeaveInfoRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.LeaveInfo.SelectByStudentIDs<SHLeaveInfoRecord>(StudentIDs);
        }

        /// <summary>
        /// 更新單筆學生離校資訊
        /// </summary>
        /// <param name="LeaveInfoRecord">學生離校資訊物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHLeaveInfoRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHLeaveInfoRecord record = SHLeaveInfo.SelectByStudentID(StudentID);
        ///     record.Reason = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHLeaveInfo.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHLeaveInfoRecord LeaveInfoRecord)
        {
            return K12.Data.LeaveInfo.Update(LeaveInfoRecord);
        }

        /// <summary>
        /// 更新多筆學生離校資訊
        /// </summary>
        /// <param name="LeaveInfoRecords">多筆學生離校資訊物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHLeaveInfoRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHLeaveInfoRecord record = SHLeaveInfo.SelectByStudentID(StudentID);
        ///     record.Reason = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHLeaveInfoRecord&gt; records = new List&lt;SHLeaveInfoRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHLeaveInfo.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHLeaveInfoRecord> LeaveInfoRecords)
        {
            return K12.Data.LeaveInfo.Update(K12.Data.Utility.Utility.GetBaseList<LeaveInfoRecord,SHLeaveInfoRecord>(LeaveInfoRecords));
        }
    }
}