using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 評分樣板資訊
    /// </summary>
    public class SHAEIncludeRecord : AEIncludeRecord
    {
        /// <summary>
        /// 是否有文字評量
        /// </summary>
        [Field(Caption = "有文字評量", EntityName = "AEInclude", EntityCaption = "評分樣板")]
        public new bool UseText
        {
            get
            {
                return base.UseText ;
            }
            set
            {
                base.UseText = value;
            }
        }

        /// <summary>
        /// 是否有百分比成績
        /// </summary>
        [Field(Caption = "有百分比成績", EntityName = "AEInclude", EntityCaption = "評分樣板")]
        public new bool UseScore
        {
            get
            {
                return base.UseScore;
            }
            set
            {
                base.UseScore = value;
            }
        }

        /// <summary>
        /// 是否開放TeacherAccess輸入成績
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Obsolete("是否開放TeacherAccess輸入成績屬性已不再使用。")]
        [Field(Caption = "開放TA輸入成績", EntityName = "AEInclude", EntityCaption = "評分樣板", Remark = "是否開放TeacherAccess輸入成績，此屬性已不再使用。")]
        public new bool OpenTeacherAccess 
        {
            get
            {
                return base.OpenTeacherAccess;
            }
            set
            {
                base.OpenTeacherAccess = value;
            }
        }
        /// <summary>
        /// 是否強制輸入成績
        /// </summary>
        [Field(Caption = "強制輸入成績", EntityName = "AEInclude", EntityCaption = "評分樣板")]
        public new bool InputRequired 
        {
            get { return base.InputRequired; }
            set { base.InputRequired = value; }
        }

        /// <summary>
        /// 試別樣版記錄物件
        /// </summary>
        public new SHAssessmentSetupRecord AssessmentSetup 
        { 
            get
            { 
                return !string.IsNullOrEmpty(RefAssessmentSetupID)?SHSchool.Data.SHAssessmentSetup.SelectByID(RefAssessmentSetupID):null; 
            }
        }

        /// <summary>
        /// 試別項目記錄物件
        /// </summary>
        public new SHExamRecord Exam 
        {
            get 
            {
                return !string.IsNullOrEmpty(RefExamID)?SHSchool.Data.SHExam.SelectByID(RefExamID):null; 
            }
        }
    }
}