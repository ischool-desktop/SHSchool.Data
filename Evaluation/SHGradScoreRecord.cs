using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生畢業成績資訊
    /// </summary>
    public class SHGradScoreRecord
    {
        /// <summary>
        /// 所屬學生編號
        /// </summary>
        [Field(Caption = "學生編號", EntityName = "Student", EntityCaption = "學生", IsEntityPrimaryKey = true)]
        public string RefStudentID { get; set; }
        /// <summary>
        /// 畢業分項成績
        /// </summary>
        public Dictionary<string, GradEntryScore> Entries { get; set; }
        /// <summary>
        /// 所屬學生
        /// </summary>
        public SHStudentRecord Student
        {
            get
            {
                return !string.IsNullOrEmpty(RefStudentID) ? SHStudent.SelectByID(RefStudentID) : null;
            }
        }

        /// <summary>
        /// 預設建構式
        /// </summary>
        public SHGradScoreRecord()
        {

        }

        /// <summary>
        /// XML參數建構式
        /// <![CDATA[
        /// ]]>
        /// </summary>
        /// <param name="data"></param>
        public SHGradScoreRecord(XmlElement data)
        {
            Load(data);
        }

        /// <summary>
        /// 從XML載入設定值
        /// <![CDATA[
        /// ]]>
        /// </summary>
        /// <param name="data"></param>
        public void Load(XmlElement data)
        {
            XmlHelper helper = new XmlHelper(data);

            RefStudentID = helper.GetString("@ID");

            Entries = new Dictionary<string, GradEntryScore>();

            foreach (var entryElement in helper.GetElements("GradScore/GradScore/EntryScore"))
            {
                GradEntryScore entryScore = new GradEntryScore(entryElement);
                Entries.Add(entryScore.Entry, entryScore);
            }
        }
    }

    /// <summary>
    /// 畢業分項成績
    /// </summary>
    public class GradEntryScore : ICloneable
    {
        /// <summary>
        /// 分項名稱
        /// </summary>
        [Field(Caption = "分項", EntityName = "GradEntryScore", EntityCaption = "畢業分項")]
        public string Entry { get; set; }
        /// <summary>
        /// 成績
        /// </summary>
        [Field(Caption = "成績", EntityName = "GradEntryScore", EntityCaption = "畢業分項")]
        public decimal? Score { get; set; }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="element"></param>
        public GradEntryScore(XmlElement element)
        {
            Entry = element.GetAttribute("Entry");
            decimal d;
            if (decimal.TryParse(element.GetAttribute("Score"), out d))
                Score = d;
        }

        /// <summary>
        /// 建構式，傳入預設領域名稱
        /// </summary>
        /// <param name="entry"></param>
        public GradEntryScore(string entry)
        {
            Entry = entry;
        }

        public override string ToString()
        {
            return "<EntryScore Entry="+Entry+" Score="+K12.Data.Decimal.GetString(Score)+" />";
        }

        #region ICloneable 成員

        /// <summary>
        /// 複製畢業成績物件
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            GradEntryScore newScore = new GradEntryScore(Entry);
            newScore.Score = this.Score;
            return newScore;
        }

        #endregion
    }
}