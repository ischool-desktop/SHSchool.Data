
namespace SHSchool.Data
{
    /// <summary>
    /// 學生電話資訊
    /// </summary>
    public class SHPhoneRecord : K12.Data.PhoneRecord
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