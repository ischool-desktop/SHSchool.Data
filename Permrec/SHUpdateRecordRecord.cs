using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生異動記錄資訊
    /// </summary>
    public class SHUpdateRecordRecord : K12.Data.UpdateRecordRecord 
    {
        /// <summary>
        /// 所屬學生
        /// </summary>
        public new SHStudentRecord Student 
        { 
            get 
            {
                return !string.IsNullOrEmpty(StudentID)?SHSchool.Data.SHStudent.SelectByID(StudentID):null; 
            } 
        }

        /// <summary>
        /// 異動科別名稱
        /// </summary>
        [Field(Caption = "科別", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public new string Department
        {
            get { return base.Department; }
            set { base.Department = value; }
        }

        /// <summary>
        /// 轉入前學生學校
        /// </summary>
        [Field(Caption = "轉入前學校", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string PreviousSchool
        {
            get
            {
                return base.Attributes["PreviousSchool"];
            }
            set
            {
                base.Attributes["PreviousSchool"] = value;
            }
        }

        /// <summary>
        /// 轉入前學生學號
        /// </summary>
        [Field(Caption = "轉入前學號", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string PreviousStudentNumber
        {
            get
            {
                return base.Attributes["PreviousStudentNumber"];
            }
            set
            {
                base.Attributes["PreviousStudentNumber"] = value;
            }
        }

        /// <summary>
        /// 轉入前科別
        /// </summary>
        [Field(Caption = "轉入前科別", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string PreviousDepartment
        {
            get
            {
                return base.Attributes["PreviousDepartment"];
            }
            set
            {
                base.Attributes["PreviousDepartment"] = value;
            }
        }
        
        /// <summary>
        /// 轉入前最後核準日期
        /// </summary>
        [Field(Caption = "轉入前最後核準日期", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string PreviousSchoolLastADDate
        {
            get
            {
                return base.Attributes["PreviousSchoolLastADDate"];
            }
            set
            {
                base.Attributes["PreviousSchoolLastADDate"] = value;
            }
        }

        /// <summary>
        /// 轉入前最後核準文號
        /// </summary>
        [Field(Caption = "轉入前最後核準文號", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string PreviousSchoolLastADNumber
        {
            get
            {
                return base.Attributes["PreviousSchoolLastADNumber"];
            }
            set
            {
                base.Attributes["PreviousSchoolLastADNumber"] = value;
            }
        }

        /// <summary>
        /// 轉入前年級
        /// </summary>
        [Field(Caption = "轉入前年級", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string PreviousGradeYear
        {
            get
            {
                return base.Attributes["PreviousGradeYear"];
            }
            set
            {
                base.Attributes["PreviousGradeYear"] = value;
            }
        }

        /// <summary>
        /// 轉入前學期，99年進校轉入生異動名冊開始新增使用。
        /// </summary>
        [Field(Caption = "轉入前學期", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string PreviousSemester
        {
            get
            {
                return base.Attributes["PreviousSemester"];
            }
            set
            {
                base.Attributes["PreviousSemester"] = value;
            }
        }

        /// <summary>
        /// 畢業國中所在地代碼
        /// </summary>
        [Field(Caption = "畢業國中所在地代碼", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string GraduateSchoolLocationCode
        {
            get
            {
                return base.Attributes["GraduateSchoolLocationCode"];
            }
            set
            {
                base.Attributes["GraduateSchoolLocationCode"] = value;
            }
        }

        /// <summary>
        /// 畢業國中
        /// </summary>
        [Field(Caption = "畢業國中", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string GraduateSchool
        {
            get
            {
                return base.Attributes["GraduateSchool"];
            }
            set
            {
                base.Attributes["GraduateSchool"] = value;
            }
        }

        /// <summary>
        /// 畢業國中學校代碼
        /// </summary>
        [Field(Caption = "畢業國中學校代碼", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string GraduateSchoolCode
        {
            get
            {
                return base.Attributes["GraduateSchoolCode"];
            }
            set
            {
                base.Attributes["GraduateSchoolCode"] = value;
            }
        }

        /// <summary>
        /// 高中畢業證書字號
        /// </summary>
        [Field(Caption = "高中畢業證書字號", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string GraduateCertificateNumber
        {
            get
            {
                return base.Attributes["GraduateCertificateNumber"];
            }
            set
            {
                base.Attributes["GraduateCertificateNumber"] = value;
            }
        }

        /// <summary>
        /// 最後異動代碼
        /// </summary>
        [Field(Caption = "最後異動代碼", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string LastUpdateCode
        {
            get
            {
                return base.Attributes["LastUpdateCode"];
            }
            set
            {
                base.Attributes["LastUpdateCode"] = value;
            }
        }

        /// <summary>
        /// 新學號
        /// </summary>
        [Field(Caption = "新學號", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string NewStudentNumber
        {
            get
            {
                return base.Attributes["NewStudentNumber"];
            }
            set
            {
                base.Attributes["NewStudentNumber"] = value;
            }
        }

        /// <summary>
        /// 更正後資料，一般適用學籍異動，可能異動的資料為更改姓名、更改身份證字號、更改學號、更改生日、更改性別。
        /// </summary>
        [Field(Caption = "更正後資料", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "一般適用學籍異動，可能異動的資料為更改姓名、更改身份證字號、更改學號、更改生日、更改性別。")]
        public string NewData
        {
            get
            {
                return base.Attributes["NewData"];
            }
            set
            {
                base.Attributes["NewData"] = value;
            }
        }

        /// <summary>
        /// 班別
        /// </summary>
        [Field(Caption = "班別", EntityName = "UpdateRecord", EntityCaption = "異動")]
        public string ClassType
        {
            get
            {
                return base.Attributes["ClassType"];
            }
            set
            {
                base.Attributes["ClassType"] = value;
            }
        }

        /// <summary>
        /// 舊班別，異動原因代碼如果是222 復學(一) 轉科,224 復學(二) 轉科,232 重讀(一) 轉科,234 重讀(二) 轉科,238 復學(一) 重讀轉科必須填寫。
        /// </summary>
        [Field(Caption = "舊班別", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "異動原因代碼如果是222 復學(一) 轉科,224 復學(二) 轉科,232 重讀(一) 轉科,234 重讀(二) 轉科,238 復學(一) 重讀轉科必須填寫。")]
        public string OldClassType
        {
            get
            {
                return base.Attributes["OldClassType"];
            }
            set
            {
                base.Attributes["OldClassType"] = value;
            }
        }

        /// <summary>
        /// 舊科別代碼，異動原因代碼如果是222 復學(一) 轉科,224 復學(二) 轉科,232 重讀(一) 轉科,234 重讀(二) 轉科,238 復學(一) 重讀轉科必須填寫。
        /// </summary>
        [Field(Caption = "舊科別代碼",EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "異動原因代碼如果是222 復學(一) 轉科,224 復學(二) 轉科,232 重讀(一) 轉科,234 重讀(二) 轉科,238 復學(一) 重讀轉科必須填寫。")]
        public string OldDepartmentCode
        {
            get
            {
                return base.Attributes["OldDepartmentCode"];
            }
            set
            {
                base.Attributes["OldDepartmentCode"] = value;
            }
        }

        /// <summary>
        /// 特殊身份代碼，亦為學籍身份代碼，取得對照表請使用SHPermrecStatusMapping.SelectAll()方法，其值一般為SHPermrecStatusMappingInfo.Code屬性。
        /// </summary>
        [Field(Caption = "特殊身份代碼", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "特殊身份代碼，亦為學籍身份代碼，請使用學籍身份對照表參照。")]
        public string SpecialStatus
        {
            get
            {
                return base.Attributes["SpecialStatus"];
            }
            set
            {
                base.Attributes["SpecialStatus"] = value;
            } 
        }

        /// <summary>
        /// 身份證號註（註1），正常：空白、錯誤填1、重號填2、非身份字號填3（如居留證字號），所謂的重號指與所有國民的身份證字號有重覆。
        /// </summary>
        [Field(Caption = "身份證字號註（註1）", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "身份證字號正常：空白、錯誤填1、重號填2、非身份字號填3（如居留證字號），所謂的重號指與所有國民的身份證字號有重覆。")]
        public string IDNumberComment
        {
            get
            {
                return base.Attributes["IDNumberComment"];
            }
            set
            {
                base.Attributes["IDNumberComment"] = value;
            }  
        }

        /// <summary>
        /// 國中畢業年度，該生國中畢業學年度，非入學年度。
        /// </summary>
        [Field(Caption = "國中畢業年度", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "該生國中畢業學年度，非入學年度。")]
        public string GraduateSchoolYear
        {
            get
            {
                return base.Attributes["GraduateSchoolYear"];
            }
            set
            {
                base.Attributes["GraduateSchoolYear"] = value;
            }   
        }

        /// <summary>
        /// 應畢業學年度，使用在呈報日校99學年度延修生名冊、延修生學籍異動名冊、延修生畢業名冊。
        /// </summary>
        [Field(Caption = "應畢業學年度", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "學生應畢業學年度，使用在呈報日校99學年度延修生名冊、延修生學籍異動名冊、延修生畢業名冊。")]
        public string ExpectGraduateSchoolYear
        {
            get
            {
                return base.Attributes["ExpectGraduateSchoolYear"];
            }
            set
            {
                base.Attributes["ExpectGraduateSchoolYear"] = value;
            }
        }

        /// <summary>
        /// 入學資格備註，假設在對照表內則應設為空白，否則設為1；取得國中列表使用School.SelectJuniorSchools()方法、取得國小列表使用School.SelectElementarySchools()方法。
        /// </summary>
        [Field(Caption = "入學資格備註", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "假設在對照表內則應設為空白，否則設為1；取得列表請查詢『所有國中』或『所有國小』。")]
        public string GraduateComment
        {
            get
            {
                return base.Attributes["GraduateComment"];
            }
            set
            {
                base.Attributes["GraduateComment"] = value;
            }   
        }

        /// <summary>
        /// 日校用備註2：在學籍異動表示更正後身分證註記代碼，在他校轉入表示轉入身分別代碼。
        /// </summary>
        [Field(Caption="備註2",EntityName ="UpdateRecord",EntityCaption ="異動",Remark="日校用備註2：在學籍異動表示更正後身分證註記代碼，在他校轉入表示轉入身分別代碼。")]
        public string Comment2
        {
            get
            {
                return base.Attributes["Comment2"];
            }
            set
            {
                base.Attributes["Comment2"] = value;
            }
        }

        /// <summary>
        /// 入學資格證明文件
        /// </summary>
        [Field(Caption="GraduateDocument",EntityName="GraduateDocument",EntityCaption="異動",Remark ="")]
        public string GraduateDocument
        {
            get
            {
                return base.Attributes["GraduateDocument"];
            }
            set 
            {
                base.Attributes["GraduateDocument"] = value;
            }
        }

        /// <summary>
        /// 異動記錄種類(新生異動、轉入異動、畢業異動、學籍異動)。
        /// </summary>
        [Field(Caption = "種類", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "根據異動代碼查詢『異動代碼對照表』中的異動分類，目前有『新生異動』、『轉入異動』、『畢業異動』、『學籍異動』。")]
        public string UpdateType
        {
            get
            {
                SHUpdateCodeMappingInfo MappingInfo = SHUpdateCodeMapping.SelectByCode(UpdateCode);

                return MappingInfo == null ? string.Empty : MappingInfo.Type;
            }
        }

        /// <summary>
        /// 借讀學校代碼(借讀名冊)。
        /// </summary>
        [Field(Caption = "借讀學校代碼", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "借讀學校代碼(借讀名冊)")]
        public string Code7SchoolCode
        {
            get
            {
                return base.Attributes["Code7SchoolCode"];
            }
            set
            {
                base.Attributes["Code7SchoolCode"] = value;
            }
        }

        /// <summary>
        /// 借讀科別代碼(借讀名冊)。
        /// </summary>
        [Field(Caption = "借讀科別代碼", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "借讀科別代碼(借讀名冊)")]
        public string Code7DeptCode
        {
            get
            {
                return base.Attributes["Code7DeptCode"];
            }
            set
            {
                base.Attributes["Code7DeptCode"] = value;
            }
        }

        /// <summary>
        /// 借讀申請開始日期(借讀名冊)。
        /// </summary>
        [Field(Caption = "借讀申請開始日期", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "借讀申請開始日期(借讀名冊)")]
        public string Code71BeginDate
        {
            get
            {
                return base.Attributes["Code71BeginDate"];
            }
            set
            {
                base.Attributes["Code71BeginDate"] = value;
            }
        }

        /// <summary>
        /// 借讀申請結束日期(借讀名冊)。
        /// </summary>
        [Field(Caption = "借讀申請結束日期", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "借讀申請結束日期(借讀名冊)")]
        public string Code71EndDate
        {
            get
            {
                return base.Attributes["Code71EndDate"];
            }
            set
            {
                base.Attributes["Code71EndDate"] = value;
            }
        }

        /// <summary>
        /// 借讀實際開始日期(借讀名冊)。
        /// </summary>
        [Field(Caption = "借讀實際開始日期", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "借讀實際開始日期(借讀名冊)")]
        public string Code72BeginDate
        {
            get
            {
                return base.Attributes["Code72BeginDate"];
            }
            set
            {
                base.Attributes["Code72BeginDate"] = value;
            }
        }

        /// <summary>
        /// 借讀實際結束日期(借讀名冊)。
        /// </summary>
        [Field(Caption = "借讀實際結束日期", EntityName = "UpdateRecord", EntityCaption = "異動", Remark = "借讀實際結束日期(借讀名冊)")]
        public string Code72EndDate
        {
            get
            {
                return base.Attributes["Code72EndDate"];
            }
            set
            {
                base.Attributes["Code72EndDate"] = value;
            }
        }

    }
}