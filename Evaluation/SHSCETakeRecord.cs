using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生期中成績資訊
    /// </summary>
    public class SHSCETakeRecord : K12.Data.SCETakeRecord 
    {
        /// <summary>
        /// 評量成績
        /// </summary>
        [Field(Caption = "成績", EntityName = "SCETake", EntityCaption = "評量成績")]
        public new decimal Score
        {
            get { return base.Score; }
            set { base.Score = value; }
        }

        /// <summary>
        /// 文字評量
        /// </summary>
        [Field(Caption = "文字描述", EntityName = "SCETake", EntityCaption = "評量成績")]
        public string Text
        {
            get
            {
                return Extension.SelectSingleNode("Text").InnerText;
            }
            set
            {
                Extension.SelectSingleNode("Text").InnerText = value;
            }
        }

        /// <summary>
        /// 所屬學生
        /// </summary>
        public new SHStudentRecord Student
        {
            get 
            {
                return !string.IsNullOrEmpty(RefStudentID)?SHSchool.Data.SHStudent.SelectByID(RefStudentID):null;
            }
        }

        /// <summary>
        /// 所屬學生修課
        /// </summary>
        public new SHSCAttendRecord SCAttend
        {
            get 
            {
                return !string.IsNullOrEmpty(RefSCAttendID)?SHSchool.Data.SHSCAttend.SelectByID(RefSCAttendID):null; 
            }
        }
        /// <summary>
        /// 所屬試別設定
        /// </summary>
        public new SHExamRecord Exam
        {
            get 
            {
                return !string.IsNullOrEmpty(RefExamID)?SHSchool.Data.SHExam.SelectByID(RefExamID):null; 
            }
        }
        /// <summary>
        /// 所屬課程
        /// </summary>
        public new SHCourseRecord Course
        {
            get
            {
                return !string.IsNullOrEmpty(RefCourseID)?SHSchool.Data.SHCourse.SelectByID(RefCourseID):null; 
            }
        }
    }
}