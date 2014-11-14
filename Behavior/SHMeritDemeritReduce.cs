using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 取得及更新功過換算表
    /// </summary>
    public class SHMeritDemeritReduce : MeritDemeritReduce
    {
        /// <summary>
        /// 取得功過換算表
        /// </summary>
        /// <returns>功過換算表記錄物件</returns>
        public new static SHMeritDemeritReduceRecord Select()
        {
            return K12.Data.MeritDemeritReduce.Select<SHMeritDemeritReduceRecord>();
        }
    }
}