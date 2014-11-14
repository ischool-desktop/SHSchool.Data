
using K12.Data;
namespace SHSchool.Data
{
    /// <summary>
    /// 課程資訊
    /// </summary>
    public class SHCourseRecord : K12.Data.CourseRecord
    {
        /// <summary>
        /// 所屬班級
        /// </summary>
        public new SHClassRecord Class 
        { 
            get 
            { 
                return !string.IsNullOrEmpty(RefClassID)?SHSchool.Data.SHClass.SelectByID(RefClassID):null;
            } 
        }
        /// <summary>
        /// 所屬試別設定
        /// </summary>
        public new SHAssessmentSetupRecord AssessmentSetup
        { 
            get 
            { 
                return !string.IsNullOrEmpty(RefAssessmentSetupID)?SHSchool.Data.SHAssessmentSetup.SelectByID(RefAssessmentSetupID):null;
            } 
        }
        /// <summary>
        /// 分項
        /// </summary>
        [Field(Caption = "分項", EntityName = "Course", EntityCaption = "課程")]
        public new string Entry
        {
            get { return base.Entry; }
            set { base.Entry = value; }
        }
        /// <summary>
        /// 科目級別
        /// </summary>
        [Field(Caption = "級別", EntityName = "Course", EntityCaption = "課程")]
        public new decimal? Level
        {
            get {return base.Level;}
            set { base.Level = value; }
        }
        /// <summary>
        /// 部/校訂
        /// </summary>
        [Field(Caption = "部/校訂", EntityName = "Course", EntityCaption = "課程")]
        public new string RequiredBy 
        {
            get { return base.RequiredBy; }
            set { base.RequiredBy = value; }
        }
        /// <summary>
        /// 必俢
        /// </summary>
        [Field(Caption = "必修", EntityName = "Course", EntityCaption = "課程")]
        public new bool Required 
        {
            get { return base.Required; }
            set { base.Required = value; }
        }
        /// <summary>
        /// 不計入學分
        /// </summary>
        [Field(Caption = "不計入學分", EntityName = "Course", EntityCaption = "課程")]
        public new bool NotIncludedInCredit 
        {
            get { return base.NotIncludedInCredit; }
            set { base.NotIncludedInCredit = value; } 
        }
        /// <summary>
        /// 不計分
        /// </summary>
        [Field(Caption = "不計分", EntityName = "Course", EntityCaption = "課程")]
        public new bool NotIncludedInCalc 
        {
            get { return base.NotIncludedInCalc; }
            set { base.NotIncludedInCalc = value; }        
        }

    }
}