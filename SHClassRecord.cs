using System.Collections.Generic;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 班級資訊
    /// </summary>
    public class SHClassRecord : K12.Data.ClassRecord
    {
        /// <summary>
        /// 班導師
        /// </summary>
        public new SHTeacherRecord Teacher
        {
            get
            {
                return !string.IsNullOrEmpty(RefTeacherID)?SHSchool.Data.SHTeacher.SelectByID(RefTeacherID):null;
            }
        }

        /// <summary>
        /// 所屬課程規劃
        /// </summary>
        public new SHProgramPlanRecord ProgramPlan
        {
            get 
            {
                return !string.IsNullOrEmpty(RefProgramPlanID)?SHSchool.Data.SHProgramPlan.SelectByID(RefProgramPlanID):null; 
            }
        }

        /// <summary>
        /// 所屬成績計算規則
        /// </summary>
        public new SHScoreCalcRuleRecord ScoreCalcRule
        {
            get 
            { 
                return !string.IsNullOrEmpty(RefScoreCalcRuleID)?SHSchool.Data.SHScoreCalcRule.SelectByID(RefScoreCalcRuleID):null;
            }
        }

        /// <summary>
        /// 取得班級學生
        /// </summary>
        public new List<SHStudentRecord> Students
        {
            get
            {
                return !string.IsNullOrEmpty(this.ID)?SHStudent.SelectByClassID(this.ID):null; 
            }
        }

        /// <summary>
        /// 所屬科別編號
        /// </summary>
        [Field(Caption = "科別編號", EntityName = "Department", EntityCaption = "科別")]
        public new string RefDepartmentID
        {
            get
            {
                return base.RefDepartmentID;
            }
            set
            {
                base.RefDepartmentID = value;
            }
        }

        /// <summary>
        /// 所屬科別
        /// </summary>
        public SHDepartmentRecord Department
        {
            get 
            {
                if (!string.IsNullOrEmpty(RefDepartmentID))
                    return SHDepartment.SelectByID(RefDepartmentID);
                else
                    return null;
            }
        }
    }
}