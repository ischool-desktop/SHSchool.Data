using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FISCA.Data;
//using FISCA.DSAUtil;
using K12.Data;

namespace SHSchool.Data
{
    /// <summary>
    /// 科別類別，提供方法用來取得、新增、修改及刪除課程資訊
    /// </summary>
    public class SHDepartment
    {
        private const string SELECT_DEPARTMENT = "SmartSchool.Config.GetDepartment";

        /// <summary>
        /// 取得所有科別
        /// </summary>
        /// <returns>List&lt;SHDepartmentRecord&gt;，代表多筆科別物件。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHDepartmentRecord&gt; records = SHDepartment.SelectAll();
        ///     </code>
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        [SelectMethod("SHSchool.SHDepartment.SelectAll", "學籍.科別")]
        public static List<SHDepartmentRecord> SelectAll()
        {
            List<SHDepartmentRecord> result = new List<SHDepartmentRecord>();

            QueryHelper helper = new QueryHelper();

            string strSQL = "select id,name,code,ref_teacher_id from dept";

            DataTable table = helper.Select(strSQL);

            foreach (DataRow Row in table.Rows)
            {
                SHDepartmentRecord record = new SHDepartmentRecord(Row);
                result.Add(record);
            }

            return result;
        }


        /// <summary>
        /// 根據單筆科別編號取得科別記錄物件
        /// </summary>
        /// <param name="DepartmentID">科別記錄編號</param>
        /// <returns>SHDepartmentRecord，科別記錄物件。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHDepartmentRecord record = SHDepartmentRecord.SelectByID(DepartmentID);
        ///     </code>
        /// </example>
        public static SHDepartmentRecord SelectByID(string DepartmentID)
        {
            List<string> IDs = new List<string>();

            IDs.Add(DepartmentID);

            List<SHDepartmentRecord> Records = SelectByIDs(IDs);

            if (Records.Count > 0)
                return Records[0];
            else
                return null;
        }

        /// <summary>
        /// 根據多筆科別編號取得科別記錄列表
        /// </summary>
        /// <param name="DepartmentIDs">多筆科別記錄編號</param>
        /// <returns>List&lt;SHDepartmentRecord&gt;，代表多筆科別物件。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     List&lt;SHDepartmentRecord&gt; records = SHDepartment.SelectByIDs(DepartmentIDs);
        ///     </code>
        /// </example>
        [FISCA.Authentication.AutoRetryOnWebException()]
        public static List<SHDepartmentRecord> SelectByIDs(IEnumerable<string> DepartmentIDs)
        {
            List<SHDepartmentRecord> result = new List<SHDepartmentRecord>();

            if (K12.Data.Utility.Utility.IsNullOrEmpty(DepartmentIDs))
                return result;

            QueryHelper helper = new QueryHelper();

            string strSQL = "select id,name,code,ref_teacher_id from dept where id in (" + string.Join(",",DepartmentIDs.ToArray()) +")";

            DataTable table = helper.Select(strSQL);

            foreach (DataRow Row in table.Rows)
            {
                SHDepartmentRecord record = new SHDepartmentRecord(Row);
                result.Add(record);
            }

            return result;
        }

        /// <summary>
        /// 新增單筆科別記錄
        /// </summary>
        /// <param name="DepartmentRecord">科別記錄物件</param>
        /// <returns>string，傳回新增物件的系統編號。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHDepartmentRecord newrecord = new SHDepartmentRecord();
        ///         strng NewID = SHDepartment.Insert(newrecord)
        ///     </code>
        /// </example>
        public static int Insert(SHDepartmentRecord DepartmentRecord)
        {
            List<SHDepartmentRecord> DepartmentRecords = new List<SHDepartmentRecord>();

            DepartmentRecords.Add(DepartmentRecord);

            int Result = Insert(DepartmentRecords);

            return Result;
        }

        /// <summary>
        /// 新增多筆科別記錄
        /// </summary>
        /// <param name="DepartmentRecords">多筆科別記錄物件</param> 
        /// <returns>List&lt;string&gt;，傳回新增物件的系統編號列表。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///         SHDepartmentRecord record = new SHDepartmentRecord();
        ///         List&lt;SHDepartmentRecord&gt; records = new List&lt;SHDepartmentRecord&gt;();
        ///         records.Add(record);
        ///         List&lt;string&gt; NewID = SHDepartment.Insert(records)
        ///     </code>
        /// </example>
        public static int Insert(IEnumerable<SHDepartmentRecord> records)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return 0;

            UpdateHelper helper = new UpdateHelper();

            List<string> commands = new List<string>();

            List<string> IDs = new List<string>();

            foreach (SHDepartmentRecord record in records)
            {
                string command = "INSERT INTO dept(name,code,ref_teacher_id) VALUES('" + record.FullName + "','" + record.Code + "'," + (string.IsNullOrWhiteSpace(record.RefTeacherID)?"null":record.RefTeacherID)+")";

                commands.Add(command);

                IDs.Add(record.ID);
            }

            int result = helper.Execute(commands);

            if (AfterInsert != null)
                AfterInsert(null, new DataChangedEventArgs(IDs, ChangedSource.Local));
            if (AfterChange != null)
                AfterChange(null, new DataChangedEventArgs(IDs, ChangedSource.Local));

