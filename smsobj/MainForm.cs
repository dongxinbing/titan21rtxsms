using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RTXSAPILib;
using VBSDK;
using System.Xml;
namespace SmsObj
{
    public partial class MainForm : Form
    {


        RTXSAPILib.RTXSAPIRootObj RootObj;  //声明根对象
        RTXSAPILib.RTXSAPISmsObj SmsObj;    //声明短信对象

        public delegate void AddText(string RevSmsConcent);
        AddText myDelegate;
        public MainForm()
        {
            InitializeComponent();
            RootObj = new RTXSAPIRootObj(); //创建根对象
            SmsObj = RootObj.CreateAPISmsObj();//通过根对象创建短信对象
            SmsObj.OnSendSmsMessage += new _IRTXSAPISmsObjEvents_OnSendSmsMessageEventHandler(SmsObj_OnSendSmsMessage);

            myDelegate = new AddText(AddTextMethod);
            RootObj.ServerIP = MyConfigManager.GetRTXServerIP();   //设置服务器地址
            RootObj.ServerPort = MyConfigManager.GetRTXServerPort();//设置服务器端口
            Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine;

            Microsoft.Win32.RegistryKey run = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            object keyvalue = run.GetValue("RTXSMS");
            if (keyvalue == null)
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
        }

        /// <summary>
        /// 输出日志到面板
        /// </summary>
        /// <param name="message"></param>
        private void writeToTxtLog(string message)
        {            
            txtLog.Text += DateTime.Now.ToString("MM.dd HH.mm.ss") + "->" + message + "\r\n";
            this.txtLog.Focus();//获取焦点
            this.txtLog.Select(this.txtLog.TextLength, 0);//光标定位到文本最后
            this.txtLog.ScrollToCaret();//滚动到光标处
        }
        #region 按钮事件
        private void btnStartServices_Click(object sender, EventArgs e)
        {
            try
            {
                //检测到RTX总机号:72616250(西安蓝鸟测试[西安蓝鸟数码网络科技有限公司] 2011 Formal(8.1.756.202))!
                string enterpriseInfoStr = "";
                if (getEnterpriseInfo(out enterpriseInfoStr))
                {
                    txtLog.BeginInvoke(myDelegate,enterpriseInfoStr);
                }
                else
                {
                    txtLog.BeginInvoke(myDelegate,"检测不到RTX总机号，请先申请RTXLicense !");
                    return;
                }
                txtLog.BeginInvoke(myDelegate,"正在初始化...");
                txtLog.BeginInvoke(myDelegate,"正在注册应用...");
                if (!regRTXApp())
                    return;
                txtLog.BeginInvoke(myDelegate,"正在启动应用...");
                if (!startRTXApp())
                    return;
                txtLog.BeginInvoke(myDelegate,"正在连接RTX Server...");
                txtLog.BeginInvoke(myDelegate,"连接RTX Server成功！");
                txtLog.BeginInvoke(myDelegate,"正在初始化短信服务...");
                if (!regManDao())//成功注册短信服务
                {
                    txtLog.BeginInvoke(myDelegate,"初始化短信服务失败！");
                    return;
                }
                txtLog.BeginInvoke(myDelegate,"初始化短信服务成功！");
                txtLog.BeginInvoke(myDelegate,"RTX短信网关已启动成功！");

                btnStartService.Enabled = false;
                // btnStopService.Enabled = true;
                btnCheckBalance.Enabled = true;
                btnConfig.Enabled = false;
            }
            catch (Exception ex)
            {
                txtLog.BeginInvoke(myDelegate,ex.Message);
            }

        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            try
            {
                unRegManDao();//注销漫道应用
                SmsObj.StopApp();//停止应用
                UnRegRTXApp();//注销应用

                btnStartService.Enabled = true;
                // btnStopService.Enabled = false;
                btnCheckBalance.Enabled = false;
                btnConfig.Enabled = true;
            }
            catch (Exception ex)
            {

                txtLog.BeginInvoke(myDelegate,ex.Message);
            }
        }
        #endregion

