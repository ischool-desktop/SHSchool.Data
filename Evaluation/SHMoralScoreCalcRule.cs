using System.Collections.Generic;
using System.Xml;
using FISCA.DSAUtil;
using K12.Data.Utility;

namespace SHSchool.Data
{
    /// <summary>
    /// 德行成績計算規則類別，提供方法用來取得及修改德行成績計算規則資訊
    /// </summary>
    public class SHMoralScoreCalcRule
    {
        private const string SELECT_SERVICENAME = "SmartSchool.ScoreCalcRule.GetMoralConductScoreCalcRule";
        private const string UPDATE_SERVICENAME = "SmartSchool.ScoreCalcRule.SetMoralConductScoreCalcRule";

        /// <summary>
        /// 取得德行成績計算規則記錄物件，一個學校只會有一組設定。
        /// </summary>
        /// <returns></returns>
        public static SHMoralScoreCalcRuleRecord Select()
        {
            return Select<SHMoralScoreCalcRuleRecord>();
        }

        /// <summary>
        /// 取得德行成績計算規則記錄物件，一個學校只會有一組設定。
        /// </summary>
        /// <typeparam name="T">德行成績計算規則記錄型別</typeparam>
        /// <returns></returns>
        protected static T Select<T>() where T:SHMoralScoreCalcRuleRecord ,new()
        {
            DSXmlHelper request = new DSXmlHelper("GetMoralConductScoreCalcRuleRequest");
            List<T> Types = new List<T>();

            request.AddElement(".", "Field", "<All/>", true);

            T Type = new T();

            XmlElement Element = DSAServices.CallService(SELECT_SERVICENAME, new DSRequest(request)).GetContent().GetElement("MoralConductScoreCalcRule");

            Type.Load(Element);

            return Type;
        }

        /// <summary>
        /// 更新德行成績計算規則記錄物件
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static int Update(SHMoralScoreCalcRuleRecord record)
        {
            return Update<SHMoralScoreCalcRuleRecord>(record);
        }

        /// <summary>
        /// 更新德行成績計算規則記錄物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="record"></param>
        /// <returns></returns>
        protected static int Update<T>(T record) where T:SHMoralScoreCalcRuleRecord ,new()
        {
            DSXmlHelper request = new DSXmlHelper("SetMoralConductScoreCalcRuleRequest");

            request.AddElement(".","MoralConductScoreCalcRule");
            request.AddElement("MoralConductScoreCalcRule","Content");
            request.AddElement("MoralConductScoreCalcRule/Content",record.Content);

            int result = int.Parse(DSAServices.CallService(UPDATE_SERVICENAME, new DSRequest(request.BaseElement)).GetContent().GetElement("ExecuteCount").InnerText);

            return result;
        }
    }
}