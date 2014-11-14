using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FISCA.DSAUtil;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學籍身份對照表類別，提供方法用來取得學籍身份對照表
    /// </summary>
    public class SHPermrecStatusMapping
    {
        private static string SELECT_SERVICENAME = "SmartSchool.Config.GetSchoolConfig";
        private static Dictionary<string, SHPermrecStatusMappingInfo> mRecords = null;

        /// <summary>
        /// 取得所有學籍身份對照表錄物件
        /// </summary>
        /// <returns>List&lt;SHPermrecStatusMappingInfo&gt;，學籍身份對照表記錄物件列表。</returns>
        [SelectMethod("SHSchool.SHPermrecStatusMapping.SelectAll", "學籍.學籍身份對照表")]
        public static List<SHPermrecStatusMappingInfo> SelectAll()
        {
            if (mRecords == null)
            {
                mRecords = new Dictionary<string, SHPermrecStatusMappingInfo>();

                DSResponse dsrsp = K12.Data.Utility.DSAServices.CallService(SELECT_SERVICENAME,new DSRequest());

                foreach (XmlElement data in dsrsp.GetContent().GetElements("Content/學籍身分對照表/Identity"))
                {
                    SHPermrecStatusMappingInfo record = new SHPermrecStatusMappingInfo();

                    record.Load(data);

                    mRecords.Add(record.Code, record);
                }
            }

            return mRecords.Values.ToList<SHPermrecStatusMappingInfo>();
        }

        /// <summary>
        /// 根據學籍身份代碼取得對應的學籍身份對照表記錄物件
        /// </summary>
        /// <param name="Code">學籍身份代碼</param>
        /// <returns>SHPermrecStatusMappingInfo，學籍身份對照表記錄物件</returns>
        public static SHPermrecStatusMappingInfo SelectByCode(string Code)
        {
            if (mRecords == null)
                SelectAll();

            return mRecords.ContainsKey(Code) ? mRecords[Code] : null;
        }

        /// <summary>
        /// 根據學生編號取得對應的學籍身份對照表記錄物件列表。
        /// 1.根據學生編號取得學生標籤。
        /// 2.檢查學生標籤是否有在對照表當中。
        /// 3.將有包含學生標籤的對照表物件加入到結果。
        /// </summary>
        /// <returns></returns>
        public static List<SHPermrecStatusMappingInfo> SelectyByStudentID(string StudentID)
        {
            if (mRecords == null)
                SelectAll();

            List<SHPermrecStatusMappingInfo> results = new List<SHPermrecStatusMappingInfo>();

            if (mRecords.Count > 0)
            {

                foreach (SHStudentTagRecord StudentTagRec in SHStudentTag.SelectByStudentID(StudentID))
                {
                    foreach (SHPermrecStatusMappingInfo record in mRecords.Values)
                    {
                        if (record.TagFullNames != null && record.TagFullNames.Count > 0)
                            if (record.TagFullNames.Contains(StudentTagRec.FullName))
                                if (!results.Contains(record))
                                    results.Add(record);
                    }
                }
            }

            return results;
        }
    }
}