        #region RTX函数
        public void AddTextMethod(string message)
        {
            //txtRtxToMoContent.Text = RevSmsConcent;
            writeToTxtLog(message);
        }
        public void SmsObj_OnSendSmsMessage(string szSender, string szSmsSender, string szRecvMobiles, string szMsg, string szCookie) //
        {

            char[] charSeparators = new char[] { ';' };

            string RevSmsConcent;
            string RespondMsg;
            string[] RevMobiles = szRecvMobiles.Split(charSeparators); //如果客户端群发给多个手机，把每个手机拆分出来

            foreach (string aMobile in RevMobiles)   //
            {
                try
                {
                    RevSmsConcent = szSender + szSmsSender + aMobile + szMsg + szCookie;
                    //向窗口显示消息
                    //txtRtxToMoContent.BeginInvoke(myDelegate, RevSmsConcent);

                    RespondMsg = "<Result><Item Mobile=" + "\"" + aMobile + "\"" + " Result=" + "\"\"" + @"/></Result>";
                    sendManDaoSMS(aMobile, szMsg.Split(':')[1].ToString() + "\r\n" + szSender); //通过漫道平台发送手机短信
                    SmsObj.ReSendSmsMessage(szSender, szCookie, RespondMsg);
                }
                catch (Exception ex)
                {
                    txtLog.BeginInvoke(myDelegate,ex.Message);
                }
            }
            //发送短信，去除企业前缀
            //sendManDaoSMS(szRecvMobiles.Replace(';', ','), szMsg.Split(':')[1].ToString() + "\r\n" + szSender); //通过漫道平台发送手机短信

        }
        private bool regRTXApp()
        {
            SmsObj.AppAction = RTXSAPI_APP_ACTION.AA_COPY;//设置过滤类型，AA_DISTILL表示抽取该消息类型
            SmsObj.AppGUID = "{54567dfb-9d81-4382-8f0a-4301761029bf}"; //设置GUID，此GUID必须为{54567dfb-9d81-4382-8f0a-4301761029bf},
            SmsObj.AppName = "Tencent.RTX.Sms";   //设置应用名称
            SmsObj.AppPriority = 0; //设置应用权限
            SmsObj.SmsWordLimit = 70; //设置短信大小
            //SmsObj.SmsWordLimit = Convert.ToInt32(txtWordLimit.Text);
            try
            {
                SmsObj.RegisterApp(); //注册应用               
                return true;
            }
            catch (COMException ex)
            {
                txtLog.BeginInvoke(myDelegate,"注册应用失败：" + ex.Message);
                return false;
            }

        }

        private void UnRegRTXApp()
        {
            SmsObj.AppGUID = "{54567dfb-9d81-4382-8f0a-4301761029bf}"; //设置GUID，此GUID必须为{54567dfb-9d81-4382-8f0a-4301761029bf},
            SmsObj.AppName = "Tencent.RTX.Sms";   //设置应用名称

            try
            {
                SmsObj.UnRegisterApp(); //注销应用
                txtLog.BeginInvoke(myDelegate,"注销成功");
            }
            catch (COMException ex)
            {
                txtLog.BeginInvoke(myDelegate,ex.Message);
            }
        }

        private bool startRTXApp()
        {
            try
            {
                SmsObj.StartApp("", 8); //启动应用
                return true;
            }
            catch (COMException ex)
            {
                txtLog.BeginInvoke(myDelegate,"启动应用失败：" + ex.Message);
                return false;
            }
        }

