
using K12.Data;
namespace SHSchool.Data
{

    /// <summary>
    /// 學生資訊
    /// </summary>
    public class SHStudentRecord : K12.Data.StudentRecord
    {
        /// <summary>
        /// 覆蓋後的課程規劃
        /// </summary>
        public new SHProgramPlanRecord OverrideProgramPlan
        {
            get { return !string.IsNullOrEmpty(OverrideProgramPlanID)?SHSchool.Data.SHProgramPlan.SelectByID(OverrideProgramPlanID):null; }
        }

        /// <summary>
        /// 自動判斷所屬課程規劃，若是學生身上有課程規劃，則用學生的，否則取得班級的課程規劃
        /// </summary>
        public new SHProgramPlanRecord ProgramPlan
        {
            get
            {
                if (!string.IsNullOrEmpty(OverrideProgramPlanID))
                    return OverrideProgramPlan;
                else
                    return Class!=null?Class.ProgramPlan:null;
            }
        }
        /// <summary>
        /// 覆蓋後的成績計算規則
        /// </summary>
        public new SHScoreCalcRuleRecord OverrideScoreCalcRule { get { return SHSchool.Data.SHScoreCalcRule.SelectByID(OverrideScoreCalcRuleID); } }
        /// <summary>
        /// 自動判斷所屬成績計算規則，若是學生身上有成績計算規則，則用學生的，否則取得班級的課程規劃
        /// </summary>
        public new SHScoreCalcRuleRecord ScoreCalcRule
        {
            get
            {
                if (!string.IsNullOrEmpty(OverrideScoreCalcRuleID))
                    return OverrideScoreCalcRule;
                else
                    return Class!=null?Class.ScoreCalcRule:null;
            }
        }

        /// <summary>
        /// 學生身上覆蓋後的科別編號
        /// </summary>
        [Field(Caption = "科別編號（覆蓋後）", EntityName = "Department", EntityCaption = "科別")]
        public new string OverrideDepartmentID
        {
            get { return base.OverrideDepartmentID; }
            set { base.OverrideDepartmentID = value; }
        }

        /// <summary>
        /// 學生身上覆蓋後的科別
        /// </summary>
        public SHDepartmentRecord OverrideDepartment
        {
            get 
            {
                if (!string.IsNullOrEmpty(OverrideDepartmentID))
                    return SHDepartment.SelectByID(OverrideDepartmentID);
                else 
                    return null;
            }
        }

        /// <summary>
        /// 自動判斷所屬Department，若是學生身上有OverrideDepartment，則用學生的，否則取得班級的Department
        /// </summary>
        public SHDepartmentRecord Department
        {
            get
            {
                if (OverrideDepartment != null)
                    return OverrideDepartment;
                else
                    return Class==null?null:Class.Department;
            }
        }

        /// <summary>
        /// 自動判斷所屬DepartmentID，若是學生身上有OverrideDepartmentID，則用學生的，否則取得班級的RefDepartmentID
        /// </summary>
        [Field(Caption = "科別編號", EntityName = "Department", EntityCaption = "科別", Remark = "自動判斷所屬科別編號，若是學生身上有覆蓋後科別編號，則用學生的，否則取得班級的科別編號")]
        public string DepartmentID
        {
            get
            {
                if (!string.IsNullOrEmpty(OverrideDepartmentID))
                    return OverrideDepartmentID;
                else
                    return (Class==null)?string.Empty:Class.RefDepartmentID;
            }
        }

        /// <summary>
        /// 所屬班級
        /// </summary>
        public new SHClassRecord Class
        {
            get
            {
                return !string.IsNullOrEmpty(RefClassID)?SHClass.SelectByID(RefClassID):null;
            }
        }
    }
}