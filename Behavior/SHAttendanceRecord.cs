
namespace SHSchool.Data
{
    /// <summary>
    /// 學生缺曠資訊
    /// </summary>
    public class SHAttendanceRecord : K12.Data.AttendanceRecord
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