using System;
using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 成績計算規則類別，適用於學生及班級，提供方法用來取得、新增、修改及刪除成績計算規則資訊
    /// </summary>
    public class SHScoreCalcRule : K12.Data.ScoreCalcRule
    {
        /// <summary>
        /// 取得所有成績計算規則列表。
        /// </summary>
        /// <returns>List&lt;SHScoreCalcRuleRecord&gt;，代表多筆成績計算規則記錄物件。</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHScoreCalcRuleRecord&gt; records = SHScoreCalcRule.SelectAll();
        /// </example>
        [SelectMethod("SHSchool.SHScoreCalcRule.SelectAll", "成績.成績計算規則")]
        public new static List<SHScoreCalcRuleRecord> SelectAll()
        {
            return K12.Data.ScoreCalcRule.SelectAll<SHScoreCalcRuleRecord>();
        }

        /// <summary>
        /// 依學生系統編號列表取得成績計算規則
        /// </summary>
        /// <param name="StudentIDs">學生系統編號列表</param>
        /// <returns></returns>
        public new static Dictionary<string, SHScoreCalcRuleRecord> SelectByStudentIDs(IEnumerable<string> StudentIDs)
        {
            return SelectByStudentIDs<SHScoreCalcRuleRecord>(StudentIDs);
        }

        /// <summary>
        /// 根據單筆成績計算規則編號取得成績計算規則物件。
        /// </summary>
        /// <param name="ScoreCalcRuleID">成績計算規則編號</param>
        /// <returns>SHScoreCalcRuleRecord，成績計算規則物件</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        public static SHScoreCalcRuleRecord SelectByID(string ScoreCalcRuleID)
        {
            return K12.Data.ScoreCalcRule.SelectByID<SHScoreCalcRuleRecord>(ScoreCalcRuleID);
        }

        /// <summary>
        /// 根據多筆成績計算規則編號取得成績計算規則列表。
        /// </summary>
        /// <param name="ScoreCalcRuleIDs">多筆成績計算規則編號</param>
        /// <returns>List&lt;SHScoreCalcRuleRecord&gt;，代表多筆成績計算規則記錄物件。</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     List&lt;SHScoreCalcRuleRecord&gt; records = SHScoreCalcRule.SelectByIDs(ScoreCalcRuleIDs);
        /// </example>
        public static List<SHScoreCalcRuleRecord> SelectByIDs(IEnumerable<string> ScoreCalcRuleIDs)
        {
            return K12.Data.ScoreCalcRule.SelectByIDs<SHScoreCalcRuleRecord>(ScoreCalcRuleIDs);
        }

        /// <summary>
        /// 新增單筆成績計算規則記錄
        /// </summary>
        /// <param name="ScoreCalcRuleRecord">成績計算規則記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        public static string Insert(SHScoreCalcRuleRecord ScoreCalcRuleRecord)
        {
            return K12.Data.ScoreCalcRule.Insert(ScoreCalcRuleRecord);
        }

        /// <summary>
        /// 新增多筆成績計算規則記錄
        /// </summary>
        /// <param name="ScoreCalcRuleRecords">多筆成績計算規則記錄物件</param> 
        /// <returns>List&lt;string&gt，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static List<string> Insert(IEnumerable<SHScoreCalcRuleRecord> ScoreCalcRuleRecords)
        {
            return K12.Data.ScoreCalcRule.Insert(K12.Data.Utility.Utility.GetBaseList<ScoreCalcRuleRecord, SHScoreCalcRuleRecord>(ScoreCalcRuleRecords));
        }

        /// <summary>
        /// 更新單筆成績計算規則記錄
        /// </summary>
        /// <param name="ScoreCalcRuleRecord">成績計算規則記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(SHScoreCalcRuleRecord ScoreCalcRuleRecord)
        {
            return K12.Data.ScoreCalcRule.Update(ScoreCalcRuleRecord);
        }

        /// <summary>
        /// 更新多筆成績計算規則記錄
        /// </summary>
        /// <param name="ScoreCalcRuleRecords">多筆成績計算規則記錄</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        public static int Update(IEnumerable<SHScoreCalcRuleRecord> ScoreCalcRuleRecords)
        {
            return K12.Data.ScoreCalcRule.Update(K12.Data.Utility.Utility.GetBaseList<ScoreCalcRuleRecord, SHScoreCalcRuleRecord>(ScoreCalcRuleRecords));
        }

        /// <summary>
        /// 刪除單筆成績計算規則記錄
        /// </summary>
        /// <param name="ScoreCalcRuleRecord">成績計算規則記錄物件</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(SHScoreCalcRuleRecord ScoreCalcRuleRecord)
        {
            return K12.Data.ScoreCalcRule.Delete(ScoreCalcRuleRecord);
        }


        /// <summary>
        /// 刪除單筆成績計算規則記錄
        /// </summary>
        /// <param name="ScoreCalcRuleID">成績計算規則編號</param> 
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(string ScoreCalcRuleID)
        {
            return K12.Data.ScoreCalcRule.Delete(ScoreCalcRuleID);
        }

        /// <summary>
        /// 刪除多筆成績計算規則記錄
        /// </summary>
        /// <param name="ScoreCalcRuleRecords">多筆成績計算規則記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHScoreCalcRuleRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<SHScoreCalcRuleRecord> ScoreCalcRuleRecords)
        {
            return K12.Data.ScoreCalcRule.Delete(K12.Data.Utility.Utility.GetBaseList<ScoreCalcRuleRecord, SHScoreCalcRuleRecord>(ScoreCalcRuleRecords));
        }

        /// <summary>
        /// 刪除多筆成績計算規則記錄
        /// </summary>
        /// <param name="ScoreCalcRuleIDs">多筆成績計算規則編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     
        /// </example>
        static public int Delete(IEnumerable<string> ScoreCalcRuleIDs)
        {
            return K12.Data.ScoreCalcRule.Delete(ScoreCalcRuleIDs);
        }
    }
}