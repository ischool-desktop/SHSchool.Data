using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生缺曠類別，提供方法用來取得、新增、修改及刪除學生缺曠資訊
    /// </summary>
    public class SHAttendance : K12.Data.Attendance
    {
        [SelectMethod("SHSchool.SHAttendance.SelectAllAttendancePeriod", "學務.缺曠")]
        public static List<AttendancePeriod> SelectAllAttendancePeriod()
        {
            List<SHAttendanceRecord> Attendances = SelectAll();

            List<AttendancePeriod> Periods = new List<AttendancePeriod>();

            for (int i = 0; i < Attendances.Count; i++)
                Periods.AddRange(Attendances[i].PeriodDetail);

            return Periods;
        }

        /// <summary>
        /// 取得所有缺曠紀錄
        /// </summary>
        /// <returns>List&lt;SHAttendanceRecord&gt;，一個SHAttendanceRecord物件代表一個學生在某一天的缺曠紀錄。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <example>
        ///     <code>
        ///     List&lt;SHAttendanceRecord&gt; records = SHAttendance.SelectAll();
        ///     
        ///     foreach(SHAttendanceRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>    
        /// <exception cref="Exception">
        /// </exception>
        public new static List<SHAttendanceRecord> SelectAll()
        {
            return SelectAll<SHAttendanceRecord>();
        }

        /// <summary>
        /// 根據條件取得缺曠紀錄列表
        /// </summary>
        /// <param name="StudentIDs">學生編號列表</param>
        /// <param name="StartDate">缺曠發生開始時間</param>
        /// <param name="EndDate">缺曠發生結束時間</param>
        /// <param name="OccurDate">缺曠發生時間</param>
        /// <param name="SchoolYears">學年度列表</param>
        /// <param name="Semesters">學期列表</param>
        /// <returns>List&lt;SHAttendanceRecord&gt;，一個 AttendanceRecord物件代表一個學生在某一天的缺曠紀錄。</returns>
        public static new List<SHAttendanceRecord> Select(IEnumerable<string> StudentIDs, DateTime? StartDate, DateTime? EndDate, DateTime? OccurDate, IEnumerable<int> SchoolYears, IEnumerable<int> Semesters)
        {
            return Select<SHAttendanceRecord>(StudentIDs, StartDate, EndDate, OccurDate, SchoolYears, Semesters);
        }

        /// <summary>
        /// 根據條件取得缺曠紀錄列表
        /// </summary>
        /// <param name="StudentIDs">學生編號列表</param>
        /// <param name="StartDate">缺曠發生開始時間</param>
        /// <param name="EndDate">缺曠發生結束時間</param>
        /// <param name="OccurDates">缺曠發生時間列表</param>
        /// <param name="SchoolYears">學年度列表</param>
        /// <param name="Semesters">學期列表</param>
        /// <param name="SchoolYearSemesters">學年度學期列表</param>
        /// <returns>List&lt;SHAttendanceRecord&gt;，一個 AttendanceRecord物件代表一個學生在某一天的缺曠紀錄。</returns>
        public static new List<SHAttendanceRecord> Select(IEnumerable<string> StudentIDs, DateTime? StartDate, DateTime? EndDate, IEnumerable<DateTime> OccurDates, IEnumerable<int> SchoolYears, IEnumerable<int> Semesters, IEnumerable<SchoolYearSemester> SchoolYearSemesters)
        {
            return K12.Data.Attendance.Select<SHAttendanceRecord>(StudentIDs, StartDate, EndDate, OccurDates, SchoolYears, Semesters, SchoolYearSemesters);
        }

        /// <summary>
        /// 取得指定學生在某學年度學期的學生缺曠紀錄
        /// </summary>
        /// <param name="Students">學生記錄物件列表</param>
        /// <param name="SchoolYear">學年度，傳入null代表取得所有學年度資料。</param>
        /// <param name="Semester">學期，傳入null代表取得所有學期資料。</param>
        /// <returns>List&lt;SHAttendanceRecord&gt;，一個 AttendanceRecord物件代表一個學生在某一天的缺曠紀錄。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <example>
        ///     <code>
        ///     List&lt;SHAttendanceRecord&gt; records = SHAttendance.SelectBySchoolYearAndSemester(Students, 98,1);
        ///     
        ///     foreach(SHAttendanceRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>    
        /// <exception cref="Exception">
        /// </exception>
        public static List<SHAttendanceRecord> SelectBySchoolYearAndSemester(IEnumerable<SHStudentRecord> Students,
                                                                        int? SchoolYear,
                                                                        int? Semester)
        {
            return K12.Data.Attendance.SelectBySchoolYearAndSemester<SHAttendanceRecord>(K12.Data.Utility.Utility.GetBaseList<StudentRecord, SHStudentRecord>(Students), SchoolYear, Semester);
        }

        /// <summary>
        /// 取得指定學生在日期區間的學生缺曠紀錄
        /// </summary>
        /// <param name="Students">學生記錄物件列表</param>
        /// <param name="BeginDate">開始日期</param>
        /// <param name="EndDate">結束日期</param>
        /// <returns>List&lt;SHAttendanceRecord&gt;，一個 AttendanceRecord物件代表一個學生在某一天的缺曠紀錄。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <remarks></remarks>
        /// <example>
        ///     <code>
        ///     DateTime beginDate = new DateTime(2009, 4, 1);
        ///     DateTime endDate = DateTime.Now ;
        ///
        ///     ListList&lt;SHAttendanceRecord&gt; records = SHAttendance.SelectByDate(Students, beginDate, endDate );
        ///     
        ///     foreach(SHAttendanceRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        public static List<SHAttendanceRecord> SelectByDate(IEnumerable<SHStudentRecord> Students,
                                                        DateTime BeginDate,
                                                        DateTime EndDate)
        {
            return K12.Data.Attendance.SelectByDate<SHAttendanceRecord>(K12.Data.Utility.Utility.GetBaseList<StudentRecord, SHStudentRecord>(Students),BeginDate ,EndDate);
        }

        /// <summary>
        /// 取得指定日期區間的學生缺曠紀錄
        /// </summary>
        /// <param name="BeginDate">開始日期</param>
        /// <param name="EndDate">結束日期</param>
        /// <returns>List&lt;SHAttendanceRecord&gt;，一個AttendanceRecord物件代表一個學生在某一天的缺曠紀錄。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <example>
        ///     <code>
        ///     DateTime beginDate = new DateTime(2009, 4, 1);
        ///     DateTime endDate = DateTime.Now ;
        ///
        ///     List&lt;SHAttendanceRecord&gt; records = SHAttendance.SelectByDate(StudentIDs,beginDate, endDate );
        ///     foreach(SHAttendanceRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        public static new List<SHAttendanceRecord> SelectByDate(DateTime BeginDate, DateTime EndDate)
        {
            return K12.Data.Attendance.SelectByDate<SHAttendanceRecord>(BeginDate, EndDate);
        }

        /// <summary>
        /// 取得指定學生歷年所有的學生缺曠紀錄
        /// </summary>
        /// <param name="Students">學生記錄物件列表</param>
        /// <returns>List&lt;SHAttendanceRecord&gt;，一個 AttendanceRecord物件代表一個學生在某一天的缺曠紀錄。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <example>
        ///     <code>
        ///     List&lt;SHAttendanceRecord&gt; records = SHAttendance.SelectByStudents(Students);
        ///     
        ///     foreach(SHAttendanceRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        public static List<SHAttendanceRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students)
        {
            return K12.Data.Attendance.SelectByStudents<SHAttendanceRecord>(K12.Data.Utility.Utility.GetBaseList<StudentRecord, SHStudentRecord>(Students));
        }

        /// <summary>
        /// 根據多筆學生編號取得學生缺曠紀錄
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHAttendanceRecord&gt;，一個 SHAttendanceRecord物件代表一個學生在某一天的缺曠紀錄。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <example>
        ///     <code>
        ///     List&lt;SHAttendanceRecord&gt; records = SHAttendance.SelectByStudentIDs(StudentIDs);
        ///     
        ///     foreach(SHAttendanceRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        public static new List<SHAttendanceRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.Attendance.SelectByStudentIDs<SHAttendanceRecord>(StudentIDs);
        }

        /// <summary>
        /// 新增單筆學生缺曠記錄
        /// </summary>
        /// <param name="AttendanceRecord">學生缺曠記錄</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHAttendanceRecord newrecord = new SHAttendanceRecord();
        ///         newrecord.RefStudentID = RefStudentID;
        ///         newrecord.SchoolYear = SchoolYear;
        ///         newrecord.Semester = Semester;
        ///         newrecord.OccurDate = DateTime.Today;
        ///         strng NewID = SHAttendance.Insert(newrecord)
        ///         SHAttendanceRecord record = SHAttendance.SelectByID(NewID);
        ///         System.Console.Writeln(record.RefStudentID);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增一律傳回新增物件的編號。
        /// 2.新增必填欄位為學生記錄編號（RefStudentID）、學年度（SchoolYear）、學期（Semester）、缺曠日期（OccurDate）。
        /// </remarks>
        public static string Insert(SHAttendanceRecord AttendanceRecord)
        {
            return K12.Data.Attendance.Insert(AttendanceRecord);
        }

        /// <summary>
        /// 新增多筆學生缺曠記錄
        /// </summary>
        /// <param name="AttendanceRecords">多筆班級記錄物件</param> 
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHAttendanceRecord record = new SHAttendanceRecord();
        ///         newrecord.RefStudentID = RefStudentID;
        ///         newrecord.SchoolYear = SchoolYear;
        ///         newrecord.Semester = Semester;
        ///         newrecord.OccurDate = DateTime.Today;
        ///         
        ///         List&lt;SHAttendanceRecord&gt; records = new List&lt;SHAttendanceRecord&gt;();
        ///         records.Add(record);
        ///         List&lt;string&gt; NewID = SHAttendance.Insert(records)
        ///     </code>
        /// </example>
        public static List<string> Insert(IEnumerable<SHAttendanceRecord> AttendanceRecords)
        {
            return K12.Data.Attendance.Insert(K12.Data.Utility.Utility.GetBaseList<AttendanceRecord, SHAttendanceRecord>(AttendanceRecords));
        }

        /// <summary>
        /// 更新單筆學生缺曠記錄
        /// </summary>
        /// <param name="AttendanceRecord">學生缺曠記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHAttendanceRecord record = SHAttendance.SelectByStudentID(Student)[0];
        ///     record.OccurDate = DateTime.Today;
        ///     int UpdateCount = SHAttendance.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHAttendanceRecord AttendanceRecord)
        {
            return K12.Data.Attendance.Update(AttendanceRecord);
        }

        /// <summary>
        /// 更新多筆學生缺曠記錄
        /// </summary>
        /// <param name="AttendanceRecords">多筆學生缺曠記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHAttendanceRecord record = SHAttendance.SelectByStudentID(Student)[0];
        ///     record.Date = DateTime.Today;
        ///     List&lt;SHAttendanceRecord&gt; records = new List&lt;SHAttendanceRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHAttendance.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHAttendanceRecord> AttendanceRecords)
        {
            return K12.Data.Attendance.Update(K12.Data.Utility.Utility.GetBaseList<AttendanceRecord, SHAttendanceRecord>(AttendanceRecords));
        }

        /// <summary>
        /// 刪除單筆學生缺曠記錄
        /// </summary>
        /// <param name="AttendanceRecord">學生缺曠記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHAttendanceRecord&gt; records = SHAttendance.SelectByStudentIDs(StudentIDs);
        ///       int DeleteCount = SHAttendance.Delete(records[0]);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHAttendanceRecord AttendanceRecord)
        {
            return K12.Data.Attendance.Delete(AttendanceRecord);
        }

        /// <summary>
        /// 刪除單筆學生缺曠記錄
        /// </summary>
        /// <param name="AttendanceRecordID">學生缺曠記錄編號</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = JHAttendance.Delete(AttendanceID);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(string AttendanceRecordID)
        {
            return K12.Data.Attendance.Delete(AttendanceRecordID);
        }

        /// <summary>
        /// 刪除多筆學生缺曠記錄
        /// </summary>
        /// <param name="AttendanceRecords">多筆學生缺曠記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHAttendanceRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHAttendanceRecord&gt; records = SHAttendance.SelectByStudentIDs(StudentIDs);
        ///       int DeleteCount = SHAttendance.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(IEnumerable<SHAttendanceRecord> AttendanceRecords)
        {
            return K12.Data.Attendance.Delete(K12.Data.Utility.Utility.GetBaseList<AttendanceRecord, SHAttendanceRecord>(AttendanceRecords));
        }

        /// <summary>
        /// 刪除多筆學生缺曠記錄
        /// </summary>
        /// <param name="AttendanceRecordIDs">多筆學生缺曠記錄編號</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHAttendance.Delete(AttendanceIDs);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(IEnumerable<string> AttendanceRecordIDs)
        {
            return K12.Data.Attendance.Delete(AttendanceRecordIDs);
        }
    }
}