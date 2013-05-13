using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Data.Common;

namespace SmsObj
{
  
    /// <summary>
    /// 数据访问基础类
    /// </summary>
    public class CommonDbHelper
    {
        //public string connectionString = String.Empty;// = ConfigurationManager.ConnectionStrings["DBMonitorConnectionString"].ConnectionString;
        //public DbProviderFactory provider =null;// DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["DBMonitorConnectionString"].ProviderName);

        public string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public DbProviderFactory provider = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["conn"].ProviderName);

        public CommonDbHelper() { }
        public CommonDbHelper(string connStr,DbProviderFactory prov) 
        {
            this.connectionString = connStr;
            this.provider = prov;
        }

        #region 获取数据库信息
        public DataSet GetDatabases()
        {
            string sql = "SELECT Name FROM Master..SysDatabases ORDER BY Name";
            if (string.Equals(provider.ToString(), "MySql.Data.MySqlClient.MySqlClientFactory"))
                sql = string.Format("show databases");
            return GetDataSet(sql);
        }

        public DataSet GetDBTables()
        {
            string sql = "select name from sysobjects where type='U'";
            if (string.Equals(provider.ToString(), "MySql.Data.MySqlClient.MySqlClientFactory"))
                sql = "show tables";
            return GetDataSet(sql);
        }
        public DataSet GetDBColumnsByTblName(string tblName)
        {
            string strSQL = string.Format(" select name  from syscolumns  where (id = (select id from sysobjects  where (id = OBJECT_ID('{0}')))) order by colid", tblName);
            if (string.Equals(provider.ToString(), "MySql.Data.MySqlClient.MySqlClientFactory"))
                strSQL = string.Format("SHOW FULL COLUMNS FROM {0}", tblName);
            return GetDataSet(strSQL);
        }

        #endregion

