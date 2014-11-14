using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生學年成績紀錄物件
    /// </summary>
    public class SHSchoolYearScoreRecord
    {
        /// <summary>
        /// 系統編號
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 所屬學生編號
        /// </summary>
        public string RefStudentID { get; set; }

        /// <summary>
        /// 學年度
        /// </summary>
        public int SchoolYear { get; set; }

        /// <summary>
        /// 年級
        /// </summary>
        public int GradeYear { get; set; }

        /// <summary>
        /// 班級範圍人數
        /// </summary>
        public int ClassScopeNumber { get; set; }
        
        /// <summary>
        /// 班級排名
        /// </summary>
        public List<SHRankingInfo> ClassRating { get; set; }

        /// <summary>
        /// 年級範圍人數
        /// </summary>
        public int YearScopeNumber { get; set; }

        /// <summary>
        /// 年級排名
        /// </summary>
        public List<SHRankingInfo> YearRating { get; set; }

        /// <summary>
        /// 科範圍人數
        /// </summary>
        public int DeptScopeNumber { get; set; }

        /// <summary>
        /// 科排名
        /// </summary>
        public List<SHRankingInfo> DeptRating { get; set; }

        /// <summary>
        /// 學期科目成績
        /// </summary>
        public List<SHSchoolYearScoreSubject> Subjects { get; set; }

        /// <summary>
        /// 空白建構式
        /// </summary>
        public SHSchoolYearScoreRecord()
        {

        }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="element"></param>
        public SHSchoolYearScoreRecord(XmlElement element)
        {
            Load(element);
        }

        /// <summary>
        /// 從XML參數載入資料
        /// </summary>
        /// <param name="element"></param>
        public virtual void Load(XmlElement element)
        {
            ID = element.GetAttribute("ID");
            SchoolYear = K12.Data.Int.Parse(element.SelectSingleNode("SchoolYear").InnerText);
            GradeYear = K12.Data.Int.Parse(element.SelectSingleNode("GradeYear").InnerText);
            RefStudentID = element.SelectSingleNode("RefStudentId").InnerText;

            //ClassRating = new List<SHRankingInfo>();

            //foreach (XmlElement Element in element.SelectNodes("ClassRating/Rating/Item"))
            //    ClassRating.Add(new SHRankingInfo(Element));

            //YearRating = new List<SHRankingInfo>();

            //foreach (XmlElement Element in element.SelectNodes("YearRating/Rating/Item"))
            //    YearRating.Add(new SHRankingInfo(Element));

            //DeptRating = new List<SHRankingInfo>();

            //foreach (XmlElement Element in element.SelectNodes("DeptRating/Rating/Item"))
            //    DeptRating.Add(new SHRankingInfo(Element));

            Subjects = new List<SHSchoolYearScoreSubject>();

            foreach (XmlElement Element in element.SelectNodes("ScoreInfo/SchoolYearSubjectScore/Subject"))
                Subjects.Add(new SHSchoolYearScoreSubject(Element));

        }

        public XmlElement ToXML()
        {
            return null;
        }
    }

    /// <summary>
    /// 學生學年科目成績紀錄物件
    /// </summary>
    public class SHSchoolYearScoreSubject
    {
        /// <summary>
        /// 科目名稱
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 分數
        /// </summary>
        public decimal? Score { get; set; }

        /// <summary>
        /// 空白建構式
        /// </summary>
        public SHSchoolYearScoreSubject()
        {
 
        }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="element"></param>
        public SHSchoolYearScoreSubject(XmlElement element)
        {
            Load(element);
        }

        /// <summary>
        /// 由XML載入資料
        /// </summary>
        /// <param name="element"></param>
        public virtual void Load(XmlElement element)
        {
            Subject = element.GetAttribute("科目");
            Score = K12.Data.Decimal.ParseAllowNull(element.GetAttribute("學年成績"));           
        }

        public XmlElement ToXml()
        {
            System.Xml.XmlDocument xmldoc = new XmlDocument();

            xmldoc.LoadXml("<Subject 學年成績='' 科目=''/>");

            //成績相關屬性
            xmldoc.DocumentElement.SetAttribute("學年成績", K12.Data.Decimal.GetString(Score));
            xmldoc.DocumentElement.SetAttribute("科目", Subject);

            return xmldoc.DocumentElement; 
        }
    }
}