            return result;
        }

        /// <summary>
        /// 更新單筆科別記錄
        /// </summary>
        /// <param name="DepartmentRecord">科別記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHDepartmentRecord record = SHDepartment.SelectByID(DepartmentID);
        ///     int UpdateCount = SHDepartment.Update(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(SHDepartmentRecord record)
        {
            if (record == null)
                return 0;

            List<SHDepartmentRecord> records = new List<SHDepartmentRecord>();

            records.Add(record);

            int Result = Update(records);

            return Result;
        }

        /// <summary>
        /// 更新多筆科別記錄
        /// </summary>
        /// <param name="records">科別記錄物件</param> 
        /// <returns>int，傳回成功更新的筆數。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///     SHDepartmentRecord record = SHDepartment.SelectByID(DepartmentID);
        ///     List&lt;SHDepartmentRecord&gt; records = new List&lt;SHDepartmentRecord&gt;();
        ///     records.Add(record);
        ///     int UpdateCount = SHDepartment.Update(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功更新的筆數。</remarks>
        public static int Update(IEnumerable<SHDepartmentRecord> records)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return 0;

            UpdateHelper helper = new UpdateHelper();

            List<string> commands = new List<string>();
            List<string> IDs = new List<string>();

            foreach (SHDepartmentRecord record in records)
            {
                string command = "UPDATE dept SET name = '" + record.FullName + "',code = '" + record.Code + "',ref_teacher_id =" + (string.IsNullOrWhiteSpace(record.RefTeacherID) ? "null" : record.RefTeacherID) + " WHERE id =" + record.ID;

                IDs.Add(record.ID);

                commands.Add(command);
            }

            int result = helper.Execute(commands);

            if (AfterUpdate != null)
                AfterUpdate(null, new DataChangedEventArgs(IDs,ChangedSource.Local));
            if (AfterChange != null)
                AfterChange(null, new DataChangedEventArgs(IDs, ChangedSource.Local));

            return result;
        }

        /// <summary>
        /// 刪除多筆科別記錄
        /// </summary>
        /// <param name="DepartmentRecords">多筆科別記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHDepartmentRecord&gt; records = SHDepartment.SelectByIDs(DepartmentIDs);
        ///       int DeleteCount = SHDepartment.Delete(records);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(IEnumerable<SHDepartmentRecord> records)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(records))
                return 0;

            List<string> IDs = records.Select(x => x.ID).ToList();

            int result = Delete(IDs);

            return result;
        }

        /// <summary>
        /// 刪除單筆科別記錄
        /// </summary>
        /// <param name="DepartmentRecord">科別記錄物件</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <seealso cref="SHDepartmentRecord"/>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       List&lt;SHDeaprtmentRecord&gt; record = SHDepartment.SelectByID(DepartmentID);
        ///       int DeleteCount = SHDepartment.Delete(record);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(SHDepartmentRecord record)
        {
            if (record == null)
                return 0;

            int result = Delete(record.ID);

            return result;
        }

        /// <summary>
        /// 刪除單筆科別記錄
        /// </summary>
        /// <param name="ClassID">科別記錄系統編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int DeleteCount = SHDepartment.Delete(DepartmentID);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(string ID)
        {
            if (string.IsNullOrWhiteSpace(ID))
                return 0;

            int result = Delete(new List<string>(){ID});

            return result;
        }

        /// <summary>
        /// 刪除多筆科別記錄
        /// </summary>
        /// <param name="DepartmentIDs">多筆科別記錄系統編號</param>
        /// <returns>int，傳回成功刪除的筆數。</returns>
        /// <exception cref="Exception">
        /// </exception>
        /// <example>
        ///     <code>
        ///       int Count = SHDepartment.Delete(DepartmentIDs);
        ///     </code>
        /// </example>
        /// <remarks>傳回值為成功刪除的筆數。</remarks>
        static public int Delete(IEnumerable<string> IDs)
        {
            if (K12.Data.Utility.Utility.IsNullOrEmpty(IDs))
                return 0;

            UpdateHelper helper = new UpdateHelper();
            
            List<string> commands = new List<string>();

            foreach (string ID in IDs)
            {
                string command = "delete from dept where id=" + ID;

                commands.Add(command);
            }

            int result = helper.Execute(commands);

            if (AfterDelete != null)
                AfterDelete(null, new DataChangedEventArgs(IDs, ChangedSource.Local));
            if (AfterChange != null)
                AfterChange(null, new DataChangedEventArgs(IDs, ChangedSource.Local));


            return result;
        }

        /// <summary>
        /// 新增之後所觸發的事件
        /// </summary>
        static public event EventHandler<DataChangedEventArgs> AfterInsert;

        /// <summary>
        /// 更新之後所觸發的事件
        /// </summary>
        static public event EventHandler<DataChangedEventArgs> AfterUpdate;

        /// <summary>
        /// 刪除之後所觸發的事件
        /// </summary>
        static public event EventHandler<DataChangedEventArgs> AfterDelete;

        /// <summary>
        /// 資料改變之後所觸發的事件，新增、更新、刪除都會觸發
        /// </summary>
        static public event EventHandler<DataChangedEventArgs> AfterChange;
    }
}