
namespace SHSchool.Data
{
    /// <summary>
    /// 學生懲戒資訊，新增物件時會直接將MeritFlag屬性設為0
    /// </summary>
    public class SHDemeritRecord : K12.Data.DemeritRecord
    {
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
    }
}