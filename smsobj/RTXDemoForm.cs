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
        RTXSAPILib.RTXSAPIRootObj RootObj;  //����������
        RTXSAPILib.RTXSAPISmsObj SmsObj;    //�������Ŷ���

        public delegate void AddText(string RevSmsConcent);
        AddText myDelegate;

        public RTXDemoForm()
        {
            InitializeComponent();
            RootObj = new RTXSAPIRootObj(); //����������
            SmsObj = RootObj.CreateAPISmsObj();//ͨ�������󴴽����Ŷ���
            SmsObj.OnSendSmsMessage +=new _IRTXSAPISmsObjEvents_OnSendSmsMessageEventHandler(SmsObj_OnSendSmsMessage);

            myDelegate = new AddText(AddTextMethod);

            RootObj.ServerIP = txtSvrIP.Text;   //���÷�������ַ
            RootObj.ServerPort = Convert.ToInt16(txtSvrPort.Text);//���÷������˿�

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
            string[] RevMobiles = szRecvMobiles.Split(charSeparators); //����ͻ���Ⱥ��������ֻ�����ÿ���ֻ���ֳ���

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
            SmsObj.AppAction = RTXSAPI_APP_ACTION.AA_COPY;//���ù������ͣ�AA_DISTILL��ʾ��ȡ����Ϣ����
            SmsObj.AppGUID = txtAppGUID.Text; //����GUID����GUID����Ϊ{54567dfb-9d81-4382-8f0a-4301761029bf},
            SmsObj.AppName = txtAppName.Text;   //����Ӧ������
            SmsObj.AppPriority = 0; //����Ӧ��Ȩ��
            SmsObj.SmsWordLimit = Convert.ToInt32(txtWordLimit.Text);
            try
            {
                SmsObj.RegisterApp(); //ע��Ӧ��
                MessageBox.Show("ע��ɹ�");
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUnRegApp_Click(object sender, EventArgs e)
        {
            SmsObj.AppGUID = txtAppGUID.Text; //����GUID����GUID����Ϊ{54567dfb-9d81-4382-8f0a-4301761029bf},
            SmsObj.AppName = txtAppName.Text;   //����Ӧ������

            try
            {
                SmsObj.UnRegisterApp(); //ע��Ӧ��
                MessageBox.Show("ע���ɹ�");
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
                SmsObj.StartApp("", 8); //����Ӧ��
                MessageBox.Show("�����ɹ�");
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
                SmsObj.StopApp();   //ֹͣӦ��
                MessageBox.Show("ֹͣ�ɹ�");
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
                MessageBox.Show("���ͳɹ�");
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