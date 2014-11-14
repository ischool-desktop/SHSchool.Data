using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SHSchool.Data
{
    /// <summary>
    /// 德行成績計算規則
    /// </summary>
    public class SHMoralScoreCalcRuleRecord
    {
        /// <summary>
        /// 內容，必填
        /// </summary>
        public XmlElement Content { get; set; }

        /// <summary>
        /// 預設建構式
        /// </summary>
        public SHMoralScoreCalcRuleRecord()
        {
 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content">內容</param>
        public SHMoralScoreCalcRuleRecord(XmlElement Content)
        {
            this.Content = Content;
        }

        /// <summary>
        /// 從XML載入設定值
        /// <![CDATA[
        /// <MoralConductScoreCalcRule>
        ///        <PeriodAbsenceCalcRule NoAbsenceReward="3">
        ///            <Rule Absence="曠課" Aggregated="2" Noabsence="" Period="早修" Subtract="1" />
        ///            <Rule Absence="事假" Aggregated="40" Noabsence="" Period="早修" Subtract="1" />
        ///        </PeriodAbsenceCalcRule>
        ///        <BasicScore DecimalType="四捨五入" Decimals="1" NormalScore="80" Over100="以實際分數計" UltimateAdmonitionScore="60" />
        ///        <TeacherAppraise Range="7" />
        ///        <RewardCalcRule AwardA1="7" AwardB1="2" AwardB3="3" AwardC1="1" CalcCancel="False" FaultA1="7" FaultB1="2" FaultB3="3" FaultC1="1" />
        ///    </MoralConductScoreCalcRule>
        /// ]]>
        /// </summary>
        /// <param name="data"></param>
        public virtual void Load(XmlElement data)
        {
            this.Content = data;
        }

    }
}