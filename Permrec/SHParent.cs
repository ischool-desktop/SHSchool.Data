using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生家長及監護人類別，提供方法用來取得及修改學生家長及監護人資訊
    /// </summary>
    public class SHParent : K12.Data.Parent
    {
        /// <summary>
        /// 取得所有學生家長及監護人記錄物件列表。
        /// </summary>
        /// <returns>List&lt;SHParentRecord&gt;，代表多筆學生家長及監護人記錄物件。</returns>
        /// <seealso cref="SHParentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHParentRecord&gt; records = SHParent.SelectAll();
        ///     
        ///     foreach(SHParentRecord record in records)
        ///         Console.WrlteLine(record.Mother.Name);
        ///     </code>
        /// </example>
        [SelectMethod("SHSchool.SHParent.SelectAll", "學籍.學生家長及監護人")]
        public new static List<SHParentRecord> SelectAll()
        {
            return SelectAll<SHParentRecord>();
        }

        /// <summary>
        /// 根據單筆學生記錄物件取得學生家長及監護人記錄物件。
        /// </summary>
        /// <param name="Student">學生記錄物件</param>
        /// <returns>SHParentRecord，代表學生家長及監人記錄物件。</returns>
        /// <seealso cref="SHStudentRecord"/>
        /// <seealso cref="SHParentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     JHPaerntRecord record = SHParent.SelectByStudent(Student);
        ///     
        ///    if (record != null)
        ///        System.Console.WriteLine(record.Mother.Name);
        ///     </code>
        /// </example>
        /// <remarks>若是Student不則在則會傳回null</remarks>
        public static SHParentRecord SelectByStudent(SHStudentRecord Student)
        {
            return K12.Data.Parent.SelectByStudent<SHParentRecord>(Student);
        }

        /// <summary>
        /// 根據單筆學生記錄編號取得學生家長及監護人記錄物件。
        /// </summary>
        /// <param name="StudentID">學生記錄編號</param>
        /// <returns>SHParentRecord，代表學生家長及監護人記錄物件。</returns>
        /// <seealso cref="SHParentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHParentRecord record = SHParent.SelectByStudent(StudentID);
        ///     
        ///     if (record != null)
        ///        System.Console.WriteLine(record.Mother.Name);
        ///     </code>
        /// </example>
        /// <remarks>若是StudentID不則在則會傳回null</remarks>
        public static new SHParentRecord SelectByStudentID(string StudentID)
        {
            return K12.Data.Parent.SelectByStudentID<SHParentRecord>(StudentID);
        }

        /// <summary>
        /// 根據多筆學生記錄物件取得學生家長及監護人記錄物件列表。
        /// </summary>
        /// <param name="Students">多筆學生記錄物件</param>
        /// <returns>List&lt;SHParentRecord&gt;，代表多筆學生家長及監護人記錄物件。</returns>
        /// <seealso cref="SHParentRecord"/>
        /// <seealso cref="SHStudentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHParentRecord&gt; records = SHParent.SelectByStudents(Students);
        ///     
        ///     foreach(SHParentRecord record in records)
        ///         Console.WrlteLine(record.Mother.Name);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆學生，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static List<SHParentRecord> SelectByStudents(IEnumerable<SHStudentRecord> Students)
        {
            return K12.Data.Parent.SelectByStudents<SHParentRecord>(K12.Data.Utility.Utility.GetBaseList<StudentRecord, SHStudentRecord>(Students));
        }

        /// <summary>
        /// 根據多筆學生記錄編號取得學生家長及監護人記錄物件列表。
        /// </summary>
        /// <param name="StudentIDs">多筆學生記錄編號</param>
        /// <returns>List&lt;SHParentRecord&gt;，代表多筆學生家長及監護人記錄物件。</returns>
        /// <seealso cref="SHParentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHParentRecord&gt; records = SHParent.SelectByStudentIDs(StudentIDs);
        ///     
        ///     foreach(SHParentRecord record in records)
        ///         Console.WrlteLine(record.Mother.Name);
        ///     </code>
        /// </example>
        /// <remarks>可能情況若是傳5筆學生，但是其中1筆沒有資料，就只會回傳4筆資料</remarks>
        public static new List<SHParentRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return K12.Data.Parent.SelectByStudentIDs<SHParentRecord>(StudentIDs);
        }

        /// <summary>
        /// 更新單筆家長及監護人記錄
        /// </summary>
        /// <param name="ParentRecord">家長及監護人記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHParentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHParentRecord record = SHParent.SelectByStudentID(StudentID);
        ///     record.Mother.Name = (new System.Random()).NextDouble().ToString();
        ///     int UpdateCount = SHParent.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHParentRecord ParentRecord)
        {
            return K12.Data.Parent.Update(ParentRecord);
        }

        /// <summary>
        /// 更新多筆家長及監護人記錄
        /// </summary>
        /// <param name="ParentRecords">多筆家長及監護人記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHParentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHParentRecord record = SHParent.SelectByStudentID(StudentID);
        ///     record.Mother.Name = (new System.Random()).NextDouble().ToString();
        ///     List&lt;SHParentRecord&gt; records = new List&lt;SHParentRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHParent.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHParentRecord> ParentRecords)
        {
            return K12.Data.Parent.Update(K12.Data.Utility.Utility.GetBaseList<ParentRecord, SHParentRecord>(ParentRecords));            
        }
    }
}