using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學期德行評量類別，提供方法用來取得、新增、修改及刪除學期德行評量資訊
    /// </summary>
    public class SHMoralScore : K12.Data.MoralScore
    {
        /// <summary>
        /// 取得所有學期德行評量列表。
        /// </summary>
        /// <returns>List&lt;SHMoralScoreRecord&gt;，代表多筆學期德行評量記錄物件。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHMoralScoreRecord&gt; records = SHMoralScore.SelectAll();
        ///     </code>
        /// </example>
        public static new List<SHMoralScoreRecord> SelectAll()
        {
            return K12.Data.MoralScore.SelectAll<SHMoralScoreRecord>();
        }

        /// <summary>
        /// 取得德行評量列表
        /// </summary>
        /// <param name="IDs">德行評量記錄物件編號列表。</param>
        /// <param name="StudentIDs">學生編號列表。</param>
        /// <param name="SchoolYear">學年度。</param>
        /// <param name="Semester">學期。</param>
        /// <returns>List&lt;MoralScoreRecord&gt;，代表多筆學期德行評量記錄物件。</returns>
        public static new List<SHMoralScoreRecord> Select(IEnumerable<string> IDs, IEnumerable<string> StudentIDs, int? SchoolYear, int? Semester)
        {
            return K12.Data.MoralScore.Select<SHMoralScoreRecord>(IDs, StudentIDs, SchoolYear, Semester);
        }

        /// <summary>
        /// 取得德行評量列表 
        /// </summary>
        /// <param name="IDs">德行評量記錄物件編號列表。</param>
        /// <param name="StudentIDs">學生編號列表。</param>
        /// <param name="SchoolYear">學年度。</param>
        /// <param name="Semester">學期。</param>
        /// <param name="SchoolYearSemesters">學年度學期列表。</param>
        /// <returns>List&lt;SHMoralScoreRecord&gt;，代表多筆學期德行評量記錄物件。</returns>
        public static new List<SHMoralScoreRecord> Select(IEnumerable<string> IDs, IEnumerable<string> StudentIDs, int? SchoolYear, int? Semester, IEnumerable<SchoolYearSemester> SchoolYearSemesters)
        {
            return Select<SHMoralScoreRecord>(IDs, StudentIDs, SchoolYear, Semester, SchoolYearSemesters);
        }

        /// <summary>
        /// 根據學生編號、學年度及學期取得學期德行評量列表。
        /// </summary>
        /// <param name="StudentID">學生編號</param>
        /// <param name="SchoolYear">學年度</param>
        /// <param name="Semester">學期</param>
        /// <returns>List&lt;SHMoralScoreRecord&gt;，代表多筆學期德行評量記錄物件。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHMoralScoreRecord&gt; records = SHMoralScore.SelectBySchoolYearAndSemester(StudentID,SchoolYear,Semester);
        /// </example>
        public static new SHMoralScoreRecord SelectBySchoolYearAndSemester(string StudentID, int SchoolYear, int Semester)
        {
            return K12.Data.MoralScore.SelectBySchoolYearAndSemester<SHMoralScoreRecord>(StudentID, SchoolYear, Semester);
        }

        /// <summary>
        /// 根據多筆學生編號取得學期德行評量列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHMoralScoreRecord&gt;，代表多筆學期德行評量記錄物件。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHMoralScoreRecord&gt; records = SHMoralScore.SelectByStudentIDs(StudentIDs);
        /// </example>
        public static new List<SHMoralScoreRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.MoralScore.SelectByStudentIDs<SHMoralScoreRecord>(StudentIDs);
        }

        /// <summary>
        /// 新增單筆學期德行評量記錄
        /// </summary>
        /// <param name="MoralScoreRecord">學期德行評量記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        public static string Insert(SHMoralScoreRecord MoralScoreRecord)
        {
            return K12.Data.MoralScore.Insert(MoralScoreRecord);
        }

        /// <summary>
        /// 新增多筆學期德行評量記錄
        /// </summary>
        /// <param name="MoralScoreRecords">多筆學期德行評量記錄物件</param> 
        /// <returns>List&lt;string&gt，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static List<string> Insert(IEnumerable<SHMoralScoreRecord> MoralScoreRecords)
        {
            List<K12.Data.MoralScoreRecord> MoralScores = new List<K12.Data.MoralScoreRecord>();

            foreach (MoralScoreRecord MoralScoreRecord in MoralScoreRecords)
                MoralScores.Add(MoralScoreRecord);

            return K12.Data.MoralScore.Insert(MoralScores);
        }

        /// <summary>
        /// 更新單筆學期德行評量記錄
        /// </summary>
        /// <param name="MoralScoreRecord">學期德行評量記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(SHMoralScoreRecord MoralScoreRecord)
        {
            return K12.Data.MoralScore.Update(MoralScoreRecord);
        }

        /// <summary>
        /// 更新多筆學期德行評量記錄
        /// </summary>
        /// <param name="MoralScoreRecords">多筆學期德行評量記錄</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(IEnumerable<SHMoralScoreRecord> MoralScoreRecords)
        {
            List<K12.Data.MoralScoreRecord> MoralScores = new List<K12.Data.MoralScoreRecord>();

            foreach (MoralScoreRecord MoralScoreRecord in MoralScoreRecords)
                MoralScores.Add(MoralScoreRecord);

            return K12.Data.MoralScore.Update(MoralScores);
        }

        /// <summary>
        /// 刪除單筆學期德行評量記錄
        /// </summary>
        /// <param name="MoralScoreRecord">學期德行評量記錄物件</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHMoralScoreRecord MoralScoreRecord)
        {
            return K12.Data.MoralScore.Delete(MoralScoreRecord);
        }

        /// <summary>
        /// 刪除單筆學期德行評量記錄
        /// </summary>
        /// <param name="MoralScoreID">學期德行評量記錄編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(string MoralScoreID)
        {
            return K12.Data.MoralScore.Delete(MoralScoreID);
        }

        /// <summary>
        /// 刪除多筆學期德行評量記錄
        /// </summary>
        /// <param name="MoralScoreRecords">多筆學期德行評量記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHMoralScoreRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHMoralScoreRecord> MoralScoreRecords)
        {
            List<K12.Data.MoralScoreRecord> MoralScores = new List<K12.Data.MoralScoreRecord>();

            foreach (MoralScoreRecord MoralScoreRecord in MoralScoreRecords)
                MoralScores.Add(MoralScoreRecord);

            return K12.Data.MoralScore.Delete(MoralScores);
        }

        /// <summary>
        /// 刪除多筆學期德行評量記錄
        /// </summary>
        /// <param name="MoralScoreIDs">多筆學期德行評量記錄編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(IEnumerable<string> MoralScoreIDs)
        {
            return K12.Data.MoralScore.Delete(MoralScoreIDs);
        }
    }
}
