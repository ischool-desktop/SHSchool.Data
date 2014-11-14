
using K12.Data;
namespace SHSchool.Data
{
    /// <summary>
    /// 學生修課資訊
    /// </summary>
    public class SHSCAttendRecord:K12.Data.SCAttendRecord
    {
        /// <summary>
        /// 校部訂
        /// </summary>
        [Field(Caption = "校部訂", EntityName = "SCAttend", EntityCaption = "學生修課")]
        public new string RequiredBy 
        {
            get 
            { 
                return base.RequiredBy;
            } 
        }
        /// <summary>
        /// 取得必選修
        /// </summary>
        [Field(Caption = "必選修", EntityName = "SCAttend", EntityCaption = "學生修課")]
        public new bool Required
        {
            get
            {
                return base.Required;
            }
        }
        /// <summary>
        /// 是否覆蓋課程的必選修資訊
        /// </summary>
        [Field(Caption = "必選修（覆蓋後）", EntityName = "SCAttend", EntityCaption = "學生修課")]
        public new bool? OverrideRequired 
        {
            get
            {
                return base.OverrideRequired;
            }
            set 
            {
                base.OverrideRequired = value;
            }
        }
        /// <summary>
        /// 取得，指出是否覆蓋課程的校部訂資訊
        /// </summary>
        [Field(Caption = "校部訂（覆蓋後）", EntityName = "SCAttend", EntityCaption = "學生修課")]
        public new string OverrideRequiredBy
        {
            get
            {
                return base.OverrideRequiredBy;
            }
            set
            {
                base.OverrideRequiredBy = value;
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