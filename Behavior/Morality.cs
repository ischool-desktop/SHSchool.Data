using System.Collections.Generic;
using System.Data;
using System.Xml;
using FISCA.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 文字評量代碼表
    /// </summary>
    public class Morality
    {
        /// <summary>
        /// 取得所有文字評量代碼表記錄
        /// </summary>
        /// <returns>文字評量代碼表記錄列表</returns>
        public static List<MoralityRecord> SelectAll()
        {
            List<MoralityRecord> records = new List<MoralityRecord>();

            QueryHelper helper = new QueryHelper();

            DataTable table = helper.Select("select * from list where name='文字評量代碼表'");

            if (table.Rows.Count >= 1)
            {
                XmlDocument xmldoc = new XmlDocument();

                string Content = "" + table.Rows[0]["content"];

                xmldoc.LoadXml(Content); 

                foreach(XmlNode Node in xmldoc.DocumentElement.SelectNodes("Content/Morality"))
                {
                    MoralityRecord record = new MoralityRecord();

                    record.Load(Node as XmlElement);

                    records.Add(record);
                }
            }

            return records;
        }
    }
}