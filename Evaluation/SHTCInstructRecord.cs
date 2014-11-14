
namespace SHSchool.Data
{
    /// <summary>
    /// 教師教授課程資訊
    /// </summary>
    public class SHTCInstructRecord : K12.Data.TCInstructRecord 
    {
        /// <summary>
        /// 所屬學生
        /// </summary>
        public new SHTeacherRecord Teacher 
        { 
            get
            {
                return !string.IsNullOrEmpty(RefTeacherID)?SHSchool.Data.SHTeacher.SelectByID(RefTeacherID):null;
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