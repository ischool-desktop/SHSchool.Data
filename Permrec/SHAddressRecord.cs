
namespace SHSchool.Data
{
    /// <summary>
    /// 學生地址資訊
    /// </summary>
    public class SHAddressRecord : K12.Data.AddressRecord
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