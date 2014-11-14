using System.Collections.Generic;
using System.Xml;
using System.Linq;

namespace SHSchool.Data
{
    /// <summary>
    /// 文字評量代碼表記錄
    /// </summary>
    public class MoralityRecord
    {
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 項目
        /// </summary>
        public List<MoralityItem> Items { get; set; }

        /// <summary>
        /// 從XML載入
        /// </summary>
        /// <param name="Element"></param>
        public void Load(XmlElement Element)
        {
            Name = Element.GetAttribute("Face");

            Items = new List<MoralityItem>();

            foreach (XmlNode Node in Element.SelectNodes("Item"))
            {
                XmlElement SubElement = Node as XmlElement;

                MoralityItem Item = new MoralityItem();

                Item.Code = SubElement.GetAttribute("Code");
                Item.Comment = SubElement.GetAttribute("Comment");

                Items.Add(Item);
            }

            Items = Items.OrderBy(x => x.Code).ToList();
        }

        /// <summary>
        /// Xml參數建構式
        /// </summary>
        /// <param name="Element"></param>
        public MoralityRecord(XmlElement Element)
        {
            Load(Element);
        }

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public MoralityRecord()
        {
            Items = new List<MoralityItem>();
        }
    }

    /// <summary>
    /// 文字評量代碼表項目
    /// </summary>
    public class MoralityItem
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set;}

        /// <summary>
        /// 註解
        /// </summary>
        public string Comment { get; set;}
    }
}