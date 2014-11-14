using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SHSchool.Data
{
    /// <summary>
    /// 排名資訊
    /// </summary>
    public class SHRankingInfo
    {
        /// <summary>
        /// 分數
        /// </summary>
        public decimal? Score { get; set; }

        /// <summary>
        /// 成績人數
        /// </summary>
        public int ScoreNumber { get; set; }

        /// <summary>
        /// 排名
        /// </summary>
        public int Ranking { get; set; }

        /// <summary>
        /// 排序名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="element"></param>
        public SHRankingInfo(XmlElement element,string Type)
        {
            Load(element,Type);
        }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="element"></param>
        public virtual void Load(XmlElement element,string Type)
        {
            //<Item 成績="87" 成績人數="50" 排名="12" 科目="公民" />
            Score = K12.Data.Decimal.ParseAllowNull(element.GetAttribute("成績"));
            ScoreNumber = K12.Data.Int.Parse(element.GetAttribute("成績人數"));
            Ranking = K12.Data.Int.Parse(element.GetAttribute("排名"));
            Name = element.GetAttribute(Type);
        }
    }
}