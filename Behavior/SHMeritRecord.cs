
namespace SHSchool.Data
{
    /// <summary>
    /// 學生獎勵資訊
    /// </summary>
    public class SHMeritRecord : K12.Data.MeritRecord
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