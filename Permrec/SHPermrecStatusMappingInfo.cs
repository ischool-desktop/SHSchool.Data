using System.Collections.Generic;
using System.Xml;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學籍身份對照表記錄物件
    /// </summary>
    public class SHPermrecStatusMappingInfo
    {
        /// <summary>
        /// 學籍身份代碼
        /// </summary>
        [Field(Caption = "代碼", EntityName = "PermrecStatusMapping", EntityCaption = "學籍身份對照", IsEntityPrimaryKey = true)]
        public string Code { get; set; }

        /// <summary>
        /// 學籍身份名稱
        /// </summary>
        [Field(Caption = "名稱", EntityName = "PermrecStatusMapping", EntityCaption = "學籍身份對照")]
        public string Name { get; set; }

        /// <summary>
        /// 學生標籤的完整名稱列表
        /// </summary>
        public List<string> TagFullNames { get; set; }

        /// <summary>
        /// 學生標籤的完整名稱列表字串
        /// </summary>
        [Field(Caption = "標籤名稱列表", EntityName = "PermrecStatusMapping", EntityCaption = "學籍身份對照")]
        public string TagFullNamesStr
        {
            get
            {
                string Result = string.Empty;

                for (int i = 0; i < TagFullNames.Count; i++)
                    Result += string.IsNullOrEmpty(Result) ? TagFullNames[i] : "," + TagFullNames[i];

                return Result;
            }
        }

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public SHPermrecStatusMappingInfo()
        {
            TagFullNames = new List<string>();
        }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="data"></param>
        public void Load(XmlElement data)
        {
            TagFullNames = new List<string>();

            Code = data.GetAttribute("Code");
            Name = data.GetAttribute("Name");

            foreach (XmlNode Node in data.SelectNodes("Tag"))
                TagFullNames.Add((Node as XmlElement).GetAttribute("FullName"));
        }
    }
}