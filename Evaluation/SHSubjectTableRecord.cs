using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace SHSchool.Data
{
    /// <summary>
    /// 核心及學程科目表記錄物件
    /// </summary>
    public class SHSubjectTableRecord
    {
        /// <summary>
        /// 系統編號
        /// </summary>
        public string ID { get; set;}

        /// <summary>
        /// 目前為『核心科目表』或『學程科目表』
        /// </summary>
        public string Catalog { get; set;}

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        /// 必修學分數
        /// </summary>
        public int CreditCount { get; set;}

        /// <summary>
        /// 核心科目學分數
        /// </summary>
        public int CoreCount { get; set; }

        /// <summary>
        /// 科目列表
        /// </summary>
        public List<SHSubjectTableSubject> Subjects { get; set;}

        /// <summary>
        /// 空白建構式
        /// </summary>
        public SHSubjectTableRecord()
        {

        }

        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="data"></param>
        public SHSubjectTableRecord(XmlElement data)
        {
            Load(data);
        }

        /// <summary>
        /// 從XML載入資料
        /// </summary>
        /// <![CDATA[ 
        ///<SubjectTable ID="1">
        ///    <Catalog>核心科目表</Catalog>
        ///    <Name>後期中等教育核心課程</Name>
        ///    <Content>
        ///        <SubjectTableContent CreditCount="48">
        ///            <Subject Name="國文">
        ///                <Level>1</Level>
        ///                <Level>2</Level>
        ///                <Level>3</Level>
        ///                <Level>4</Level>
        ///            </Subject>
        ///            <Subject Name="歷史" />
        ///        </SubjectTableContent>
        ///    </Content>
        ///</SubjectTable>
        /// ]]>
        /// <param name="data"></param>
        public void Load(XmlElement data)
        {
            ID = data.GetAttribute("ID");
            Catalog = data.SelectSingleNode("Catalog").InnerText;
            Name = data.SelectSingleNode("Name").InnerText;
            CreditCount = K12.Data.Int.Parse(data.SelectSingleNode("Content/SubjectTableContent/@CreditCount").InnerText);
            CoreCount = K12.Data.Int.Parse(data.SelectSingleNode("Content/SubjectTableContent/@CoreCount").InnerText);
            Subjects = new List<SHSubjectTableSubject>();

            foreach (XmlNode Node in data.SelectNodes("Content/SubjectTableContent/Subject"))
            {
                SHSubjectTableSubject Subject = new SHSubjectTableSubject();

                Subject.Load(Node as XmlElement);

                Subjects.Add(Subject);
            }
        }

        /// <summary>
        /// 從DataRow載入資料
        /// </summary>
        /// <param name="data"></param>
        public void Load(DataRow data)
        {
            this.ID = ""+data.ItemArray[0];
            this.Catalog = ""+data.ItemArray[1];
            this.Name = ""+data.ItemArray[2];

            XmlDocument xmldoc = new XmlDocument();

            xmldoc.LoadXml(""+data.ItemArray[3]);

            CreditCount = K12.Data.Int.Parse(xmldoc.DocumentElement.GetAttribute("CreditCount"));
            CoreCount = K12.Data.Int.Parse(xmldoc.DocumentElement.GetAttribute("CoreCount"));

            Subjects = new List<SHSubjectTableSubject>();

            foreach (XmlNode Node in xmldoc.DocumentElement.SelectNodes("Subject"))
            {
                SHSubjectTableSubject Subject = new SHSubjectTableSubject();

                Subject.Load(Node as XmlElement);

                Subjects.Add(Subject);
            }
        }
    }

    /// <summary>
    /// 學程或核心科目表科目
    /// </summary>
    public class SHSubjectTableSubject
    {
        /// <summary>
        /// 科目名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否為核心科目，只有學程科目表會是true或false，若是核心科目表的科目，其值為null。
        /// </summary>
        public bool? IsCore { get; set; }

        /// <summary>
        /// 級別
        /// </summary>
        public List<int> Levels { get; set; }

        /// <summary>
        /// 從XML參數載入
        /// </summary>
        /// <param name="data"></param>
        public void Load(XmlElement data)
        {
            Name = data.GetAttribute("Name");           

            string strIsCore = data.GetAttribute("IsCore");

            if (string.IsNullOrEmpty(strIsCore))
                IsCore = null;
            else if (strIsCore.ToLower().Equals("true"))
                IsCore = true;
            else if (strIsCore.ToLower().Equals("false"))
                IsCore = false;
            else 
                IsCore = null;

            Levels = new List<int>();

            foreach (XmlNode SubNode in data.SelectNodes("Level"))
                Levels.Add(K12.Data.Int.Parse(SubNode.InnerText)); 
        }
    }
}