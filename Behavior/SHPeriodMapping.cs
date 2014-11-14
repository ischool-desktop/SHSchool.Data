using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 節次對照表類別，提供方法用來取得節次對照資訊
    /// </summary>
    public class SHPeriodMapping:K12.Data.PeriodMapping
    {
        /// <summary>
        /// 取得所有節次對照表清單
        /// </summary>
        /// <returns>List&lt;SHPeriodMappingInfo&gt;，代表節次對照資訊物件列表。</returns>
        [SelectMethod("SHSchool.SHPeriodMapping.SelectAll", "學務.節次對照表")]
        public new static List<SHPeriodMappingInfo> SelectAll()
        {
            return K12.Data.PeriodMapping.SelectAll<SHPeriodMappingInfo>();
        }
    }
}