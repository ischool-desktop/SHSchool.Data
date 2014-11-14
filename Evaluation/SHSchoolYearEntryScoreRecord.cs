﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using System.Xml;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生學年分項成績資訊
    /// </summary>
    public class SHSchoolYearEntryScoreRecord
    {
        /// <summary>
        /// 系統編號
        /// </summary>
        [Field(Caption = "編號", EntityName = "SHSchoolYearEntryScore", EntityCaption = "學年分項成績", IsEntityPrimaryKey = true)]
        public string ID { get; set; }

        /// <summary>
        /// 所屬學生編號，必填
        /// </summary>
        [Field(Caption = "學生編號", EntityName = "Student", EntityCaption = "學生", IsEntityPrimaryKey = true)]
        public string RefStudentID { get; set; }

        /// <summary>
        /// 學年度，必填
        /// </summary>
        [Field(Caption = "學年度", EntityName = "SHSchoolYearEntryScore", EntityCaption = "學年分項成績")]
        public int SchoolYear { get; set; }

        /// <summary>
        /// 年級
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("學期成績上的成績年級已不再使用。")]
        [Field(Caption = "年級", EntityName = "SHSchoolYearEntryScore", EntityCaption = "學年分項成績")]
        public int GradeYear { get; set; }

        /// <summary>
        /// 分項群組
        /// </summary>
        [Field(Caption = "分項群組", EntityName = "SHSchoolYearEntryScore", EntityCaption = "學年分項成績")]
        public string Group { get; set; }

        /// <summary>
        /// 根據分項群組取得對應的分項成績，若是分項群組為『學習』，則取得『學業』分項成績；若是分項群組為『行為』，則取得『德行』分項成績。
        /// </summary>
        [Field(Caption = "分項群組主要成績", EntityName = "SHSchoolYearEntryScore", EntityCaption = "學期分項成績", Remark = "根據分項群組取得對應的分項成績，若是分項群組為『學習』，則取得『學業』分項成績；若是分項群組為『行為』，則取得『德行』分項成績。")]
        public decimal GroupMainScore
        {
            get
            {
                if (Group.Equals("學習"))
                {
                    if (Scores.ContainsKey("學業"))
                        return Scores["學業"];
                }
                else if (Group.Equals("行為"))
                {
                    if (Scores.ContainsKey("德行"))
                        return Scores["德行"];
                }

                return 0;
            }
        }

        /// <summary>
        /// 根據分項群組取得對應的分項班級排名。
        /// 若是分項群組為『學習』，則取得『學業』分項班級排名。
        /// 若是分項群組為『行為』，則取得『德行』分項班級排名。
        /// </summary>
        [Field(Caption = "分項群組主要班級排名", EntityName = "SHSchoolYearEntryScore", EntityCaption = "學期分項成績", Remark = "根據分項群組取得對應的分項班級排名。若是分項群組為『學習』，則取得『學業』分項班級排名。若是分項群組為『行為』，則取得『德行』分項班級排名。")]
        public int? GroupMainClassRating
        {
            get
            {
                if (!K12.Data.Utility.Utility.IsNullOrEmpty(ClassRating))
                {
                    Dictionary<string, SHRankingInfo> Infos = ClassRating.ToDictionary(x => x.Name);

                    if (Group.Equals("學習"))
                    {
                        if (Infos.ContainsKey("學業"))
                            return Infos["學業"].Ranking;
                    }
                    else if (Group.Equals("行為"))
                    {
                        if (Infos.ContainsKey("德行"))
                            return Infos["德行"].Ranking;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 根據分項群組取得對應的分項年級排名。
        /// 若是分項群組為『學習』，則取得『學業』分項年級排名。
        /// 若是分項群組為『行為』，則取得『德行』分項年級排名。
        /// </summary>
        [Field(Caption = "分項群組主要年級排名", EntityName = "SHSchoolYearEntryScore", EntityCaption = "學期分項成績", Remark = "根據分項群組取得對應的分項年級排名。若是分項群組為『學習』，則取得『學業』分項年級排名。若是分項群組為『行為』，則取得『德行』分項年級排名。")]
        public int? GroupYearRating
        {
            get
            {
                if (!K12.Data.Utility.Utility.IsNullOrEmpty(YearRating))
                {
                    Dictionary<string, SHRankingInfo> Infos = YearRating.ToDictionary(x => x.Name);

                    if (Group.Equals("學習"))
                    {
                        if (Infos.ContainsKey("學業"))
                            return Infos["學業"].Ranking;
                    }
                    else if (Group.Equals("行為"))
                    {
                        if (Infos.ContainsKey("德行"))
                            return Infos["德行"].Ranking;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 根據分項群組取得對應的分項科排名。
        /// 若是分項群組為『學習』，則取得『學業』分項科排名。
        /// 若是分項群組為『行為』，則取得『德行』分項科排名。
        /// </summary>
        [Field(Caption = "分項群組主要年級排名", EntityName = "SHSchoolYearEntryScore", EntityCaption = "學期分項成績", Remark = "根據分項群組取得對應的分項科排名。若是分項群組為『學習』，則取得『學業』分項科排名。若是分項群組為『行為』，則取得『德行』分項科排名。")]
        public int? GroupDeptRating
        {
            get
            {
                if (!K12.Data.Utility.Utility.IsNullOrEmpty(DeptRating))
                {
                    Dictionary<string, SHRankingInfo> Infos = DeptRating.ToDictionary(x => x.Name);

                    if (Group.Equals("學習"))
                    {
                        if (Infos.ContainsKey("學業"))
                            return Infos["學業"].Ranking;
                    }
                    else if (Group.Equals("行為"))
                    {
                        if (Infos.ContainsKey("德行"))
                            return Infos["德行"].Ranking;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 分項成績
        /// </summary>
        public Dictionary<string, decimal> Scores { get; set; }

        /// <summary>
        /// 班級排名
        /// </summary>
        public List<SHRankingInfo> ClassRating { get; set; }

        /// <summary>
        /// 年級排名
        /// </summary>
        public List<SHRankingInfo> YearRating { get; set; }

        /// <summary>
        /// 科排名
        /// </summary>
        public List<SHRankingInfo> DeptRating { get; set; }

        /// <summary>
        /// 用XML參數載入資料
        /// <![CDATA[
        ///    <SchoolYearEntryScore ID="11812">
        ///    <RefStudentId>49614</RefStudentId>
        ///    <SchoolYear>96</SchoolYear>
        ///    <GradeYear>3</GradeYear>
        ///    <EntryGroup>學習</EntryGroup>
        ///    <ScoreInfo>
        ///        <SchoolYearEntryScore>
        ///            <Entry 分項="學業" 成績="86.1" />
        ///        </SchoolYearEntryScore>
        ///    </ScoreInfo>
        ///    <ClassRating>
        ///        <Rating 範圍人數="52">
        ///            <Item 分項="學業" 成績="86.1" 成績人數="52" 排名="10" />
        ///        </Rating>
        ///    </ClassRating>
        ///    <DeptRating>
        ///        <Rating 範圍人數="144">
        ///            <Item 分項="學業" 成績="86.1" 成績人數="144" 排名="24" />
        ///        </Rating>
        ///    </DeptRating>
        ///    <YearRating>
        ///        <Rating 範圍人數="1225">
        ///            <Item 分項="學業" 成績="86.1" 成績人數="828" 排名="85" />
        ///        </Rating>
        ///    </YearRating>
        ///</SchoolYearEntryScore>
        /// ]]>
        /// </summary>
        /// <param name="element"></param>
        public void Load(XmlElement element)
        {
            XmlHelper helper = new XmlHelper(element);

            ID = helper.GetString("@ID");
            RefStudentID = helper.GetString("RefStudentId");
            SchoolYear = helper.GetInteger("SchoolYear", 0);
            GradeYear = helper.GetInteger("GradeYear", 0);
            Group = helper.GetString("EntryGroup");

            Scores = new Dictionary<string, decimal>();

            foreach (var subjectElement in helper.GetElements("ScoreInfo/SchoolYearEntryScore/Entry"))
            {
                string strEntry = subjectElement.GetAttribute("分項");
                decimal Score = K12.Data.Decimal.Parse(subjectElement.GetAttribute("成績"));

                if (!Scores.ContainsKey(strEntry))
                    Scores.Add(strEntry, Score);
            }

            ClassRating = new List<SHRankingInfo>();

            foreach (XmlElement Element in element.SelectNodes("ClassRating/Rating/Item"))
                ClassRating.Add(new SHRankingInfo(Element, "分項"));

            YearRating = new List<SHRankingInfo>();

            foreach (XmlElement Element in element.SelectNodes("YearRating/Rating/Item"))
                YearRating.Add(new SHRankingInfo(Element, "分項"));

            DeptRating = new List<SHRankingInfo>();

            foreach (XmlElement Element in element.SelectNodes("DeptRating/Rating/Item"))
                DeptRating.Add(new SHRankingInfo(Element, "分項"));
        }
    }
}