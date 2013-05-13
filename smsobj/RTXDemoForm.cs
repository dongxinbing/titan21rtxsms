using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RTXSAPILib;
using System.Runtime.InteropServices;

namespace SmsObj
{
    public partial class RTXDemoForm : Form
    {
        RTXSAPILib.RTXSAPIRootObj RootObj;  //声明根对象
        RTXSAPILib.RTXSAPISmsObj SmsObj;    //声明短信对象

        public delegate void AddText(string RevSmsConcent);
        AddText myDelegate;

        public RTXDemoForm()
        {
            InitializeComponent();
            RootObj = new RTXSAPIRootObj(); //创建根对象
            SmsObj = RootObj.CreateAPISmsObj();//通过根对象创建短信对象
            SmsObj.OnSendSmsMessage +=new _IRTXSAPISmsObjEvents_OnSendSmsMessageEventHandler(SmsObj_OnSendSmsMessage);

            myDelegate = new AddText(AddTextMethod);

            RootObj.ServerIP = txtSvrIP.Text;   //设置服务器地址
            RootObj.ServerPort = Convert.ToInt16(txtSvrPort.Text);//设置服务器端口

        }

        public void AddTextMethod(string RevSmsConcent)
        {
            txtRtxToMoContent.Text = RevSmsConcent;
        }
        public void SmsObj_OnSendSmsMessage(string szSender, string szSmsSender, string szRecvMobiles, string szMsg, string szCookie) //
        {

            char[] charSeparators = new char[] { ';' };

            string RevSmsConcent;
            string RespondMsg;
            string[] RevMobiles = szRecvMobiles.Split(charSeparators); //如果客户端群发给多个手机，把每个手机拆分出来

            foreach (string aMobile in RevMobiles )   //
            {

                RevSmsConcent = szSender + szSmsSender + aMobile + szMsg + szCookie;
                txtRtxToMoContent.BeginInvoke(myDelegate, RevSmsConcent);

                RespondMsg = "<Result><Item Mobile=" + "\"" + aMobile + "\"" +  " Result=" + "\"\"" + @"/></Result>" ;

                SmsObj.ReSendSmsMessage(szSender, szCookie, RespondMsg);
            }
        }
        private void btnRegApp_Click(object sender, EventArgs e)
        {
            SmsObj.AppAction = RTXSAPI_APP_ACTION.AA_COPY;//设置过滤类型，AA_DISTILL表示抽取该消息类型
            SmsObj.AppGUID = txtAppGUID.Text; //设置GUID，此GUID必须为{54567dfb-9d81-4382-8f0a-4301761029bf},
            SmsObj.AppName = txtAppName.Text;   //设置应用名称
            SmsObj.AppPriority = 0; //设置应用权限
            SmsObj.SmsWordLimit = Convert.ToInt32(txtWordLimit.Text);
            try
            {
                SmsObj.RegisterApp(); //注册应用
                MessageBox.Show("注册成功");
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUnRegApp_Click(object sender, EventArgs e)
        {
            SmsObj.AppGUID = txtAppGUID.Text; //设置GUID，此GUID必须为{54567dfb-9d81-4382-8f0a-4301761029bf},
            SmsObj.AppName = txtAppName.Text;   //设置应用名称

            try
            {
                SmsObj.UnRegisterApp(); //注销应用
                MessageBox.Show("注销成功");
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStartApp_Click(object sender, EventArgs e)
        {
            try
            {
                SmsObj.StartApp("", 8); //启动应用
                MessageBox.Show("启动成功");
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStopApp_Click(object sender, EventArgs e)
        {
            try
            {
                SmsObj.StopApp();   //停止应用
                MessageBox.Show("停止成功");
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SmsObj.SendMoSmsMessage(txtMobile.Text, txtRevUserName.Text, txtMoToRTXContent.Text, txtRevUIN.Text);
                MessageBox.Show("发送成功");
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSvrIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAppName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}