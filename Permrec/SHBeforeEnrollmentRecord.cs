
namespace SHSchool.Data
{
    /// <summary>
    /// 入學前資訊
    /// 詳細規格：https://docs.google.com/a/ischool.com.tw/View?id=dcw7gq95_29ff6fpfhd
    /// </summary>
    public class SHBeforeEnrollmentRecord:K12.Data.BeforeEnrollmentRecord
    {
        /// <summary>
        /// 所屬學生記錄物件
        /// </summary>
        public new SHStudentRecord Student
        {
            get
            {
                if (!string.IsNullOrEmpty(RefStudentID))
                    return SHStudent.SelectByID(RefStudentID);
                else
                    return null;
            }
        }

        /// <summary>
        /// 國中畢業學年度
        /// </summary>
        public new string GraduateSchoolYear
        {
            get { return base.GraduateSchoolYear; }
            set { base.GraduateSchoolYear = value; }
        }
    }
}