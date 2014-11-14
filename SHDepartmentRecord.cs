using System.Data;
using System.Xml;
using FISCA.DSAUtil;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 科別資訊
    /// </summary>
    public class SHDepartmentRecord
    {
        private string mFullName;

        /// <summary>
        /// 系統編號
        /// </summary>
        [Field(Caption = "編號", EntityName = "Department", EntityCaption = "科別",IsEntityPrimaryKey=true)]
        public string ID { get; set; }
        /// <summary>
        /// 科別代碼
        /// </summary>
        [Field(Caption = "代碼", EntityName = "Department", EntityCaption = "科別")]
        public string Code { get; set; }
        /// <summary>
        /// 科別名稱，根據完整名稱解析出的科別名稱，例如『綜合高中科:資訊應用學程-94』會解析出『綜合高中科』；只可讀取。
        /// </summary>
        [Field(Caption = "名稱", EntityName = "Department", EntityCaption = "科別", Remark = "根據完整名稱解析出的科別名稱，例如『綜合高中科:資訊應用學程-94』會解析出『綜合高中科』。")]
        public string Name { get; private set; }
        /// <summary>
        /// 資料庫中使用者輸入的原始科別名稱，可讀寫。
        /// </summary>
        [Field(Caption = "完整名稱", EntityName = "Department", EntityCaption = "科別", Remark = "資料庫中使用者輸入的原始科別名稱。")]
        public string FullName 
        {
            get{ return mFullName; }

            set
            {
                mFullName = value;
                Name = mFullName;
                SubDepartment = string.Empty;

                //科別名稱與學程用冒號分隔
                var hasSubDepartment = mFullName.Split(":".ToCharArray()).Length > 1;

                //假設有學程
                if (hasSubDepartment)
                {
                    Name = mFullName.Split(":".ToCharArray())[0];
                    SubDepartment = mFullName.Substring(mFullName.LastIndexOf(":") + 1);
                }
            }
        }

        /// <summary>
        /// 學程名稱，根據完整名稱解析出的科別名稱，例如『綜合高中科:資訊應用學程-94』會解析出『資訊應用學程-94』；只可讀取。
        /// </summary>
        [Field(Caption = "學程名稱", EntityName = "Department", EntityCaption = "科別", Remark = "例如資訊應用學程-94。")]
        public string SubDepartment { get; private set; }

        /// <summary>
        /// 科主任，教師系統編號
        /// </summary>
        [Field(Caption = "教師系統編號", EntityName = "Department", EntityCaption = "科別", Remark = "科主任。")]
        public string RefTeacherID { get; set; }

        /// <summary>
        /// 科主任教師記錄物件
        /// </summary>
        public SHTeacherRecord Teacher
        {
            get
            {
                if (!string.IsNullOrEmpty(RefTeacherID))
                    return SHTeacher.SelectByID(RefTeacherID);
                else
                    return null;
            }
        }

        /// <summary>
        /// 無參數建構式
        /// </summary>
        public SHDepartmentRecord()
        {
 
        }
 
        /// <summary>
        /// XML參數建構式
        /// </summary>
        /// <param name="element"></param>
        public SHDepartmentRecord(XmlElement element)
        {
            Load(element);
        }

        /// <summary>
        /// DataRow參數建構式
        /// </summary>
        /// <param name="Row"></param>
        public SHDepartmentRecord(DataRow Row)
        {
            Load(Row);
        }

        /// <summary>
        /// 從XML載入設定值
        /// </summary>
        /// <param name="element"></param>
        public void Load(XmlElement element)
        {
            ID = element.GetAttribute("ID");
            DSXmlHelper helper = new DSXmlHelper(element);

            //取得科別名稱，並將全形的冒號取代為半形的冒號
            FullName = helper.GetText("Name").Replace("：", ":");

            Code = helper.GetText("Code"); 
        }

        /// <summary>
        /// 從DataRow載入設定值
        /// </summary>
        /// <param name="row"></param>
        public void Load(DataRow row)
        {
            ID = ""+row["id"];
            //取得科別名稱，並將全形的冒號取代為半形的冒號
            FullName = (""+row["name"]).Replace("：", ":");
            Code = ("" + row["code"]);
            RefTeacherID = ""+row["ref_teacher_id"];
        }
    }
}