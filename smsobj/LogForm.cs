using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmsObj
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void dataBountToDgvLog()
        {
            DataTable dt = new DataTable();//建立个数据表

            dt.Columns.Add(new DataColumn("id", typeof(int)));//在表中添加int类型的列

            dt.Columns.Add(new DataColumn("Name", typeof(string)));//在表中添加string类型的Name列

            DataRow dr;//行
            for (int i = 0; i < 3; i++)
            {
                dr = dt.NewRow();
                dr["id"] = i;
                dr["Name"] = "Name" + i;
                dt.Rows.Add(dr);//在表的对象的行里添加此行
            }

            dgvLog.DataSource = dt;
            


        }
    }
}
