
namespace SHSchool.Data
{
    /// <summary>
    /// 教師標籤資訊
    /// </summary>
    public class SHTeacherTagRecord:K12.Data.TeacherTagRecord 
    {
        /// <summary>
        /// 取得所屬教師
        /// </summary>
        public new SHTeacherRecord Teacher
        {
            get 
            {
                return !string.IsNullOrEmpty(RefEntityID)?SHSchool.Data.SHTeacher.SelectByID(RefEntityID):null;
            }
        }
    }
}