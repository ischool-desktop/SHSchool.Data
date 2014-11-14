
namespace SHSchool.Data
{
    /// <summary>
    /// 學生離校資訊
    /// </summary>
    public class SHLeaveInfoRecord : K12.Data.LeaveInfoRecord
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

        /// <summary>
        /// 畢業時的科別名稱
        /// </summary>
        public new string DepartmentName
        {
            get { return base.DepartmentName; }

            set { base.DepartmentName = value; }
        }
    }
}