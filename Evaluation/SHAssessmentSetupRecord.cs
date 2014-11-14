using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 評量設定資訊
    /// </summary>
    public class SHAssessmentSetupRecord:K12.Data.AssessmentSetupRecord 
    {
        /// <summary>
        /// 是否允許上傳成績
        /// </summary>
        [Field(Caption = "允許上傳成績", EntityName = "AssessmentSetup", EntityCaption = "評量設定")]
        public new bool AllowUpload
        {
            get
            {
                return base.AllowUpload;
            }
            set
            {
                base.AllowUpload = AllowUpload;
            }
        }
    }
}