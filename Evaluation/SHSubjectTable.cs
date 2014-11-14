using System.Collections.Generic;
using System.Data;
using System.Linq;
using FISCA.Data;
using K12.Data.Utility;

namespace SHSchool.Data
{
    /// <summary>
    /// 核心科目表或學程科目表
    /// </summary>
    public class SHSubjectTable
    {
        /// <summary>
        /// 取得核心科目表或學程科目表
        /// </summary>
        /// <returns></returns>
        public static List<SHSubjectTableRecord> Select(IEnumerable<string> IDs, IEnumerable<string> Catalogs,IEnumerable<string> Names)
        {
            string strSQL = "select * from subj_table";
            List<string> strConditions = new List<string>();

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(IDs))
                strConditions.Add("id in (" + string.Join(",", IDs.ToArray()) + ")");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(Catalogs))
                strConditions.Add("catalog in (" + string.Join(",", Catalogs.AddSeperator("'").ToArray()) + ")");

            if (!K12.Data.Utility.Utility.IsNullOrEmpty(Names))
                strConditions.Add("name in (" + string.Join(",", Names.AddSeperator("'").ToArray()) + ")");

            if (strConditions.Count > 0)
                strSQL += " where " + string.Join(" and ", strConditions.ToArray());               

            QueryHelper Helper = new QueryHelper();

            DataTable Result = Helper.Select(strSQL);

            List<SHSubjectTableRecord> records = new List<SHSubjectTableRecord>();

            for (int i = 0; i < Result.Rows.Count; i++)
            {
                SHSubjectTableRecord record = new SHSubjectTableRecord();

                record.Load(Result.Rows[i]);

                records.Add(record);
            }

            return records;
        }
    }
}