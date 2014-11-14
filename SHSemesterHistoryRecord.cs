
namespace SHSchool.Data
{
    /// <summary>
    /// 學生學期歷程資訊
    /// </summary>
    public class SHSemesterHistoryRecord : K12.Data.SemesterHistoryRecord 
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