        #region  执行简单SQL语句      

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString)
        {
            ChangePath();
            using (DbConnection connection = provider.CreateConnection())
            {

                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SQLString;
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                        return rows;
                    }
                    catch (DbException E)
                    {
                        connection.Close();
                        connection.Dispose();
                       // LogWriter.Error("执行SQL命令时出现错误:"+E.Message);
                        //throw new Exception(E.Message);
                        return 0;
                    }
                }
            }
        }

        //
        //
        //public int ExecuteSql(string sqlStr, DataSet ds)
        //{
        //    ChangePath();
        //    using (DbConnection conn = provider.CreateConnection())
        //    {
        //        conn.ConnectionString = connectionString;
        //        using (DbCommand cmd = provider.CreateCommand())
        //        {
        //            int i = 0;
        //            cmd.Connection = conn;
        //            cmd.CommandText = sqlStr;
                    
        //            try
        //            {

        //                DbDataAdapter adapter = provider.CreateDataAdapter();
        //                adapter.UpdateCommand = cmd;
        //                 i = adapter.Update(ds, "ds");
        //                ds.AcceptChanges();                    


        //            }
        //            catch (DbException ex)
        //            {
        //                LogWriter.Error("执行SQL命令时出现错误:"+ex.Message);
        //                // throw new Exception(ex.Message);
        //            }
        //            finally
        //            {
        //                cmd.Dispose();
        //                conn.Close();
        //                conn.Dispose();
                       
        //            }
        //            return i;
        //        }
        //    }
        //}

        /// <summary>执行多条SQL语句，实现数据库事务。
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>        
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = conn;
                    using (DbTransaction tx = conn.BeginTransaction())
                    {
                        cmd.Transaction = tx;
                        try
                        {
                            for (int n = 0; n < SQLStringList.Count; n++)
                            {
                                string strsql = SQLStringList[n].ToString();
                                if (strsql.Trim().Length > 1)
                                {
                                    cmd.CommandText = strsql;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            tx.Commit();
                        }
                        catch (DbException ex)
                        {
                            tx.Rollback();
                            //LogWriter.Error("执行事务时出现错误:"+ex.Message);
                            // throw ex;
                        }
                        finally
                        {
                            conn.Close();
                            conn.Dispose();
                           
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {
            ChangePath();
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SQLString;
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (DbException e)
                    {  // throw new Exception(e.Message);
                        return null;

                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();                     
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public DbDataReader ExecuteReader(string strSQL)
        {
            DbConnection connection = provider.CreateConnection();
            connection.ConnectionString = connectionString;
            DbCommand cmd = provider.CreateCommand();
            cmd.Connection = connection;
            cmd.CommandText = strSQL;
            try
            {
                connection.Open();
                DbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.Common.DbException e)
            {
                connection.Close();
                connection.Dispose();
               // LogWriter.Error("执行Reader查询时出现错误:"+e.Message);
                return null;
               // throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string SQLString)
        {
            ChangePath();
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SQLString;
                    try
                    {
                        DataSet ds = new DataSet();
                        DbDataAdapter adapter = provider.CreateDataAdapter();
                        adapter.SelectCommand = cmd;

                        adapter.Fill(ds, "ds");

                        //adapter.Update(ds.Tables[0]);
                        //ds.AcceptChanges();
                        return ds;

                    }
                    catch (DbException ex)
                    {
                        throw new Exception(ex.Message);
                        // LogWriter.Warn("执行查询DataSet时出现错误:"+ex.Message);

                        return null;

                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                  
                    
                   
                }
            }
        }
        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, DbParameter[] cmdParms)
        {
            ChangePath();
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SQLString;
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        
                        return rows;
                    }
                    catch (DbException E)
                    {
                       // LogWriter.Warn("执行SQL命令时出现错误:"+E.Message);
                        connection.Close();
                        connection.Dispose();
                        return 0;
                        //throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (DbConnection conn = provider.CreateConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    using (DbCommand cmd = provider.CreateCommand())
                    {
                        try
                        {
                            //循环
                            foreach (DictionaryEntry myDE in SQLStringList)
                            {
                                string cmdText = myDE.Key.ToString();
                                DbParameter[] cmdParms = (DbParameter[])myDE.Value;
                                PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            trans.Commit();
                        }
                        catch (DbException ex)
                        {
                            trans.Rollback();
                            //
                            //LogWriter.Warn("执行数据库事务时出现错误:"+ex.Message);
                            conn.Close();
                            conn.Dispose();
                           // throw ex;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）,返回首行首列的值;
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, DbParameter[] cmdParms)
        {
            ChangePath();
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (DbException e)
                    {
                        connection.Close();
                        connection.Dispose();
                        //throw new Exception(e.Message);
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public DbDataReader ExecuteReader(string SQLString, DbParameter[] cmdParms)
        {
            ChangePath();
            DbConnection connection = provider.CreateConnection();
            connection.ConnectionString = connectionString;
            DbCommand cmd = provider.CreateCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                DbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Dispose();
                connection.Dispose();
                return myReader;
            }
            catch (DbException e)
            {
                connection.Close();
                connection.Dispose();
                //throw new Exception(e.Message);
               // LogWriter.Warn("返回Reader时出现错误:"+e.Message);
                return null;
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string SQLString, DbParameter[] cmdParms)
        {
            ChangePath();
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand cmd = provider.CreateCommand())
                {
                    using (DbDataAdapter da = provider.CreateDataAdapter())
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        try
                        {
                            // ds.AcceptChanges();
                            da.Fill(ds, "ds");

                            cmd.Parameters.Clear();
                            return ds;
                        }
                        catch (DbException ex)
                        {
                           // LogWriter.Warn("执行查询语句，返回DateSet时出现错误");
                            connection.Close();
                            connection.Dispose();
                            return null;
                            //throw new Exception(ex.Message);
                        }
                    }
                }
            }
        }

        private void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (DbParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        #endregion

        #region 存储过程操作
        /// <summary>
        /// 执行存储过程;
        /// </summary>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">所需要的参数</param>
        /// <returns>返回受影响的行数</returns>
        public int RunProcedureExecuteSql(string storeProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                DbCommand cmd = BuildQueryCommand(connection, storeProcName, parameters);
                int rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connection.Close();
                return rows;
            }
        }

        /// <summary>
        /// 执行存储过程,返回首行首列的值
        /// </summary>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>返回首行首列的值</returns>
        public Object RunProcedureGetSingle(string storeProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                try
                {
                    DbCommand cmd = BuildQueryCommand(connection, storeProcName, parameters);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (DbException e)
                {
                    connection.Close();
                    connection.Dispose();
                   // throw new Exception(e.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public DbDataReader RunProcedureGetDataReader(string storedProcName, DbParameter[] parameters)
        {
            DbConnection connection = provider.CreateConnection();
            connection.ConnectionString = connectionString;
            DbDataReader returnReader;
            DbCommand cmd = BuildQueryCommand(connection, storedProcName, parameters);
            cmd.CommandType = CommandType.StoredProcedure;
            returnReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return returnReader;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedureGetDataSet(string storedProcName, DbParameter[] parameters)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                DataSet dataSet = new DataSet();
                DbDataAdapter sqlDA = provider.CreateDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet);
                sqlDA.SelectCommand.Parameters.Clear();
                sqlDA.Dispose();
                return dataSet;
            }
        }

        /// <summary>
        /// 执行多个存储过程，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">存储过程的哈希表（value为存储过程语句，key是该语句的DbParameter[]）</param>
        public bool RunProcedureTran(Hashtable SQLStringList)
        {
            using (DbConnection connection = provider.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (DbTransaction trans = connection.BeginTransaction())
                {
                    using (DbCommand cmd = provider.CreateCommand())
                    {
                        try
                        {
                            //循环
                            foreach (DictionaryEntry myDE in SQLStringList)
                            {
                                cmd.Connection = connection;
                                string storeName = myDE.Value.ToString();
                                DbParameter[] cmdParms = (DbParameter[])myDE.Key;

                                cmd.Transaction = trans;
                                cmd.CommandText = storeName;
                                cmd.CommandType = CommandType.StoredProcedure;
                                if (cmdParms != null)
                                {
                                    foreach (DbParameter parameter in cmdParms)
                                    {
                                        cmd.Parameters.Add(parameter);
                                    }
                                }
                                int val = cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            trans.Commit();
                            return true;
                        }
                        catch
                        {
                            trans.Rollback();
                            connection.Close();
                            connection.Dispose();
                            return false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private DbCommand BuildQueryCommand(DbConnection connection, string storedProcName, DbParameter[] parameters)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = provider.CreateCommand();
            command.CommandText = storedProcName;
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Dispose();
            return command;
        }
        #endregion                
        //纠正数据库位置
        //
        private void ChangePath()
        {
            //改变数据库存储路径
            //string p = AppDomain.CurrentDomain.BaseDirectory;//获取操作的直接路径
            ////重新定位数据库
            //if (p.IndexOf("\\bin\\") > 0)
            //{
            //    if (p.EndsWith("\\bin\\Debug\\"))
            //        p = p.Replace("\\bin\\Debug", "");
            //    if (p.EndsWith("\\bin\\Release\\"))
            //        p = p.Replace("\\bin\\Release", "");
            //}
            ////if (!p.EndsWith("App_Data\\"))
            ////    p += "db\\";
            ////p += "App_Data\\";//这里可以指定项目数据库文件夹名
            //AppDomain.CurrentDomain.SetData("DataDirectory", p);
           
            

        }
    }
}

