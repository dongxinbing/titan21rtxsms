using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VBSDK;

namespace SmsObj
{
    public partial class ManDaoDemoForm : Form
    {
        public string RegisterNo, MobileNo, PassWord;//注册码，手机号，密码
        public Boolean result;
        ASPCom sms = new ASPCom();

        private void getParam()
        {
            RegisterNo = textBox1.Text.Trim();//获取窗体输入的注册号
            PassWord = textBox2.Text.Trim();//获取窗体输入的密码
            MobileNo = textBox3.Text.Trim();//获取窗体输入的手机号

        }
        public ManDaoDemoForm()
        {
            InitializeComponent();
        }

        //注册
        private void button1_Click(object sender, EventArgs e)
        {
            getParam();
            result = sms.Register(RegisterNo, PassWord, "北京", "北京", "软件", "北京东方", "苑长胜", "88888888", "13910423404","yuan@126.com","88888888","北京","010623");
            if (result)
            {
                MessageBox.Show("注册成功！");
            }
            else
            {
                MessageBox.Show("注册失败！！");
            }
        }

        //查询余额
        private void button3_Click(object sender, EventArgs e)
        {
            string str;
            //result = true;
            getParam();//获取注册码
            str = sms.QueryBalance(RegisterNo);
            richTextBox1.Text = "余额为：" + str;
        }

        //发送短信
        private void button5_Click(object sender, EventArgs e)
        {
            getParam();//获取注册号，密码，手机号
            String strContent = richTextBox1.Text.Trim() + "\r\n" + "测试";//获取发送内容
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
                    richTextBox1.Text = "发送成功！" + "\r\n" + "还剩余额：" + str;
                }
                else
                    richTextBox1.Text = "发送失败！";
            }
        }

        //接收短信
        private void button15_Click(object sender, EventArgs e)
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
            richTextBox1.Text = str + "\r\n" + tempSMS;
        }
        //充值
        private void button4_Click(object sender, EventArgs e)
        {
            string FeeCard, FeePass, str;
            FeeCard = textBox5.Text.Trim();//取得充值卡号
            FeePass = textBox6.Text.Trim();//取得充值密码
            getParam();//取得注册号
            if (FeeCard == "" || FeePass == "")
                MessageBox.Show("请添充值卡号或密码", "提示");
            else
            {
                result = sms.ChargeFee(RegisterNo, FeeCard, FeePass);//执行充值
                if (result == true)
                {
                    str = sms.QueryBalance(RegisterNo);//查询余额
                    richTextBox1.Text = ("充值成功！" + "\r\n" + "当前余额为:" + str);

                }
                else
                    richTextBox1.Text = ("充值失败！");
            }
        }

        //发送定时短信
        private void button7_Click(object sender, EventArgs e)
        {
            string str, sendTime, strContent;
            strContent = richTextBox1.Text.Trim();//短信内容
            sendTime = textsendtime.Text;//发送时间
            getParam();
            if (MobileNo=="" || strContent=="")
            {
                MessageBox.Show("请填写发送内容和手机号");
            }
            if (sendTime=="")
            {
                MessageBox.Show("请填写发送时间");
            }
            result = sms.SendTimeSMS(RegisterNo, MobileNo, strContent, sendTime);
            str = sms.QueryBalance(RegisterNo);
            if (result == true)
                richTextBox1.Text = "发送成功！" + "\r\n" + "还剩余额：" + str;
            else
                richTextBox1.Text = "发送失败！";
        }

        //发送短信（网络版）
        private void button6_Click(object sender, EventArgs e)
        {
            getParam();//获得注册码，手机号
            String subcode = textsubcode.Text;
            String strContent = richTextBox1.Text.Trim();//获得发送内容
            if (textBox1.Text.Trim() == "")
                MessageBox.Show("请添写SDK号");
            else if (strContent == "" || MobileNo=="")
                MessageBox.Show("请添写发送内容和手机号");
            else
            {
                string str;
                result = sms.SendSMSEx(RegisterNo, MobileNo, strContent, subcode);//执行发送
                str = sms.QueryBalance(RegisterNo);//查询余额
                if (result == true)
                    richTextBox1.Text = "发送成功！" + "\r\n" + " 还剩余额：" + str;
                else
                    richTextBox1.Text = "发送失败！";
            }
        }

        //接收短信（网络版）
        private void button16_Click(object sender, EventArgs e)
        {
            result = true;
            String subcode = textsubcode.Text;//获取子号
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
                //接收子号信息，子号为空时，接收全部子号的MO
                result = sms.ReceiveSMSEx(RegisterNo, ref total, ref num, ref content, subcode);
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
            richTextBox1.Text = str + "\r\n" + tempSMS;
        }

        //注销
        private void button2_Click(object sender, EventArgs e)
        {
            getParam();//获取注册码
            result = sms.UnRegister(RegisterNo);//执行注销
            if (result == true)
            {
                richTextBox1.Text = "注销成功！";
            }
            else
                richTextBox1.Text = "注销失败！";
        }

        //设定高端通道
        private void buttontongdao_Click(object sender, EventArgs e)
        {
            getParam();//获得序列号，密码
            
        }
    }
}