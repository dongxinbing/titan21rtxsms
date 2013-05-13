using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmsObj
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bOnlyOneInstance = false;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.UserAppDataPath.Replace(@"\", "_"), out bOnlyOneInstance);

            if (!bOnlyOneInstance)
            {
                //MessageBox.Show("已经启动了一个RTX多业务系统消息提醒插件!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MainForm.ActiveForm.Show();
                System.Environment.Exit(0);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}