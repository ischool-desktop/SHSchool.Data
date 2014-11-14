using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生修課類別，提供方法用來取得、新增、修改及刪除學生修課資訊
    /// </summary>
    public class SHSCAttend : K12.Data.SCAttend
    {
        /// <summary>
        /// 取得所有學生修課列表。
        /// </summary>
        /// <returns>List&lt;SHSCAttendRecord&gt;，代表多筆學生修課記錄物件。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SCAttendRecord&gt; records = SHSCAttend.SelectAll();
        /// </example>
        [SelectMethod("SHSchool.SHSCAttend.SelectAll", "成績.學生修課")]
        public static new List<SHSCAttendRecord> SelectAll()
        {
            return SelectAll<SHSCAttendRecord>();
        }

        /// <summary>
        /// 根據條件取得學生修課列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <param name="CourseIDs">多筆課程編號</param>
        /// <param name="SCAttendIDs">多筆學生修課列表</param>
        /// <param name="SchoolYear">學年度</param>
        /// <param name="Semester">學期</param>
        /// <returns>List&lt;SHSCAttendRecord&gt;，代表多筆學生修課記錄物件。</returns>
        public new static List<SHSCAttendRecord> Select(IEnumerable<string> StudentIDs, IEnumerable<string> CourseIDs, IEnumerable<string> SCAttendIDs, string SchoolYear, string Semester)
        {
            return Select<SHSCAttendRecord>(StudentIDs, CourseIDs, SCAttendIDs, SchoolYear, Semester);
        }

        /// <summary>
        /// 根據單筆學生修課編號取得學生修課列表。
        /// </summary>
        /// <param name="SCAttendID">單筆學生修課編號</param>
        /// <returns>SHSCAttendRecord，代表單筆學生修課記錄物件。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     SHSCAttendRecord record = SHSCAttend.SelectByID(SCAttendID);
        /// </example>
        public static new SHSCAttendRecord SelectByID(string SCAttendID)
        {
            return SelectByID<SHSCAttendRecord>(SCAttendID);
        }

        /// <summary>
        /// 根據多筆學生修課編號取得學生修課列表。
        /// </summary>
        /// <param name="SCAttendIDs">多筆學生修課編號</param>
        /// <returns>List&lt;SHSCAttendRecord&gt;，代表多筆學生修課記錄物件。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHSCAttendRecord&gt; records = SHSCAttend.SelectByIDs(SCAttendIDs);
        /// </example>
        public static new List<SHSCAttendRecord> SelectByIDs(IEnumerable<string> SCAttendIDs)
        {
            return SelectByIDs<SHSCAttendRecord>(SCAttendIDs);
        }

        /// <summary>
        /// 根據多筆學生編號及多筆課程編號取得學生修課列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <param name="CourseIDs">多筆課程編號</param>
        /// <returns>List&lt;SCAttendRecord&gt;，代表多筆學生修課記錄物件。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHSCAttendRecord&gt; records = SHSCAttend.GetByStudentIDsAndCourseIDs(StudentIDs,CourseIDs);
        /// </example>
        public static List<SHSCAttendRecord> SelectByStudentIDAndCourseID(IEnumerable<string> StudentIDs, IEnumerable<string> CourseIDs)
        {
            return SelectByStudentIDAndCourseID<SHSCAttendRecord>(StudentIDs, CourseIDs);
        }

        /// <summary>
        /// 根據單筆學生編號取得學生修課列表。
        /// </summary>
        /// <param name="StudentID">單筆學生編號</param>
        /// <returns>List&lt;SHSCAttendRecord&gt;，代表多筆學生修課記錄物件。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHSCAttendRecord&gt; records = SHSCAttend.SelectByStudentID(StudentID);
        /// </example>
        public static List<SHSCAttendRecord> SelectByStudentID(string StudentID)
        {
            return K12.Data.SCAttend.SelectByStudentID<SHSCAttendRecord>(StudentID);
        }

        /// <summary>
        /// 根據多筆學生編號取得學生修課列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHSCAttendRecord&gt;，代表多筆學生修課記錄物件。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHSCAttendRecord&gt; records = SHSCAttend.SelectByStudentIDs(StudentIDs);
        /// </example>
        public static List<SHSCAttendRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.SCAttend.SelectByStudentIDs<SHSCAttendRecord>(StudentIDs);
        }

        /// <summary>
        /// 新增單筆學生修課記錄
        /// </summary>
        /// <param name="SCAttendRecord">學生修課記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        public static string Insert(SHSCAttendRecord SCAttendRecord)
        {
            return K12.Data.SCAttend.Insert(SCAttendRecord);
        }

        /// <summary>
        /// 新增多筆學生修課記錄
        /// </summary>
        /// <param name="SCAttendRecords">多筆學生修課記錄物件</param> 
        /// <returns>List&lt;string&gt，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static List<string> Insert(IEnumerable<SHSCAttendRecord> SCAttendRecords)
        {
            List<K12.Data.SCAttendRecord> SCAttends = new List<K12.Data.SCAttendRecord>();

            foreach (SCAttendRecord SCAttendRecord in SCAttendRecords)
                SCAttends.Add(SCAttendRecord);

            return K12.Data.SCAttend.Insert(SCAttends);
        }

        /// <summary>
        /// 更新單筆學生修課記錄
        /// </summary>
        /// <param name="SCAttendRecord">學生修課記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(SHSCAttendRecord SCAttendRecord)
        {
            return K12.Data.SCAttend.Update(SCAttendRecord);
        }

        /// <summary>
        /// 更新多筆學生修課記錄
        /// </summary>
        /// <param name="SCAttendRecords">多筆學生修課記錄</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(IEnumerable<SHSCAttendRecord> SCAttendRecords)
        {
            List<K12.Data.SCAttendRecord> SCAttends = new List<K12.Data.SCAttendRecord>();

            foreach (SCAttendRecord SCAttendRecord in SCAttendRecords)
                SCAttends.Add(SCAttendRecord);

            return K12.Data.SCAttend.Update(SCAttends);
        }

        /// <summary>
        /// 刪除單筆學生修課記錄
        /// </summary>
        /// <param name="SCAttendRecord">學生修課記錄物件</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHSCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHSCAttendRecord SCAttendRecord)
        {
            return K12.Data.SCAttend.Delete(SCAttendRecord);
        }

        /// <summary>
        /// 刪除單筆學生修課記錄
        /// </summary>
        /// <param name="SCAttendID">學生修課編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(string SCAttendID)
        {
            return K12.Data.SCAttend.Delete(SCAttendID);
        }

        /// <summary>
        /// 刪除多筆學生修課記錄
        /// </summary>
        /// <param name="SCAttendRecords">多筆學生修課記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SCAttendRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHSCAttendRecord> SCAttendRecords)
        {
            List<K12.Data.SCAttendRecord> SCAttends = new List<K12.Data.SCAttendRecord>();

            foreach (SCAttendRecord SCAttendRecord in SCAttendRecords)
                SCAttends.Add(SCAttendRecord);

            return K12.Data.SCAttend.Delete(SCAttends);
        }


        /// <summary>
        /// 刪除多筆學生修課記錄
        /// </summary>
        /// <param name="SCAttendIDs">多筆學生修課編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(IEnumerable<string> SCAttendIDs)
        {
            return K12.Data.SCAttend.Delete(SCAttendIDs);
        }
    }
}