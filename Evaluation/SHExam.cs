using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 試別項目類別，提供方法用來取得、新增、修改及刪除試別項目資訊
    /// </summary>
    public class SHExam : K12.Data.Exam
    {
        /// <summary>
        /// 取得所有考試項目列表。
        /// </summary>
        /// <returns>List&lt;SHExamRecord&gt;，代表多筆考試項目記錄物件。</returns>
        /// <seealso cref="SHExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHExamRecord&gt; records = SHExam.SelectAll();
        /// </example>
        [SelectMethod("SHSchool.SHExam.SelectAll", "成績.試別")]
        public static new List<SHExamRecord> SelectAll()
        {
            return SelectAll<SHExamRecord>();
        }

        /// <summary>
        /// 根據單筆考試項目編號取得考試項目。
        /// </summary>
        /// <param name="ExamID">單筆考試項目編號</param>
        /// <returns>SHExamRecord，代表單筆考試項目記錄物件。</returns>
        /// <seealso cref="SHExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     SHExamRecord record = SHExam.SelectByID(ExamID);
        /// </example>
        public static new SHExamRecord SelectByID(string ExamID)
        {
            return SelectByID<SHExamRecord>(ExamID);
        }

        /// <summary>
        /// 根據多筆考試項目編號取得考試項目列表。
        /// </summary>
        /// <param name="ExamIDs">多筆考試項目編號</param>
        /// <returns>List&lt;SHExamRecord&gt;，代表多筆考試項目記錄物件。</returns>
        /// <seealso cref="SHExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHExamRecord&gt; records = SHExam.SelectByIDs(ExamIDs);
        /// </example>
        public static new List<SHExamRecord> SelectByIDs(IEnumerable<string> ExamIDs)
        {
            return SelectByIDs<SHExamRecord>(ExamIDs);
        }

        /// <summary>
        /// 新增單筆考試項目記錄
        /// </summary>
        /// <param name="ExamRecord">考試項目記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        public static new string Insert(SHExamRecord ExamRecord)
        {
            return K12.Data.Exam.Insert(ExamRecord);
        }

        /// <summary>
        /// 新增多筆考試項目記錄
        /// </summary>
        /// <param name="ExamRecords">多筆考試項目記錄物件</param> 
        /// <returns>List&lt;string&gt，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static new List<string> Insert(IEnumerable<SHExamRecord> ExamRecords)
        {
            return K12.Data.Exam.Insert(K12.Data.Utility.Utility.GetBaseList<K12.Data.ExamRecord, SHExamRecord>(ExamRecords));
        }

        /// <summary>
        /// 更新單筆考試項目記錄
        /// </summary>
        /// <param name="ExamRecord">考試項目記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static new int Update(SHExamRecord ExamRecord)
        {
            return K12.Data.Exam.Update(ExamRecord);
        }

        /// <summary>
        /// 更新多筆考試項目記錄
        /// </summary>
        /// <param name="ExamRecords">多筆考試項目記錄</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(IEnumerable<SHExamRecord> ExamRecords)
        {
            return K12.Data.Exam.Update(K12.Data.Utility.Utility.GetBaseList<K12.Data.ExamRecord, SHExamRecord>(ExamRecords));
        }

        /// <summary>
        /// 刪除單筆考試項目記錄
        /// </summary>
        /// <param name="ExamRecord">考試項目記錄物件</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHExamRecord ExamRecord)
        {
            return K12.Data.Exam.Delete(ExamRecord);
        }

        /// <summary>
        /// 刪除單筆考試項目記錄
        /// </summary>
        /// <param name="ExamRecordID">考試項目記錄編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(string ExamID)
        {
            return K12.Data.Exam.Delete(ExamID);
        }

        /// <summary>
        /// 刪除多筆考試項目記錄
        /// </summary>
        /// <param name="ExamRecords">多筆考試項目記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="ExamRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHExamRecord> ExamRecords)
        {
            return K12.Data.Exam.Delete(K12.Data.Utility.Utility.GetBaseList<K12.Data.ExamRecord, SHExamRecord>(ExamRecords));
        }

        /// <summary>
        /// 刪除多筆考試項目記錄
        /// </summary>
        /// <param name="ExamRecordIDs">多筆考試項目記錄編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public new int Delete(IEnumerable<string> ExamIDs)
        {
            return K12.Data.Exam.Delete(ExamIDs);
        }
    }
}