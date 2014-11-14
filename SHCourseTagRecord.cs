
namespace SHSchool.Data
{

    /// <summary>
    /// 課程標籤資訊
    /// </summary>
    public class SHCourseTagRecord:K12.Data.CourseTagRecord
    {
        /// <summary>
        /// 取得所屬課程
        /// </summary>
        public new SHCourseRecord Course 
        { 
            get
            {
                return !string.IsNullOrEmpty(RefEntityID)?SHSchool.Data.SHCourse.SelectByID(RefEntityID):null;
            }
        }
    }
}