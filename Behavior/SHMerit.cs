using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生獎勵類別，提供方法用來取得、新增、修改及刪除學生獎勵資訊
    /// </summary>
    public class SHMerit : K12.Data.Merit
    {
        /// <summary>
        /// 取得所有學生獎勵記錄物件列表。
        /// </summary>
        /// <returns>List&lt;SHMeritRecord&gt;，代表多筆學生獎勵記錄物件。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHMeritRecord&gt; records = SHMerit.SelectAll();
        ///     
        ///     foreach(SHMeritRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHMerit.SelectAll", "學務.獎勵")]
        public static new List<SHMeritRecord> SelectAll()
        {
            return K12.Data.Merit.SelectAll<SHMeritRecord>();
        }

        /// <summary>
        /// 根據條件取得獎勵紀錄列表 
        /// </summary>
        /// <param name="StudentIDs">學生編號列表</param>
        /// <param name="StartDate">開始時間</param>
        /// <param name="EndDate">結束時間</param>
        /// <param name="StartRegisterDate">開始登錄時間</param>
        /// <param name="EndRegisterDate">結束登錄時間</param>
        /// <param name="SchoolYears">學年度</param>
        /// <param name="Semesters">學期</param>
        /// <returns>List&lt;SHMeritRecord&gt;，多筆獎勵紀錄物件列表</returns>
        public static new List<SHMeritRecord> Select(IEnumerable<string> StudentIDs, DateTime? StartDate, DateTime? EndDate, DateTime? StartRegisterDate, DateTime? EndRegisterDate, IEnumerable<int> SchoolYears, IEnumerable<int> Semesters)
        {
            return Select<SHMeritRecord>(StudentIDs, StartDate, EndDate, StartRegisterDate, EndRegisterDate, SchoolYears, Semesters);
        }

        /// <summary>
        /// 根據條件取得獎勵紀錄列表
        /// </summary>
        /// <param name="StudentIDs">學生編號列表</param>
        /// <param name="StartDate">開始時間</param>
        /// <param name="EndDate">結束時間</param>
        /// <param name="StartRegisterDate">開始登錄時間</param>
        /// <param name="EndRegisterDate">結束登錄時間</param>
        /// <param name="SchoolYears">學年度列表</param>
        /// <param name="Semesters">學期列表</param>
        /// <param name="SchoolYearSemesters">學年度學期列表</param>
        /// <returns>List&lt;SHMeritRecord&gt;，多筆獎勵紀錄物件列表</returns>
        public static new List<SHMeritRecord> Select(IEnumerable<string> StudentIDs, DateTime? StartDate, DateTime? EndDate, DateTime? StartRegisterDate, DateTime? EndRegisterDate, IEnumerable<int> SchoolYears, IEnumerable<int> Semesters, IEnumerable<SchoolYearSemester> SchoolYearSemesters)
        {
            return Select<SHMeritRecord>(StudentIDs, StartDate, EndDate, StartRegisterDate, EndRegisterDate, SchoolYears, Semesters, SchoolYearSemesters);
        }

        /// <summary>
        /// 根據單筆學生編號、學年度及學期取得學生獎勵記錄物件列表。
        /// </summary>
        /// <param name="StudentID">單筆學生編號</param>
        /// <param name="SchoolYear">學年度，傳入null取得所有學年度資料</param>
        /// <param name="Semester">學期，傳入null取得所有學期資料</param>
        /// <returns>List&lt;SHMeritRecord&gt;，代表多筆學生獎勵記錄物件。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHMeritRecord&gt; records = SHMerit.SelectBySchoolYearAndSemester(StudentID,School,Semester);
        ///     
        ///     foreach(SHMeritRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        public static new List<SHMeritRecord> SelectBySchoolYearAndSemester(string StudentID, int? SchoolYear, int? Semester)
        {
            return K12.Data.Merit.SelectBySchoolYearAndSemester<SHMeritRecord>(StudentID, SchoolYear, Semester);
        }

        /// <summary>
        /// 根據多筆學生編號、學年度及學期取得學生獎勵記錄物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <param name="SchoolYear">學年度，傳入null代表取得所有學年度的資料</param>
        /// <param name="Semester">學期，傳入null代表取得所有學年度的資料</param>
        /// <returns>List&lt;SHMeritRecord&gt;，代表多筆學生獎勵記錄物件。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHMeritRecord&gt; records = SHMerit.SelectBySchoolYearAndSemester(StudentIDs,School,Semester);
        ///     
        ///     foreach(SHMeritRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        public static new List<SHMeritRecord> SelectBySchoolYearAndSemester(IEnumerable<string> StudentIDs, int? SchoolYear, int? Semester)
        {
            return K12.Data.Merit.SelectBySchoolYearAndSemester<SHMeritRecord>(StudentIDs, SchoolYear, Semester);
        }

        /// <summary>
        /// 根據多筆學生編號取得學生獎勵記錄物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHMeritRecord&gt;，代表多筆學生獎勵記錄物件。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHMeritRecord&gt; records = SHMerit.SelectByStudentIDs(StudentIDs);
        ///     
        ///     foreach(SHMeritRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        public static new List<SHMeritRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.Merit.SelectByStudentIDs<SHMeritRecord>(StudentIDs);
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("此方法已不再使用。")] 
        public static List<SHMeritRecord> SelectRegisterDate(IEnumerable<string> StudentIDs, DateTime? StartRegisterDate, DateTime? EndRegisterDate)
        {
            return K12.Data.Merit.SelectByRegisterDate<SHMeritRecord>(StudentIDs, StartRegisterDate, EndRegisterDate);
        }

        /// <summary>
        /// 根據多筆學生編號及登錄日期取得學生獎勵記錄物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <param name="StartRegisterDate">登錄開始日期</param>
        /// <param name="EndRegisterDate">登錄結束日期</param>
        /// <returns>List&lt;SHMeritRecord&gt;，代表多筆學生獎勵記錄物件。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHMeritRecord&gt; records = SHMerit.SelectByRegisterDate(StudentIDs,StartRegisterDate,EndRegisterDate);
        ///     
        ///     foreach(SHMeritRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.若是StartRegisterDate傳入null，則會傳回EndRegisterDate之前的資料。
        /// 2.若是EndRegisterDate傳入null，則會傳回StartRegisterDate之後的資料。
        /// </remarks>
        public static List<SHMeritRecord> SelectByRegisterDate(IEnumerable<string> StudentIDs, DateTime? StartRegisterDate, DateTime? EndRegisterDate)
        {
            return K12.Data.Merit.SelectByRegisterDate<SHMeritRecord>(StudentIDs, StartRegisterDate, EndRegisterDate);
        }

        /// <summary>
        /// 根據多筆學生編號及發生日期取得學生獎勵記錄物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <param name="StartOccurDate">發生開始日期</param>
        /// <param name="EndOccurDate">發生結束日期</param>
        /// <returns>List&lt;SHMeritRecord&gt;，代表多筆學生獎勵記錄物件。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHMeritRecord&gt; records = SHMerit.SelectByOccurDate(StudentIDs,StartOccurDate,EndOccurDate);
        ///     
        ///     foreach(SHMeritRecord record in records)
        ///         System.Console.WriteLine(record.RefStudentID);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.若是StartOccurDate傳入null，則會傳回EndOccurDate之前的資料。
        /// 2.若是EndOccurDate傳入null，則會傳回StartOccurDate之後的資料。
        /// </remarks>
        public static new List<SHMeritRecord> SelectByOccurDate(IEnumerable<string> StudentIDs, DateTime? StartOccurDate, DateTime? EndOccurDate)
        {
            return K12.Data.Merit.SelectByOccurDate<SHMeritRecord>(StudentIDs, StartOccurDate, EndOccurDate);
        }

        /// <summary>
        /// 新增單筆學生獎勵記錄
        /// </summary>
        /// <param name="MeritRecord">學生獎勵記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHMeritRecord newrecord = new SHMeritRecord();
        ///         newrecord.RefStudentID = RefStudentID;
        ///         newrecord.SchoolYear = SchoolYear;
        ///         newrecord.Semester = Semester;
        ///         newrecord.OccurDate = DateTime.Today;
        ///         strng NewID = SHMerit.Insert(newrecord)
        ///         MeritRecord record = SHMerit.SelectByID(NewID);
        ///         System.Console.Writeln(record.RefStudentID);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增一律傳回新增物件的編號。
        /// 2.新增必填欄位為學生記錄編號（RefStudentID）、學年度（SchoolYear）、學期（Semester）、缺曠日期（OccurDate）。
        /// </remarks>
        public static string Insert(SHMeritRecord MeritRecord)
        {
            return K12.Data.Merit.Insert(MeritRecord);
        }

        /// <summary>
        /// 新增多筆學生獎勵記錄
        /// </summary>
        /// <param name="MeritRecords">多筆學生獎勵記錄物件</param> 
        /// <returns>List&lt;string&gt，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHMeritRecord record = new SHMeritRecord();
        ///         newrecord.RefStudentID = RefStudentID;
        ///         newrecord.SchoolYear = SchoolYear;
        ///         newrecord.Semester = Semester;
        ///         newrecord.OccurDate = DateTime.Today;
        ///         
        ///         List&lt;SHMeritRecord&gt; records = new List&lt;SHMeritRecord&gt;();
        ///         records.Add(record);
        ///         List&lt;string&gt; NewID = Merit.Insert(records)
        ///     </code>
        /// </example>
        public static List<string> Insert(IEnumerable<SHMeritRecord> MeritRecords)
        {
            return K12.Data.Merit.Insert(K12.Data.Utility.Utility.GetBaseList<MeritRecord, SHMeritRecord>(MeritRecords));
        }

        /// <summary>
        /// 更新單筆學生獎勵記錄
        /// </summary>
        /// <param name="MeritRecord">學生獎勵記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHMeritRecord record = SHMerit.SelectByStudentIDs(StudentIDs)[0];
        ///     record.OccurDate = DateTime.Today;
        ///     int UpdateCount = SHMerit.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHMeritRecord MeritRecord)
        {
            return K12.Data.Merit.Update(MeritRecord);
        }

        /// <summary>
        /// 更新多筆學生獎勵記錄
        /// </summary>
        /// <param name="MeritRecords">多筆學生獎勵記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHMeritRecord record = SHMerit.SelectByStudentIDs(StudentIDs)[0];
        ///     record.OccurDate = DateTime.Today;
        ///     List&lt;SHMeritRecord&gt; records = new List&lt;SHMeritRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = Merit.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHMeritRecord> MeritRecords)
        {
            return K12.Data.Merit.Update(K12.Data.Utility.Utility.GetBaseList<MeritRecord, SHMeritRecord>(MeritRecords));
        }

        /// <summary>
        /// 刪除單筆學生獎勵記錄
        /// </summary>
        /// <param name="MeritRecord">學生獎勵記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHMeritRecord&gt; records = SHMerit.SelectByStudentIDs(StudentIDs);
        ///       int DeleteCount = SHMerit.Delete(records[0]);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHMeritRecord MeritRecord)
        {
            return K12.Data.Merit.Delete(MeritRecord);
        }

        /// <summary>
        /// 刪除單筆學生獎勵記錄
        /// </summary>
        /// <param name="MeritID">學生獎勵記錄編號</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHMerit.Delete(MeritID);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(string MeritID)
        {
            return K12.Data.Merit.Delete(MeritID);
        }

        /// <summary>
        /// 刪除多筆學生獎勵記錄
        /// </summary>
        /// <param name="MeritRecords">多筆學生獎勵記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHMeritRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHMeritRecord&gt; records = SHMerit.SelectByStudentIDs(StudentIDs);
        ///       int DeleteCount = SHMerit.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(IEnumerable<SHMeritRecord> MeritRecords)
        {
            return K12.Data.Merit.Delete(K12.Data.Utility.Utility.GetBaseList<MeritRecord, SHMeritRecord>(MeritRecords));
        }

        /// <summary>
        /// 刪除多筆學生獎勵記錄
        /// </summary>
        /// <param name="MeritIDs">多筆學生獎勵記錄編號</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHMerit.Delete(MeritIDs);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(IEnumerable<string> MeritIDs)
        {
            return K12.Data.Merit.Delete(MeritIDs);
        }
    }
}