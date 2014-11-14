using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 課程類別，提供方法用來取得、新增、修改及刪除課程資訊
    /// </summary>
    public class SHCourse : K12.Data.Course
    {
        /// <summary>
        /// 取得所有課程列表。
        /// </summary>
        /// <returns>List&lt;SHCourseRecord&gt;，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHCourseRecord&gt; records = SHCourse.SelectAll();
        ///     
        ///     foreach(SHCourseRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks>
        /// 請先using K12.Data;
        /// </remarks>
        [SelectMethod("SHSchool.SHCourse.SelectAll", "學籍.課程")]
        public static new List<SHCourseRecord> SelectAll()
        {
            return SelectAll<SHCourseRecord>();
        }

        /// <summary>
        /// 根據學年度、學期及班級記錄物件列表取得課程列表。
        /// </summary>
        /// <param name="SchoolYear">學年度，傳入null代表取得所有學年度資料。</param>
        /// <param name="Semester">學期，傳入null代表取得所有學期資料。</param>
        /// <param name="ClassRecs">多筆班級記錄物件</param>
        /// <returns>List&lt;CourseRecord&gt;，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <seealso cref="JHClassRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///   <code>
        ///     List&lt;SHCourseRecord&gt; records = SHCourse.SelectByClass(SchoolYear,Semester,ClassRecs);
        ///     
        ///     foreach(SHCourseRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///    </code>
        /// </example>
        /// <remarks></remarks>
        public static List<SHCourseRecord> SelectByClass(int? SchoolYear, int? Semester, IEnumerable<SHClassRecord> ClassRecs)
        {
            List<string> IDs = new List<string>();

            foreach (SHClassRecord ClassRec in ClassRecs)
                IDs.Add(ClassRec.ID);

            return K12.Data.Course.SelectByClass<SHCourseRecord>(SchoolYear, Semester, IDs);
        }

        /// <summary>
        /// 根據學年度、學期及班級記錄編號列表取得課程列表。
        /// </summary>
        /// <param name="SchoolYear">學年度，傳入null代表取得所有學年度資料。</param>
        /// <param name="Semester">學期，傳入null代表取得所有學期資料。</param>
        /// <param name="ClassIDs">多筆班級記錄編號</param>
        /// <returns>List&lt;SHCourseRecord&gt;，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///   <code>
        ///     List&lt;SHCourseRecord&gt; records = SHCourse.SelectByClass(SchoolYear,Semester,ClassIDs);
        ///     
        ///     foreach(SHCourseRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///    </code>
        /// </example>
        /// <remarks></remarks>
        public static new List<SHCourseRecord> SelectByClass(int? SchoolYear, int? Semester, IEnumerable<string> ClassIDs)
        {
            return K12.Data.Course.SelectByClass<SHCourseRecord>(SchoolYear, Semester, ClassIDs);
        }


        /// <summary>
        /// 根據學年度、學期及班級記錄物件取得課程列表。
        /// </summary>
        /// <param name="SchoolYear">學年度，傳入null代表取得所有學年度資料。</param>
        /// <param name="Semester">學期，傳入null代表取得所有學期資料。</param>
        /// <param name="ClassRec">班級記錄物件</param>
        /// <returns>List&lt;SHCourseRecord&gt;，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///   <code>
        ///     List&lt;SHCourseRecord&gt; records = SHCourse.SelectByClass(SchoolYear,Semester,ClassRec);
        ///     
        ///     foreach(SHCourseRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///    </code>
        /// </example>
        /// <remarks></remarks>
        public static List<SHCourseRecord> SelectByClass(int? SchoolYear, int? Semester, SHClassRecord ClassRec)
        {
            List<string> IDs = new List<string>();

            IDs.Add(ClassRec.ID);

            return K12.Data.Course.SelectByClass<SHCourseRecord>(SchoolYear, Semester, IDs);
        }

        /// <summary>
        /// 根據學年度、學期及班級記錄編號取得課程列表。
        /// </summary>
        /// <param name="SchoolYear">學年度，傳入null代表取得所有學年度資料。</param>
        /// <param name="Semester">學期，傳入null代表取得所有學期資料。</param>
        /// <param name="ClassID">班級記錄編號</param>
        /// <returns>List&lt;CourseRecord&gt;，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///   <code>
        ///     List&lt;SHCourseRecord&gt; records = SHCourse.SelectByClass(SchoolYear,Semester,ClassID);
        ///     
        ///     foreach(SHCourseRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///    </code>
        /// </example>
        /// <remarks></remarks>
        public static new List<SHCourseRecord> SelectByClass(int? SchoolYear, int? Semester, string ClassID)
        {
            List<string> IDs = new List<string>();

            IDs.Add(ClassID);

            return K12.Data.Course.SelectByClass<SHCourseRecord>(SchoolYear, Semester, IDs);
        }

        /// <summary>
        /// 根據學年度及學期取得課程列表。
        /// </summary>
        /// <param name="SchoolYear">學年度，傳入null代表取得所有學年度資料。</param>
        /// <param name="Semester">學期，傳入null代表取得所有學期資料。</param>
        /// <returns>List&lt;SHCourseRecord&gt;，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///   <code>
        ///     List&lt;SHCourseRecord&gt; records = SHCourse.SelectBySchoolYearAndSemester(SchoolYear,Semester);
        ///     
        ///     foreach(SHCourseRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///    </code>
        /// </example>
        /// <remarks></remarks>
        public static new List<SHCourseRecord> SelectBySchoolYearAndSemester(int? SchoolYear, int? Semester)
        {
            return SelectBySchoolYearAndSemester<SHCourseRecord>(SchoolYear, Semester);
        }

        /// <summary>
        /// 根據學年度、學期及課程名稱取得課程列表。
        /// </summary>
        /// <param name="SchoolYear">學年度，傳入null代表取得所有學年度資料。</param>
        /// <param name="Semester">學期，傳入null代表取得所有學期資料。</param>
        /// <param name="CourseName">課程名稱</param> 
        /// <returns>List&lt;SHCourseRecord&gt;，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>

        /// <example>
        ///     <code>
        ///       List&lt;SHCourseRecord&gt; records = SHCourse.SelectBySchoolYearAndSemester(SchoolYear,Semester,CourseName);
        ///     
        ///       foreach(SHCourseRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks></remarks>
        public static new List<SHCourseRecord> SelectBySchoolYearAndSemester(int? SchoolYear, int? Semester, string CourseName)
        {
            return SelectBySchoolYearAndSemester<SHCourseRecord>(SchoolYear, Semester, CourseName);
        }

        /// <summary>
        /// 根據單筆課程編號取得課程物件。
        /// </summary>
        /// <param name="CourseID">課程編號</param>
        /// <returns>SHCourseRecord，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHCourseRecord record = SHCourse.SelectByID(CourseID);
        ///     
        ///    if (record != null)
        ///        System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>若是CourseID不則在則會傳回null</remarks>
        public static new SHCourseRecord SelectByID(string CourseID)
        {
            return SelectByID<SHCourseRecord>(CourseID);
        }

        /// <summary>
        /// 根據多筆課程編號取得課程物件列表。
        /// </summary>
        /// <param name="CourseIDs">多筆課程編號</param>
        /// <returns>List&lt;SHCourseRecord&gt;，代表課程物件。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHCourseRecord&gt; records = SHCourse.SelectByIDs(CourseIDs);
        ///     
        ///     foreach(SHCourseRecord record in records)
        ///         Console.WrlteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆ID，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static new List<SHCourseRecord> SelectByIDs(IEnumerable<string> CourseIDs)
        {
            return SelectByIDs<SHCourseRecord>(CourseIDs);
        }

        /// <summary>
        /// 新增單筆課程記錄
        /// </summary>
        /// <param name="CourseRecord">課程記錄物件</param> 
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>

        /// <example>
        ///     <code>
        ///         SHCourseRecord record = new SHCourseRecord();
        ///         record.Name = (new System.Random()).NextDouble().ToString();
        ///         strng NewID = SHCourse.Insert(record);
        ///         SHCourseRecord actual = SHCourse.SelectByID(NewID);
        ///         System.Console.Writeln(actual.Name);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增一律傳回新增物件的編號。
        /// 2.新增必填欄位為課程名稱（Name）。
        /// </remarks>
        public static string Insert(SHCourseRecord CourseRecord)
        {
            return K12.Data.Course.Insert(CourseRecord);
        }

        /// <summary>
        /// 新增多筆課程記錄
        /// </summary>
        /// <param name="CourseRecords">課程記錄物件</param> 
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHClassRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHCourseRecord record = new SHCourseRecord();
        ///         record.Name = (new System.Random()).NextDouble().ToString();
        ///         List&lt;SHCourseRecord&gt; records = new List&lt;SHCourseRecord&gt;();
        ///         records.Add(record);
        ///         List&lt;string&gt; NewID = SHCourse.Insert(records)
        ///     </code>
        /// </example>
        public static List<string> Insert(IEnumerable<SHCourseRecord> CourseRecords)
        {
            List<K12.Data.CourseRecord> Courses = new List<K12.Data.CourseRecord>();

            foreach (SHCourseRecord CourseRecord in CourseRecords)
                Courses.Add(CourseRecord);

            return K12.Data.Course.Insert(Courses);
        }

        /// <summary>
        /// 更新單筆課程記錄
        /// </summary>
        /// <param name="CourseRecord">課程記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHCourseRecord record = SHCourse.SelectByID(CourseID);
        ///     record.Name = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHCourse.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHCourseRecord CourseRecord)
        {
            return K12.Data.Course.Update(CourseRecord);
        }

        /// <summary>
        /// 更新多筆課程記錄
        /// </summary>
        /// <param name="CourseRecords">課程記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="CourseRecordRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        ///     SHCourseRecord record = SHCourse.SelectByID(CourseID);
        ///     record.Name = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHCourseRecord&gt; records = new List&lt;SHCourseRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHCourse.Update(records);
        public static int Update(IEnumerable<SHCourseRecord> CourseRecords)
        {
            List<K12.Data.CourseRecord> Courses = new List<K12.Data.CourseRecord>();

            foreach (SHCourseRecord CourseRecord in CourseRecords)
                Courses.Add(CourseRecord);

            return K12.Data.Course.Update(Courses);
        }

        /// <summary>
        /// 刪除多筆課程記錄
        /// </summary>
        /// <param name="CourseRecords">多筆課程記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHCourseRecord&gt; records = SHCourse.SelectByIDs(CourseIDs);
        ///       int DeleteCount = SHCourse.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(IEnumerable<SHCourseRecord> CourseRecords)
        {
            List<K12.Data.CourseRecord> Courses = new List<K12.Data.CourseRecord>();

            foreach (SHCourseRecord CourseRecord in CourseRecords)
                Courses.Add(CourseRecord);

            return K12.Data.Course.Delete(Courses);
        }

        /// <summary>
        /// 刪除單筆課程記錄
        /// </summary>
        /// <param name="CourseRecord">課程記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHCourseRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       SHCourseRecord record = SHCourse.SelectByID(CourseID);
        ///       int DeleteCount = SHCourse.Delete(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHCourseRecord CourseRecord)
        {
            return K12.Data.Course.Delete(CourseRecord);
        }

        /// <summary>
        /// 刪除單筆課程記錄
        /// </summary>
        /// <param name="CourseID">課程記錄系統編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHCourse.Delete(CourseID);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(string CourseID)
        {
            return K12.Data.Course.Delete(CourseID);
        }

        /// <summary>
        /// 刪除多筆課程記錄
        /// </summary>
        /// <param name="CourseIDs">多筆課程記錄系統編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHCourse.Delete(CourseIDs);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>        
        static public new int Delete(IEnumerable<string> CourseIDs)
        {
            return K12.Data.Course.Delete(CourseIDs);
        }
    }
}