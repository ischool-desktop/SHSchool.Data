using System.Collections.Generic;
using System.Xml;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生學期成績資訊
    /// </summary>
    public class SHSemesterScoreRecord:K12.Data.SemesterScoreRecord
    {
        /// <summary>
        /// 學期科目成績明細
        /// </summary>
        public new Dictionary<string, SHSubjectScore> Subjects { get; set; }
        /// <summary>
        /// 所屬學生
        /// </summary>
        public new SHStudentRecord Student 
        {
            get
            { 
                return !string.IsNullOrEmpty(RefStudentID)?SHStudent.SelectByID(RefStudentID):null; 
            }
        }

        /// <summary>
        /// 無參數建構式，會將學期科目成績明細初始化
        /// </summary>
        public SHSemesterScoreRecord()
        {
            Subjects = new Dictionary<string, SHSubjectScore>();
        }

        /// <summary>
        /// 新增學生學期成績記錄建構式，參數為新增記錄的必填欄位
        /// </summary>
        /// <param name="RefStudentID">所屬學生編號</param>
        /// <param name="SchoolYear">學年度</param>
        /// <param name="Semester">學期</param>
        public SHSemesterScoreRecord(string RefStudentID, int SchoolYear, int Semester)
            : this()
        {
            this.RefStudentID = RefStudentID;
            this.SchoolYear = SchoolYear;
            this.Semester = Semester;
        }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="element"></param>
        public SHSemesterScoreRecord(XmlElement element)
        {
            Load(element);
        }

        /// <summary>
        /// 用XML參數載入資料
        /// </summary>
        /// <param name="element"></param>
        public override void Load(XmlElement element)
        {
            XmlHelper helper = new XmlHelper(element);

            RefStudentID = helper.GetString("RefStudentId");
            ID = helper.GetString("@ID");

            SchoolYear = helper.GetInteger("SchoolYear", 0);
            Semester = helper.GetInteger("Semester", 0);
            GradeYear = helper.GetInteger("GradeYear", 0);

            Subjects = new Dictionary<string, SHSubjectScore>();
            foreach (var subjectElement in helper.GetElements("ScoreInfo/SemesterSubjectScoreInfo/Subject"))
            {
                subjectElement.SetAttribute("ID", ID);
                subjectElement.SetAttribute("RefStudentID", RefStudentID);
                subjectElement.SetAttribute("SchoolYear", K12.Data.Int.GetString(SchoolYear));
                subjectElement.SetAttribute("Semester", K12.Data.Int.GetString(Semester));

                SHSubjectScore subjectScore = new SHSubjectScore(subjectElement);

                if (!Subjects.ContainsKey(subjectScore.Subject))
                    Subjects.Add(subjectScore.Subject, subjectScore);
            }
        }
    }

    //科目成績XML：<Subject 不計學分="否" 不需評分="否" 修課必選修="必修" 修課校部訂="校訂" 原始成績="87" 學年調整成績="" 擇優採計成績="" 是否取得學分="是" 科目="公民" 科目級別="1" 補考成績="" 註記="" 重修成績="" 開課分項類別="學業" 開課學分數="1" />

    /// <summary>
    /// 科目成績
    /// </summary>
    public class SHSubjectScore
    {
        /// <summary>
        /// 所屬學期成績編號，此為唯讀屬性。
        /// </summary>
        [Field(Caption = "編號", EntityName = "SemesterScore", EntityCaption = "學期成績", IsEntityPrimaryKey = true)]
        public string RefSemesterScoreID { get; private set; }

        /// <summary>
        /// 所屬學生編號，此為唯讀屬性。
        /// </summary>
        [Field(Caption = "學生編號", EntityName = "Student", EntityCaption = "學生", IsEntityPrimaryKey = true)]
        public string RefStudentID { get; private set; }

        /// <summary>
        /// 學年度，此為唯讀屬性。
        /// </summary>
        [Field(Caption = "學年度", EntityName = "SemesterScore", EntityCaption = "學期成績")]
        public int SchoolYear { get; private set; }

        /// <summary>
        /// 學期，此為唯讀屬性。
        /// </summary>
        [Field(Caption = "學期", EntityName = "SemesterScore", EntityCaption = "學期成績")]
        public int Semester { get; private set; }

        #region 課程相關屬性
        /// <summary>
        /// 科目名稱
        /// </summary>
        [Field(Caption = "名稱", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public string Subject { get; set; }

        /// <summary>
        /// 學分數
        /// </summary>
        [Field(Caption = "學分數", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public decimal? Credit { get; set; }

        /// <summary>
        /// 必俢
        /// </summary>
        [Field(Caption = "必修", EntityName = "SubjectScore", EntityCaption = "科目成績",Remark="是否為必修科目。")]
        public bool Required { get; set; }

        /// <summary>
        /// 級別，代表單一科目，但是會分散在多個學期修習的情況，例如國文一、國文二。
        /// </summary>
        [Field(Caption = "級別", EntityName = "SubjectScore", EntityCaption = "科目成績", Remark = "代表單一科目，但是會分散在多個學期修習的情況，例如國文一、國文二。")]
        public int? Level { get; set; }
        
        /// <summary>
        /// 部/校訂
        /// </summary>
        [Field(Caption = "部/校訂", EntityName = "SubjectScore", EntityCaption = "科目成績", Remark = "修課校部訂")]
        public string RequiredBy{ get; set;}

        /// <summary>
        /// 不計入學分
        /// </summary>
        [Field(Caption = "不計入學分", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public bool NotIncludedInCredit{ get; set;}

        /// <summary>
        /// 不計分
        /// </summary>
        [Field(Caption = "不計分", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public bool NotIncludedInCalc{ get; set;}

        /// <summary>
        /// 開課分項類別
        /// </summary>
        [Field(Caption = "分項", EntityName = "SubjectScore", EntityCaption = "科目成績", Remark = "開課分項類別")]
        public string Entry { get; set; }

        #endregion

        #region 成績相關屬性

        /// <summary>
        /// 百分比成績
        /// </summary>
        [Field(Caption = "成績", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public decimal? Score { get; set; }

        /// <summary>
        /// 學年調整成績
        /// </summary>
        [Field(Caption = "學年調整成績", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public decimal? ScoreSchoolYearAdjust { get; set; }

        /// <summary>
        /// 擇優採計成績
        /// </summary>
        [Field(Caption = "擇優採計成績", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public decimal? ScoreBetter { get; set; }

        /// <summary>
        /// 補考成績
        /// </summary>
        [Field(Caption = "補考成績", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public decimal? ScoreReExam { get; set; }

        /// <summary>
        /// 重修成績
        /// </summary>
        [Field(Caption = "重修成績", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public decimal? ScoreReCourse { get; set; }

        /// <summary>
        /// 是否取得學分
        /// </summary>
        [Field(Caption = "取得學分", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public bool Pass { get; set; }

        /// <summary>
        /// 註解
        /// </summary>
        [Field(Caption = "註解", EntityName = "SubjectScore", EntityCaption = "科目成績")]
        public string Comment { get; set; }

        #endregion

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public SHSubjectScore()
        {

        }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="subject"></param>
        public SHSubjectScore(XmlElement subject)
        {
            this.Load(subject);
        }

        /// <summary>
        /// 從XML載入資料
        /// <![CDATA[
        /// ]]>
        /// </summary>
        /// <param name="element"></param>
        public virtual void Load(XmlElement element)
        {
            //SHSemesterScore屬性
            RefSemesterScoreID = element.GetAttribute("ID");
            RefStudentID = element.GetAttribute("RefStudentID");
            SchoolYear = K12.Data.Int.Parse(element.GetAttribute("SchoolYear"));
            Semester = K12.Data.Int.Parse(element.GetAttribute("Semester"));

            //課程相關屬性
            Subject = element.GetAttribute("科目");
            Credit = K12.Data.Decimal.ParseAllowNull(element.GetAttribute("開課學分數"));
            Required = element.GetAttribute("修課必選修") == "必修";
            Level = K12.Data.Int.ParseAllowNull(element.GetAttribute("科目級別"));
            RequiredBy = element.GetAttribute("修課校部訂");
            NotIncludedInCredit = element.GetAttribute("不計學分") == "是";
            NotIncludedInCalc = element.GetAttribute("不需評分") == "是";
            Entry = element.GetAttribute("開課分項類別");

            //成績相關屬性
            Score = K12.Data.Decimal.ParseAllowNull(element.GetAttribute("原始成績"));
            ScoreBetter = K12.Data.Decimal.ParseAllowNull(element.GetAttribute("擇優採計成績"));
            ScoreSchoolYearAdjust = K12.Data.Decimal.ParseAllowNull(element.GetAttribute("學年調整成績"));
            ScoreReExam = K12.Data.Decimal.ParseAllowNull(element.GetAttribute("補考成績"));
            ScoreReCourse = K12.Data.Decimal.ParseAllowNull(element.GetAttribute("重修成績"));
            Pass = element.GetAttribute("是否取得學分") == "是";
            Comment = element.GetAttribute("註記");
        }

        /// <summary>
        /// 將資料匯出成XML格式
        /// <![CDATA[
        /// ]]>
        /// </summary>
        /// <returns></returns>
        public XmlElement ToXML()
        {
            System.Xml.XmlDocument xmldoc = new XmlDocument();

            xmldoc.LoadXml("<Subject 不計學分='' 不需評分='' 修課必選修='' 修課校部訂='' 原始成績='' 學年調整成績='' 擇優採計成績='' 是否取得學分='' 科目='' 科目級別='' 補考成績='' 註記='' 重修成績='' 開課分項類別='' 開課學分數=''/>");


            //課程相關屬性
            xmldoc.DocumentElement.SetAttribute("科目", Subject);
            xmldoc.DocumentElement.SetAttribute("開課學分數", K12.Data.Decimal.GetString(Credit));
            xmldoc.DocumentElement.SetAttribute("修課必選修",Required == true?"必修":"選修");
            xmldoc.DocumentElement.SetAttribute("科目級別",K12.Data.Int.GetString(Level));
            xmldoc.DocumentElement.SetAttribute("修課校部訂", RequiredBy);
            xmldoc.DocumentElement.SetAttribute("不計學分",NotIncludedInCredit == true?"是":"否");
            xmldoc.DocumentElement.SetAttribute("不需評分",NotIncludedInCalc == true?"是":"否");
            xmldoc.DocumentElement.SetAttribute("開課分項類別", Entry);

            //成績相關屬性
            xmldoc.DocumentElement.SetAttribute("原始成績", K12.Data.Decimal.GetString(Score));
            xmldoc.DocumentElement.SetAttribute("擇優採計成績", K12.Data.Decimal.GetString(ScoreBetter));
            xmldoc.DocumentElement.SetAttribute("學年調整成績", K12.Data.Decimal.GetString(ScoreSchoolYearAdjust));
            xmldoc.DocumentElement.SetAttribute("補考成績", K12.Data.Decimal.GetString(ScoreReExam));
            xmldoc.DocumentElement.SetAttribute("重修成績", K12.Data.Decimal.GetString(ScoreReCourse));
            xmldoc.DocumentElement.SetAttribute("是否取得學分",Pass==true?"是":"否");
            xmldoc.DocumentElement.SetAttribute("註記",Comment);

            return xmldoc.DocumentElement;
        }
    }
  }