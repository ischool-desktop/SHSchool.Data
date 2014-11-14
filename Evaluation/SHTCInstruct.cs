using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 教師教授課程類別，提供方法用來取得、新增、修改及刪除教師教授課程資訊
    /// </summary>
    public class SHTCInstruct : K12.Data.TCInstruct
    {
        /// <summary>
        /// 取得所有教師教授課程列表。
        /// </summary>
        /// <returns>List&lt;SHTCInstructRecord&gt;，代表多筆教師教授課程記錄物件。</returns>
        /// <seealso cref="SHTCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHTCInstructRecord&gt; records = SHTCInstruct.SelectAll();
        /// </example>
        [SelectMethod("SHSchool.SHTCInstruct.SelectAll", "成績.教師授課")]
        public new static List<SHTCInstructRecord> SelectAll()
        {
            return K12.Data.TCInstruct.SelectAll<SHTCInstructRecord>();
        }

        /// <summary>
        /// 根據多筆教師教授課程編號取得教師教授課程列表。
        /// </summary>
        /// <param name="TCInstructIDs">多筆教師教授課程編號</param>
        /// <returns>List&lt;SHTCInstructRecord&gt;，代表多筆教師教授課程記錄物件。</returns>
        /// <seealso cref="SHTCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHTCInstructRecord&gt; records = SHTCInstruct.SelectByIDs(TCInstructIDs);
        /// </example>
        public new static List<SHTCInstructRecord> SelectByIDs(IEnumerable<string> TCInstructIDs)
        {
            return SelectByIDs<SHTCInstructRecord>(TCInstructIDs);
        }

        /// <summary>
        /// 根據多筆教師教授課程編號及課程編號取得教師教授課程列表。
        /// </summary>
        /// <param name="CourseIDs">多筆課程編號</param>
        /// <param name="TeacherIDs">多筆教師編號</param>
        /// <returns>List&lt;SHTCInstructRecord&gt;，代表多筆教師教授課程記錄物件。</returns>
        /// <seealso cref="SHTCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         List&lt;SHTCInstructRecord&gt; records = SHTCInstruct.SelectByTeacherIDAndCourseID(TeacherIDs,CourseIDs);
        ///     </code>
        /// </example>
        public new static List<SHTCInstructRecord> SelectByTeacherIDAndCourseID(IEnumerable<string> TeacherIDs, IEnumerable<string> CourseIDs)
        {
            return SelectByTeacherIDAndCourseIDs<SHTCInstructRecord>(TeacherIDs, CourseIDs);
        }

        /// <summary>
        /// 新增單筆教師教授課程記錄
        /// </summary>
        /// <param name="TCInstructRecord">教師教授課程記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHTCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        /// </example>
        public static string Insert(SHTCInstructRecord TCInstructRecord)
        {
            return K12.Data.TCInstruct.Insert(TCInstructRecord);
        }

        /// <summary>
        /// 新增多筆教師教授課程記錄
        /// </summary>
        /// <param name="TCInstructRecords">多筆教師教授課程記錄物件</param> 
        /// <returns>List&lt;string&gt，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHTCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static List<string> Insert(IEnumerable<SHTCInstructRecord> TCInstructRecords)
        {
            return K12.Data.TCInstruct.Insert(K12.Data.Utility.Utility.GetBaseList<TCInstructRecord,SHTCInstructRecord>(TCInstructRecords));
        }

        /// <summary>
        /// 更新單筆教師教授課程記錄
        /// </summary>
        /// <param name="TCInstructRecord">教師教授課程記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHTCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(SHTCInstructRecord TCInstructRecord)
        {
            return K12.Data.TCInstruct.Update(TCInstructRecord);
        }

        /// <summary>
        /// 更新多筆教師教授課程記錄
        /// </summary>
        /// <param name="TCInstructRecords">多筆教師教授課程記錄</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHTCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(IEnumerable<SHTCInstructRecord> TCInstructRecords)
        {
            return K12.Data.TCInstruct.Update(K12.Data.Utility.Utility.GetBaseList<TCInstructRecord, SHTCInstructRecord>(TCInstructRecords));
        }

        /// <summary>
        /// 刪除單筆教師教授課程記錄
        /// </summary>
        /// <param name="TCInstructRecord">教師教授課程記錄物件</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="TCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHTCInstructRecord TCInstructRecord)
        {
            return K12.Data.TCInstruct.Delete(TCInstructRecord);
        }

        /// <summary>
        /// 刪除單筆教師教授課程記錄
        /// </summary>
        /// <param name="TCInstructID">教師教授課程編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(string TCInstructID)
        {
            return K12.Data.TCInstruct.Delete(TCInstructID);
        }

        /// <summary>
        /// 刪除多筆教師教授課程記錄
        /// </summary>
        /// <param name="TCInstructRecords">多筆教師教授課程記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHTCInstructRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHTCInstructRecord> TCInstructRecords)
        {
            return K12.Data.TCInstruct.Delete(K12.Data.Utility.Utility.GetBaseList<TCInstructRecord, SHTCInstructRecord>(TCInstructRecords));
        }

        /// <summary>
        /// 刪除多筆教師教授課程記錄
        /// </summary>
        /// <param name="TCInstructIDs">多筆教師教授課程編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<string> TCInstructIDs)
        {
            return K12.Data.TCInstruct.Delete(TCInstructIDs);
        }
    }
}