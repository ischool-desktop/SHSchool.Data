
namespace SHSchool.Data
{
    /// <summary>
    /// 學生標籤資訊
    /// </summary>
    public class SHStudentTagRecord:K12.Data.StudentTagRecord 
    {
        /// <summary>
        /// 取得所屬學生
        /// </summary>
        public SHStudentRecord Student 
        { 
            get 
            {
                return !string.IsNullOrEmpty(RefEntityID)?SHSchool.Data.SHStudent.SelectByID(RefEntityID):null; 
            }
        }
    }
}