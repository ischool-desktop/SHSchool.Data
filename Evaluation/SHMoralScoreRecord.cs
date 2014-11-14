using System.Xml;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學期德行評量資訊
    /// </summary>
    public class SHMoralScoreRecord : MoralScoreRecord 
    {
        /// <summary>
        /// 導師加減分
        /// </summary>
        [Field(Caption = "導師加減分", EntityName = "MoralScore", EntityCaption = "德行評量")]
        public new decimal? Diff 
        {
            get
            {
                return base.Diff;
            }
            set
            {
                base.Diff = value;
            }
        }

        /// <summary>
        /// 導師評語
        /// </summary>
        [Field(Caption = "導師評語", EntityName = "MoralScore", EntityCaption = "德行評量")]
        public new string Comment 
        {
            get { return base.Comment; }
            set { base.Comment = value; }
        }

        /// <summary>
        /// 其他加減分
        /// </summary>
        public new XmlElement OtherDiff 
        {
            get { return base.OtherDiff; }
            set { base.OtherDiff = value; } 
        }

        /// <summary>
        /// 所屬學生物件
        /// </summary>
        public new SHStudentRecord Student
        {
            get
            {
                return !string.IsNullOrEmpty(RefStudentID)?SHSchool.Data.SHStudent.SelectByID(RefStudentID):null;
            }
        }
    }
}