        private void btStopRTXApp(object sender, EventArgs e)
        {
            try
            {
                SmsObj.StopApp();   //停止应用
                txtLog.BeginInvoke(myDelegate,"停止RTX应用成功");
            }
            catch (COMException ex)
            {
                txtLog.BeginInvoke(myDelegate,ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //SmsObj.SendMoSmsMessage(txtMobile.Text, txtRevUserName.Text, txtMoToRTXContent.Text, txtRevUIN.Text);
                txtLog.BeginInvoke(myDelegate,"发送成功");
            }
            catch (COMException ex)
            {
                txtLog.BeginInvoke(myDelegate,ex.Message);
            }
        }

        /// <summary>
        /// 获取企业信息
        /// </summary>
        /// <param name="enterpriseInfo">企业信息</param>
        /// <returns>获取结果</returns>
        private bool getEnterpriseInfo(out string enterpriseInfoStr)
        {
            enterpriseInfoStr = string.Empty;
            bool result = false;
            XmlDocument myXml = new XmlDocument();
            myXml.LoadXml(RootObj.GetEnterpriseInfo());
            XmlNode enterPriseInfo = myXml.DocumentElement; //读取Xml的根结点

            if (!enterPriseInfo.Name.Equals("EnterpriseInfo"))
                return false;
            try
            {
                string enterpriseNum = enterPriseInfo.Attributes["EnterpriseNumber"].Value;
                if (enterpriseNum.Equals("0"))
                {
                    result = false;
                }
                string enterpriseFullName = enterPriseInfo.Attributes["EnterpriseName"].Value;
                string enterpriseShortName = enterPriseInfo.Attributes["EnterpriseShortName"].Value;
                enterpriseInfoStr = string.Format("检测到RTX总机号:{0}({1}[{2}]  {3})", enterpriseNum, enterpriseFullName, enterpriseShortName, RootObj.GetVersion());
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                // MessageBox.Show("读取信息失败！");
            }

            return result;
        }


        #endregion

        #region 漫道程序
        public string RegisterNo, PassWord;//注册码，密码
        public Boolean result;
        ASPCom sms = new ASPCom();

        private void getParam()
        {
            RegisterNo =MyConfigManager.GetManDaoSerialNumber();//获取漫道注册号
            PassWord = MyConfigManager.GetManDaoSerialPassword();//获取漫道的密码
            // MobileNo = "15664639050";//获取窗体输入的手机号

        }

        //注册
        private bool regManDao()
        {
            getParam();
            return sms.Register(RegisterNo, PassWord, "北京", "北京", "软件", "北京东方", "苑长胜", "88888888", "13910423404", "yuan@126.com", "88888888", "北京", "010623");
        }

        //查询余额
        private void checkBalance()
        {
            string str;
            //result = true;
            getParam();//获取注册码
            str = sms.QueryBalance(RegisterNo);
            MessageBox.Show("本账户的短信余额为：" + str + "条");
        }

        //发送短信
        private void sendManDaoSMS(string MobileNo, string strContent)
        {
            getParam();//获取注册号，密码，
            if (RegisterNo == "")
                MessageBox.Show("请添写SDK号");
            else if (strContent == "")
                MessageBox.Show("请添写发送内容");
            else
            {
                string str;
                result = sms.SendSMS(RegisterNo, MobileNo, strContent);


                if (result == true)
                {
                    str = sms.QueryBalance(RegisterNo);//查询余额
                    txtLog.BeginInvoke(myDelegate,"发送成功！" + "\r\n" + "还剩余额：" + str);
                }
                else
                    txtLog.BeginInvoke(myDelegate,"发送失败！");
            }
        }

        //接收短信
        private void receiveManDaoSMS()
        {
            result = true;
            string tempSMS, str;
            object total = null;
            object num = null;
            object content = null;
            bool flag = true;
            getParam();
            tempSMS = "";
            str = "  --------接收短信---------";
            while (flag == true)
            {
                result = sms.ReceiveSMS(RegisterNo, ref total, ref num, ref content);
                if (result == true)
                {
                    tempSMS = tempSMS + ("总数:" + total.ToString() + "\r\n");
                    tempSMS = tempSMS + ("当前数:" + num.ToString() + "\r\n");
                    Object[,] smsArray = (Object[,])content;

                    for (int i = 0; i < int.Parse(num.ToString()); i++)
                    {
                        tempSMS = tempSMS + ("特服号:" + smsArray[i, 0] + "\r\n");
                        tempSMS = tempSMS + ("发送号码:" + smsArray[i, 1] + "\r\n");
                        tempSMS = tempSMS + ("发送内容:" + smsArray[i, 2] + "\r\n");
                        tempSMS = tempSMS + ("发送时间:" + smsArray[i, 3] + "\r\n");
                    }
                    if (int.Parse(total.ToString()) > int.Parse(num.ToString()))
                        flag = true;
                    else
                        flag = false;
                }
                else
                    flag = false;

            }

            //richTextBox1.Text = str + "\r\n" + tempSMS;
        }

        ////发送短信（网络版）
        //private void SendSMSToManDao(string phoneNo,string content)
        //{
        //    getParam();//获得注册码，手机号
        //    String subcode ="";
        //    String strContent =content;//获得发送内容
        //    if (textBox1.Text.Trim() == "")
        //        MessageBox.Show("请添写SDK号");
        //    else if (strContent == "" || MobileNo=="")
        //        MessageBox.Show("请添写发送内容和手机号");
        //    else
        //    {
        //        string str;
        //        result = sms.SendSMSEx(RegisterNo, MobileNo, strContent, subcode);//执行发送
        //        str = sms.QueryBalance(RegisterNo);//查询余额
        //        if (result == true)
        //            richTextBox1.Text = "发送成功！" + "\r\n" + " 还剩余额：" + str;
        //        else
        //            richTextBox1.Text = "发送失败！";
        //    }
        //}

        //接收短信（网络版）
        //private void button16_Click(object sender, EventArgs e)
        //{
        //    result = true;
        //    String subcode = textsubcode.Text;//获取子号
        //    string tempSMS, str;
        //    object total = null;
        //    object num = null;
        //    object content = null;
        //    bool flag = true;
        //    getParam();
        //    tempSMS = "";
        //    str = "  --------接收短信---------";
        //    while (flag == true)
        //    {
        //        //接收子号信息，子号为空时，接收全部子号的MO
        //        result = sms.ReceiveSMSEx(RegisterNo, ref total, ref num, ref content, subcode);
        //        if (result == true)
        //        {
        //            tempSMS = tempSMS + ("总数:" + total.ToString() + "\r\n");
        //            tempSMS = tempSMS + ("当前数:" + num.ToString() + "\r\n");
        //            Object[,] smsArray = (Object[,])content;

        //            for (int i = 0; i < int.Parse(num.ToString()); i++)
        //            {
        //                tempSMS = tempSMS + ("特服号:" + smsArray[i, 0] + "\r\n");
        //                tempSMS = tempSMS + ("发送号码:" + smsArray[i, 1] + "\r\n");
        //                tempSMS = tempSMS + ("发送内容:" + smsArray[i, 2] + "\r\n");
        //                tempSMS = tempSMS + ("发送时间:" + smsArray[i, 3] + "\r\n");
        //            }
        //            if (int.Parse(total.ToString()) > int.Parse(num.ToString()))
        //                flag = true;
        //            else
        //                flag = false;
        //        }
        //        else
        //            flag = false;

        //    }
        //    txtLog.BeginInvoke(myDelegate,str + "\r\n" + tempSMS);
        //}

        //注销
        private void unRegManDao()
        {
            getParam();//获取注册码
            result = sms.UnRegister(RegisterNo);//执行注销    
            if (result == true)
            {
                txtLog.BeginInvoke(myDelegate,"注销漫道短信成功！");
            }
            else
                txtLog.BeginInvoke(myDelegate,"注销漫道短信失败！");
        }

        private void btnCheckBalance_Click(object sender, EventArgs e)
        {
            checkBalance();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ShowExitForm.openExitForm)
            {
                ExitForm exitForm = new ExitForm();
                exitForm.ShowDialog();
                switch (ExitForm.result)
                {
                    case 2:
                        this.ShowInTaskbar = false; this.Hide();
                        this.notifyIcon1.Visible = true; e.Cancel = true; return; break;
                    case 0: e.Cancel = true; break;
                    case 3: e.Cancel = true; break;
                    default: e.Cancel = false; break;//LogWriter.Info("关闭程序"); break;
                }
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;//不显示任务栏
                notifyIcon1.Visible = true;//显示托盘
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /// <summary>
            /// 开机自动启动
            /// </summary>

            //获得文件的当前路径  
            string dir = System.IO.Directory.GetCurrentDirectory();
            //获取可执行文件的全部路径  
            string exeDir = dir + "\\MsgUnitedManagerForm.exe";
            //获取Run键
            Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine;

            Microsoft.Win32.RegistryKey run = reg.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if (checkBox1.Checked) //设置成开机自动启动
            {
                try
                {
                    //在Run键中写入一个新的键值  
                    run.SetValue("RTXSMS", exeDir);
                    reg.Close();
                }
                catch (Exception ex)
                {
                    txtLog.BeginInvoke(myDelegate,"将程序设置为开机启动时出现异常：" + ex.Message);
                    //throw new Exception(ex.ToString());
                    return;
                }
            }
            else //去除开机自动启动
            {
                run.DeleteValue("RTXSMS");
                reg.Close();
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnStopService_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnSetLimit_Click(object sender, EventArgs e)
        {

        }


        ////设定高端通道
        //private void buttontongdao_Click(object sender, EventArgs e)
        //{
        //    getParam();//获得序列号，密码

        //}

        #endregion
    }
}
