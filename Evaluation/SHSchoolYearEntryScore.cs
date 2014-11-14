using System.Collections.Generic;
using System.Xml;
using FISCA.DSAUtil;
using K12.Data.Utility;

namespace SHSchool.Data
{
    /// <summary>
    /// 學生學年分項成績類別，提供方法用來取得、新增、修改及刪除學生學年分項成績資訊
    /// </summary>
    public class SHSchoolYearEntryScore
    {
        private const string SELECT_SERVICENAME = "SmartSchool.Score.GetSchoolYearEntryScore";

        /// <summary>
        /// 根據條件取得學生學期分項成績物件紀錄列表
        /// </summary>
        /// <param name="IDs">學生學期分項成績編號</param>
        /// <param name="StudentIDs">學生編號列表</param>
        /// <param name="EntryGroup">分項群組</param>
        /// <param name="SchoolYears">學年度列表</param>
        /// <returns>List&lt;SHSchoolYearEntryScoreRecord&gt;，代表多筆學生學期分項紀錄物件。</returns>
        public static List<SHSchoolYearEntryScoreRecord> Select(IEnumerable<string> IDs, IEnumerable<string> StudentIDs, string EntryGroup, IEnumerable<int> SchoolYears)
        {
            return Select<SHSchoolYearEntryScoreRecord>(IDs, StudentIDs, EntryGroup, SchoolYears);
        }

        [FISCA.Authentication.AutoRetryOnWebException()]
        protected static List<T> Select<T>(IEnumerable<string> IDs, IEnumerable<string> StudentIDs, string EntryGroup, IEnumerable<int> SchoolYears) where T : SHSchoolYearEntryScoreRecord, new()
        {
            DSXmlHelper helper = new DSXmlHelper("GetSchoolYearEntryScore");
            helper.AddElement("Field");
            helper.AddElement("Field", "ID");
            helper.AddElement("Field", "RefStudentId");
            helper.AddElement("Field", "SchoolYear");
            helper.AddElement("Field", "GradeYear");
            helper.AddElement("Field", "EntryGroup");
            helper.AddElement("Field", "ScoreInfo");
            helper.AddElement("Field", "ClassRating");
            helper.AddElement("Field", "DeptRating");
            helper.AddElement("Field", "YearRating");

            helper.AddElement("Condition");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(IDs))
            {
                helper.AddElement("Condition", "IDList");

                foreach (string ID in IDs)
                    if (!string.IsNullOrEmpty(ID))
                        helper.AddElement("Condition", "IDList/ID", ID);
            }

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(StudentIDs))
            {
                helper.AddElement("Condition", "StudentIDList");
                foreach (var StudentID in StudentIDs)
                    if (!string.IsNullOrEmpty(StudentID))
                        helper.AddElement("Condition/StudentIDList", "ID", StudentID);
            }

            if (!string.IsNullOrEmpty(EntryGroup))
                helper.AddElement("Condition", "EntryGroup", EntryGroup);

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(SchoolYears))
                foreach (int each in SchoolYears)
                    helper.AddElement("Condition", "SchoolYear", K12.Data.Int.GetString(each));

            DSResponse rsp = DSAServices.CallService(SELECT_SERVICENAME, new DSRequest(helper));

            List<T> Types = new List<T>();

            foreach (XmlElement element in rsp.GetContent().GetElements("SchoolYearEntryScore"))
            {
                T Type = new T();
                Type.Load(element);
                Types.Add(Type);
            }

            return Types;
        }
    }
}