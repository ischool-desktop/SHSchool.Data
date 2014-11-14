using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 假別對照類別，提供方法用來取得假別對照資訊
    /// </summary>
    public class SHAbsenceMapping : K12.Data.AbsenceMapping 
    {
        /// <summary>
        /// 取得所有假別對照資訊
        /// </summary>
        /// <returns>List&lt;SHAbsenceMappingInfo&gt;，代表假別對照資訊物件列表。</returns>
        [SelectMethod("SHSchool.SHAbsenceMapping.SelectAll", "學務.假別對照表")]
        public new static List<SHAbsenceMappingInfo> SelectAll()
        {
            return K12.Data.AbsenceMapping.SelectAll<SHAbsenceMappingInfo>();
        }
    }
}