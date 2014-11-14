
namespace SHSchool.Data
{
    /// <summary>
    /// 學生獎懲資訊
    /// </summary>
    public class SHDisciplineRecord:K12.Data.DisciplineRecord
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