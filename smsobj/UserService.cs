using System;
using System.Collections.Generic;
using System.Text;
using Level.Models;
using System.Data.Common;
using System.Data;

namespace Level.DAL
{
    public class UserService
    {
        #region 增
        /// <summary>
        /// 增加部门管理员
        /// </summary>
        /// <param name="master"></param>
        /// <returns></returns>
        public static int AddMaster(User master)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into [master]");
            builder.Append("([name],[truename],");
            builder.Append("[dept],");           
            builder.Append("[masterid],[mastername],[createdate])");
            builder.AppendFormat(" values('{0}',",master.Name);           
            builder.AppendFormat("'{0}',", master.Truename);           
            builder.AppendFormat("'{0}',", master.Dept);           
            builder.AppendFormat("'{0}',", master.Masterid);
            builder.AppendFormat("'{0}',", master.Mastername);
            builder.AppendFormat("'{0}')", DateTime.Now);
            string sql = builder.ToString();

            return new CommonDbHelper().ExecuteSql(builder.ToString());

        }
        #endregion

        #region 删
        /// <summary>
        /// 删除部门管理员
        /// </summary>
        /// <param name="masterID"></param>
        /// <returns></returns>
        public static int DelMaster(long masterID)
        {
            string sql = "delete from [master] where [id]="+masterID;
            return new CommonDbHelper().ExecuteSql(sql);
        }
        public static int DelMasterByLoginName(string loginName)
        {
            string sql = string.Format("delete from [master] where [name]='{0}'", loginName);
            return new CommonDbHelper().ExecuteSql(sql);

        }
        #endregion

        #region 改
        public static int ModifyMaster(User master)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update [master] set");
            builder.AppendFormat("[truename]='{0}',", master.Truename);          
            builder.AppendFormat("[dept]='{0}',", master.Dept);           
            builder.AppendFormat("[masterid]={0},", master.Masterid);
            builder.AppendFormat("[mastername]='{0}',", master.Mastername);
            builder.AppendFormat("[createdate]='{0}' ", master.Createdate);
            builder.AppendFormat(" where id={0}", master.Id);

            return new CommonDbHelper().ExecuteSql(builder.ToString());
        }
      
        #endregion

        #region 查
        public static User GetMasterById(long id)
        {
            string sql = "select * from [master] where [id]=" + id;
            List<User> list = GetMasterListBySQL(sql);
            if (list == null)
                return null;
            return list[0];
        }
        public static User GetMasterByName(string name)
        {
            string sql = "select * from [master] where [name]='" + name + "'";
            List<User> list = GetMasterListBySQL(sql);
            if (list == null||list.Count==0)
                return null;
            return list[0];

        }
        /// <summary>
        /// 获取部门管理员
        /// </summary>
        /// <param name="deptPath"></param>
        /// <returns></returns>
        public static List<User> GetDeptMaster(string deptPath)
        {
            string sql = "select * from [master] where [dept] like '%" + deptPath + "%'";
            //string sql = string.Format("select * from [master] where [dept] like '%;{0}' or [dept] like '%;{0};%' or [dept] like '{0};%' ", deptPath);
            return GetMasterListBySQL(sql);
        }

   
        public static List<User> GetAllMaster()
        {
            string sql = "select * from [master]";
            return GetMasterListBySQL(sql);
        }

        private static List<User> GetMasterListBySQL(string sql)
        {
            List<User> list = new List<User>(); ;
            DataSet ds = new CommonDbHelper().GetDataSet(sql);
            if (null == ds)         //null
                return list;
            if (ds.Tables.Count == 0)//空
                return list;
            DataTable table = ds.Tables[0];
            if (table.Rows.Count > 0)
            {
                list = new List<User>();
                User master = null;
                foreach (DataRow row in table.Rows)
                {
                    master = new User();
                    master.Id = Convert.ToInt64(row["id"]);
                    master.Name = (string)row["name"];                  
                    object truename = row["truename"];
                    master.Truename = truename == DBNull.Value ? string.Empty : (string)truename;
                  
                    object dept = row["dept"];
                    if (DBNull.Value != dept)
                        master.Dept = (string)dept;                    
                    object masterid = row["masterid"];//创建人ID
                    if (DBNull.Value != masterid)
                        master.Masterid = Convert.ToInt64(masterid);
                    object mastername = row["mastername"];//创建人
                    if (DBNull.Value != mastername)
                        master.Mastername = (string)mastername;
                    object createdate = row["createdate"];//创建日期
                    if (DBNull.Value != createdate)
                        master.Createdate = (DateTime)createdate;


                    list.Add(master);

                }
            }
            return list;
        }
       
        #endregion
    }
}
