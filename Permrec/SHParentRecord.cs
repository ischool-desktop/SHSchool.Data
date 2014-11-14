
namespace SHSchool.Data
{
    /// <summary>
    /// 家長及監護人資訊
    /// </summary>
    public class SHParentRecord : K12.Data.ParentRecord
    {
        /// <summary>
        /// 所屬學生記錄物件
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