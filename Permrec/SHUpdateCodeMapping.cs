using System.Collections.Generic;
using System.Xml;
using System.Linq;
using FISCA.DSAUtil;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 異動代號對照表類別，提供方法用來取得異動代碼對照表
    /// </summary>
    public class SHUpdateCodeMapping
    {
        private static string SELECT_SERVICENAME = "SmartSchool.Config.GetUpdateCodeSynopsis";
        private static Dictionary<string, SHUpdateCodeMappingInfo> mRecords = null;

        /// <summary>
        /// 取得所有異動代碼對照表記錄物件
        /// </summary>
        /// <returns>List&lt;SHUpdateCodeMappingInfo&gt;，異動代碼對照表記錄物件列表。</returns>
        [SelectMethod("SHSchool.SHUpdateCodeMapping.SelectAll", "學籍.異動代號對照表")]
        public static List<SHUpdateCodeMappingInfo> SelectAll()
        {
            if (mRecords == null)
            {
                mRecords = new Dictionary<string, SHUpdateCodeMappingInfo>();

                DSRequest request = new DSRequest();
                DSXmlHelper helper = new DSXmlHelper("GetCountyListRequest");
                helper.AddElement("Field");
                helper.AddElement("Field", "All");
                request.SetContent(helper);
                DSResponse dsrsp = K12.Data.Utility.DSAServices.CallService(SELECT_SERVICENAME, request);

                foreach (XmlElement data in dsrsp.GetContent().GetElements("異動"))
                {
                    SHUpdateCodeMappingInfo record = new SHUpdateCodeMappingInfo();

                    record.Load(data);

                    mRecords.Add(record.Code, record);
                }
            }

            return mRecords.Values.ToList<SHUpdateCodeMappingInfo>();
        }

        /// <summary>
        /// 根據異動記錄代碼取得對應的異動代碼對照表記錄物件
        /// </summary>
        /// <param name="UpdateCode">異動代碼</param>
        /// <returns>SHUpdateCodeMappingInfo，異動代碼對照表記錄物件</returns>
        public static SHUpdateCodeMappingInfo SelectByCode(string UpdateCode)
        {
            if (mRecords == null)
                SelectAll();

            return mRecords.ContainsKey(UpdateCode)?mRecords[UpdateCode]:null;
        }
    }
}