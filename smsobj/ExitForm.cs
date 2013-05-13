using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsObj
{
    public partial class ExitForm : Form
    {
        /// <summary>用户选择 1为直接退出,2为最小化
        /// 
        /// </summary>
        public static int result = 0;

        public ExitForm()
        {
            result = 0;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            if (radBtnExit.Checked)//直接退出
            {
               result = 1;

            }else if(radBtnMin.Checked)//最小化
            {
                result=2;
            }
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = 3;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      

       
    }
}
