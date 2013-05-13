using System;
using System.Collections.Generic;
using System.Text;

namespace SmsObj
{
   public class Op_Log
    {
        private long sendID;

        public long SendID
        {
            get { return sendID; }
            set { sendID = value; }
        }
        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private int msgType;

        public int MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }
        private int smsID;

        public int SmsID
        {
            get { return smsID; }
            set { smsID = value; }
        }
        private string sender;

        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }
        private int groupID1;

        public int GroupID1
        {
            get { return groupID1; }
            set { groupID1 = value; }
        }
        private int groupID2;

        public int GroupID2
        {
            get { return groupID2; }
            set { groupID2 = value; }
        }
        private int groupID3;

        public int GroupID3
        {
            get { return groupID3; }
            set { groupID3 = value; }
        }
        private int groupID4;

        public int GroupID4
        {
            get { return groupID4; }
            set { groupID4 = value; }
        }
        private int groupID5;

        public int GroupID5
        {
            get { return groupID5; }
            set { groupID5 = value; }
        }
        private string mobile;

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        private string addNum;

        public string AddNum
        {
            get { return addNum; }
            set { addNum = value; }
        }
        private int sendCount;

        public int SendCount
        {
            get { return sendCount; }
            set { sendCount = value; }
        }
        private DateTime sendTime;

        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }
        private string msg;

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }
    }
}
