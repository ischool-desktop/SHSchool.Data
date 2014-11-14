using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生類別，提供方法用來取得、新增、修改及刪除學生資訊
    /// </summary>
    public class SHStudent : K12.Data.Student
    {
        /// <summary>
        /// 取得所有學生記錄列表。
        /// </summary>
        /// <returns>List&lt;SHStudentRecord&gt;，代表多筆學生記錄物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHStudentRecord&gt; records = SHStudent.SelectAll();
        ///     
        ///     foreach(SHStudentRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks>
        /// 請先using K12.Data;
        /// </remarks>
        [SelectMethod("SHSchool.SHStudent.SelectAll", "學籍.學生")]
        public static new List<SHStudentRecord> SelectAll()
        {
            return K12.Data.Student.SelectAll<SHStudentRecord>();
        }

        /// <summary>
        /// 根據班級記錄物件取得學生記錄編號列表。
        /// </summary>
        /// <param name="ClassRec">班級記錄物件</param>
        /// <returns>List&lt;SHStudentRecord&gt;，代表多筆學生記錄物件。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHStudentRecord&gt; records = SHStudent.SelectByClass(ClassRec);
        ///     
        ///     foreach(SHStudentRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks>
        /// 請先using K12.Data;
        /// </remarks>
        public static List<SHStudentRecord> SelectByClass(SHClassRecord ClassRec)
        {
            return SelectByClassID<SHStudentRecord>(ClassRec.ID);
        }

        /// <summary>
        /// 根據班級編號取得學生記錄編號列表。
        /// </summary>
        /// <param name="ClassID">班級編號</param>
        /// <returns>List&lt;SHStudentRecord&gt;，代表多筆學生記錄物件。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHStudentRecord&gt; records = SHStudent.SelectByClassID(ClassID);
        ///     
        ///     foreach(SHStudentRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks>
        /// 請先using K12.Data;
        /// </remarks>
        public static new List<SHStudentRecord> SelectByClassID(string ClassID)
        {
            return K12.Data.Student.SelectByClassID<SHStudentRecord>(ClassID);
        }

        /// <summary>
        /// 根據多筆班級記錄物件取得學生記錄編號列表。
        /// </summary>
        /// <param name="ClassRecs">多筆班級記錄物件</param>
        /// <returns>List&lt;SHStudentRecord&gt;，代表多筆學生記錄物件。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHStudentRecord&gt; records = SHStudent.SelectByClasses(ClassRecs);
        ///     
        ///     foreach(SHStudentRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks>
        /// 請先using K12.Data;
        /// </remarks>
        public static List<SHStudentRecord> SelectByClasses(IEnumerable<SHClassRecord> ClassRecs)
        {
            List<string> IDs = new List<string>();

            foreach (SHClassRecord ClassRec in ClassRecs)
                IDs.Add(ClassRec.ID);

            return SelectByClassIDs<SHStudentRecord>(IDs);
        }

        /// <summary>
        /// 根據多筆班級編號取得學生記錄編號列表。
        /// </summary>
        /// <param name="ClassIDs">多筆班級編號</param>
        /// <returns>List&lt;SHStudentRecord&gt;，代表多筆學生記錄物件。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHStudentRecord&gt; records = SHStudent.SelectByClassIDs(ClassIDs);
        ///     
        ///     foreach(SHStudentRecord record in records)
        ///         System.Console.Writeln(record.Name); 
        ///     </code>
        /// </example>
        /// <remarks>
        /// 請先using K12.Data;
        /// </remarks>
        public static List<SHStudentRecord> SelectByClassIDs(IEnumerable<string> ClassIDs)
        {
            return SelectByClassIDs<SHStudentRecord>(ClassIDs);
        }

        /// <summary>
        /// 根據單筆學生編號取得學生記錄。
        /// </summary>
        /// <param name="StudentID">學生編號</param>
        /// <returns>SHStudentRecord，代表學生記錄物件</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHStudentRecord record = SHStudent.SelectByID(StudentID);
        ///     
        ///     if (record != null)
        ///         System.Console.WriteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>若是StudentID不則在則會傳回null</remarks>
        public static new SHStudentRecord SelectByID(string StudentID)
        {
            return K12.Data.Student.SelectByID<SHStudentRecord>(StudentID);
        }

        /// <summary>
        /// 根據多筆學生編號取得學生記錄列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生編號</param>
        /// <returns>List&lt;SHStudentRecord&gt;，代表多筆學生記錄物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHStudentRecord&gt; records = SHStudent.SelectByIDs(CourseIDs);
        ///     
        ///     foreach(SHStudentRecord record in records)
        ///         Console.WrlteLine(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆ID，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static new List<SHStudentRecord> SelectByIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.Student.SelectByIDs<SHStudentRecord>(StudentIDs);
        }

        /// <summary>
        /// 新增單筆學生記錄
        /// </summary>
        /// <param name="StudentRecord">學生記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHStudentRecord newrecord = new SHStudentRecord();
        ///         newrecord.Name = (new System.Random()).NextDouble().ToString();
        ///         newrecord.Gender = "男";
        ///         strng NewID = SHStudent.Insert(newrecord)
        ///         StudentRecord record = SHStudent.SelectByID(NewID);
        ///         System.Console.Writeln(record.Name);
        ///     </code>
        /// </example>
        /// <remarks>
        /// 1.新增一律傳回新增物件的編號。
        /// 2.新增必填欄位為課程名稱（Name）。
        /// </remarks>
        public static string Insert(SHStudentRecord StudentRecord)
        {
            return K12.Data.Student.Insert(StudentRecord);
        }

        /// <summary>
        /// 新增多筆學生記錄
        /// </summary>
        /// <param name="StudentRecords">多筆班級記錄物件</param>
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHStudentRecord record = new SHStudentRecord();
        ///         record.Name = (new System.Random()).NextDouble().ToString();
        ///         List&lt;SHStudentRecord&gt; records = new List&lt;SHStudentRecord&gt;();
        ///         records.Add(record);
        ///         List&lt;string&gt; NewID = SHStudent.Insert(records)
        ///     </code>
        /// </example>
        public static List<string> Insert(IEnumerable<SHStudentRecord> StudentRecords)
        {
            List<K12.Data.StudentRecord> Students = new List<K12.Data.StudentRecord>();

            foreach (SHStudentRecord StudentRecord in StudentRecords)
                Students.Add(StudentRecord);

            return K12.Data.Student.Insert(Students);
        }

        /// <summary>
        /// 更新單筆學生記錄
        /// </summary>
        /// <param name="StudentRecord">學生記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHStudentRecord record = SHStudent.SelectByID(StudentID);
        ///     record.Name = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHStudent.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHStudentRecord StudentRecord)
        {
            return K12.Data.Student.Update(StudentRecord);
        }

        /// <summary>
        /// 更新多筆學生記錄
        /// </summary>
        /// <param name="StudentRecords">多筆學生記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHStudentRecord record = SHStudent.SelectByID(StudentID);
        ///     record.Name = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHStudentRecord&gt; records = new List&lt;SHStudentRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHStudent.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHStudentRecord> StudentRecords)
        {
            List<K12.Data.StudentRecord> Students = new List<K12.Data.StudentRecord>();

            foreach (SHStudentRecord StudentRecord in StudentRecords)
                Students.Add(StudentRecord);

            return K12.Data.Student.Update(Students);
        }

        /// <summary>
        /// 刪除多筆學生記錄
        /// </summary>
        /// <param name="StudentRecords">多筆學生記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHStudentRecord&gt; records = SHStudent.SelectByIDs(StudentIDs);
        ///       int DeleteCount = Student.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(IEnumerable<SHStudentRecord> StudentRecords)
        {
            List<K12.Data.StudentRecord> Students = new List<K12.Data.StudentRecord>();

            foreach (SHStudentRecord StudentRecord in StudentRecords)
                Students.Add(StudentRecord);

            return K12.Data.Student.Delete(Students);
        }

        /// <summary>
        /// 刪除單筆學生記錄
        /// </summary>
        /// <param name="StudentRecord">學生記錄物件</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       SHStudentRecord record = SHStudent.SelectByID(StudentID);
        ///       int DeleteCount = SHStudent.Delete(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHStudentRecord StudentRecord)
        {
            return K12.Data.Student.Delete(StudentRecord);
        }

        /// <summary>
        /// 刪除單筆學生記錄
        /// </summary>
        /// <param name="StudentID">學生記錄編號</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHStudent.Delete(StudentID);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(string StudentID)
        {
            return K12.Data.Student.Delete(StudentID);
        }

        /// <summary>
        /// 刪除多筆學生標籤記錄
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHStudent.Delete(StudentIDs);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public new int Delete(IEnumerable<string> StudentIDs)
        {
            return K12.Data.Student.Delete(StudentIDs);
        }
    }
}
