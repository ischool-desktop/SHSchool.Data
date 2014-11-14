using System.Xml;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 異動代碼對照表記錄物件
    /// </summary>
    public class SHUpdateCodeMappingInfo
    {
        /// <summary>
        /// 異動代碼
        /// </summary>
        [Field(Caption = "代碼", EntityName = "UpdateCodeMapping", EntityCaption = "異動")]
        public string Code { get; set; }

        /// <summary>
        /// 異動原因及事項
        /// </summary>
        [Field(Caption = "原因及事項", EntityName = "UpdateCodeMapping", EntityCaption = "異動")]
        public string Description { get; set; }

        /// <summary>
        /// 異動分類
        /// </summary>
        [Field(Caption = "分類", EntityName = "UpdateCodeMapping", EntityCaption = "異動")]
        public string Type { get; set; }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="data"></param>
        public void Load(XmlElement data)
        {
            if (data.SelectSingleNode("代號")!=null)
                Code = data.SelectSingleNode("代號").InnerText;
    
            if (data.SelectSingleNode("原因及事項")!=null)
                Description = data.SelectSingleNode("原因及事項").InnerText;
    
            if (data.SelectSingleNode("分類")!=null)
                Type = data.SelectSingleNode("分類").InnerText;
        }
    }
}