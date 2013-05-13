using System;
using System.Collections.Generic;
using System.Text;
using Level.Models;
using System.Data.Common;
using System.Data;

namespace SmsObj
{
    public class LogService
    {
        static readonly string ORDER_ID_DESC = " order by [UserID] desc";
        public static int AddLog(Op_Log log)
        {
            string sql = string.Format("insert into [SmsLog]([UserID],[MsgType],[SmsID],[Sender],[GroupID1],[GroupID2],[GroupID3],[GroupID4],[GroupID5],[Mobile],[AddNum],[SendCount],[SendTime],[Msg]) values({0},{1},{2},'{3}',{4},{5},{6},{7},{8},'{9}','{10}',{11},{12},'{13}')",
                log.UserID,log.MsgType,log.SmsID,log.Sender,
                log.GroupID1,log.GroupID2,log.GroupID3,log.GroupID4,log.GroupID5,
                log.Mobile,log.AddNum,log.SendCount,log.SendTime,log.Msg);
            return new CommonDbHelper().ExecuteSql(sql);              
        }
        public static int DelLog(long sendID)
        {
            string sql = string.Format("delete from [SmsLog] where [SendID]={0}",sendID);
            return new CommonDbHelper().ExecuteSql(sql);
        }
        public static int DelLogBySql(string sql)
        {
            return new CommonDbHelper().ExecuteSql(sql);
        }
        //public static int ModifyLog(Op_Log log)
        //{
        //}
        public static Op_Log GetLogById(long SendID)
        {
            string sql = string.Format("select * from [SmsLog] where SendID={0}", SendID);
            List<Op_Log> logList = GetLogListBySql(sql);
            if (logList.Count > 0)
                return logList[0];
            return null;
        }
        public static List<Op_Log> GetLogListByUserId(string uid)
        {
            string sql = string.Format("select * from [SmsLog] where UserID={0}" + ORDER_ID_DESC, uid);
            return GetLogListBySql(sql);
        }
        public static List<Op_Log> GetLogListBySender(string sender)
        {
            string sql = string.Format("select * from [SmsLog] where [Sender]='{0}' " + ORDER_ID_DESC, sender);
            return GetLogListBySql(sql);
        }
        public static List<Op_Log> GetLogListByType(string type)
        {
            string sql = string.Format("select * from [SmsLog] where MsgType='{0}' " + ORDER_ID_DESC, type);
            return GetLogListBySql(sql);
        }
        /// <summary>
        ///  根据日期获取日志列表
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>日志列表</returns>
        public static List<Op_Log> GetLogListByBeginTime(DateTime beginTime)
        {
            string sql = string.Format("select * from [SmsLog] where [SendTime]>{0}  " + ORDER_ID_DESC, beginTime);
            return GetLogListBySql(sql);
        }

        public static List<Op_Log> GetLogListByEndTime(DateTime endTime)
        {
            string sql = string.Format("select * from [SmsLog] where [SendTime]<{0}  " + ORDER_ID_DESC, endTime);
            return GetLogListBySql(sql);
        }

        public static List<Op_Log> GetLogListByTime(DateTime beginTime, DateTime endTime)
        {
            string sql = string.Format("select * from [SmsLog] where [SendTime] between {0} and {1}  " + ORDER_ID_DESC, beginTime, endTime);
            return GetLogListBySql(sql);
        }
       
        public static List<Op_Log> GetAllLogs()
        {
            string sql = "select * from [SmsLog] " + ORDER_ID_DESC;
            return GetLogListBySql(sql);
        }

        public static List<Op_Log> GetLogListBySql(string sql)
        {
            List<Op_Log> logList = new List<Op_Log>();
            DataSet ds = new CommonDbHelper().GetDataSet(sql);
            if (ds == null)
                return new List<Op_Log>();
            if (ds.Tables.Count == 0)
                return new List<Op_Log>();
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                Op_Log log = null;
                foreach (DataRow row in dt.Rows)
                {
                    log = new Op_Log();                   
                    log.SendID =Convert.ToInt64(row["SendID"]);
                    log.UserID = row["UserID"] == DBNull.Value ? 0: (int)row["UserID"];
                    log.MsgType =row["MsgType"]==DBNull.Value?0: (int)row["MsgType"];
                    log.SmsID = row["SmsID"] == DBNull.Value ? 0 : (int)row["SmsID"];
                    log.Sender = row["Sender"] == DBNull.Value ? string.Empty : (string)row["Sender"];
                    log.GroupID1 = row["GroupID1"] == DBNull.Value ? 0 : (int)row["GroupID1"];
                    log.GroupID2 = row["GroupID2"] == DBNull.Value ? 0 : (int)row["GroupID2"];
                    log.GroupID3 = row["GroupID3"] == DBNull.Value ? 0 : (int)row["GroupID3"];
                    log.GroupID4 = row["GroupID4"] == DBNull.Value ? 0 : (int)row["GroupID4"];
                    log.GroupID5 = row["GroupID5"] == DBNull.Value ? 0 : (int)row["GroupID5"];
                    log.Mobile = row["Mobile"] == DBNull.Value ? string.Empty : (string)row["Mobile"];
                    log.AddNum = row["AddNum"] == DBNull.Value ? string.Empty : (string)row["AddNum"];
                    log.SendCount = row["SendCount"] == DBNull.Value ? 0 : (int)row["SendCount"];
                    log.SendTime = row["SendTime"] == DBNull.Value ? DateTime.MinValue: Convert.ToDateTime(row["SendTime"]);
                    log.Msg = row["Msg"] == DBNull.Value ? string.Empty : (string)row["Msg"];
                    logList.Add(log);
                }

            }
            return logList;

        }

    }
}
