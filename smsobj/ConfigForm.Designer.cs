namespace SmsObj
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWordLimit = new System.Windows.Forms.TextBox();
            this.txtSvrPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSvrIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtManDaoRegPass = new System.Windows.Forms.TextBox();
            this.txtManDaoRegNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxRTX = new System.Windows.Forms.GroupBox();
            this.groupBoxManDao = new System.Windows.Forms.GroupBox();
            this.cbIsUseBizSign = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxRTX.SuspendLayout();
            this.groupBoxManDao.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWordLimit
            // 
            this.txtWordLimit.Location = new System.Drawing.Point(141, 94);
            this.txtWordLimit.Margin = new System.Windows.Forms.Padding(4);
            this.txtWordLimit.Name = "txtWordLimit";
            this.txtWordLimit.Size = new System.Drawing.Size(132, 25);
            this.txtWordLimit.TabIndex = 18;
            this.txtWordLimit.Text = "70";
            // 
            // txtSvrPort
            // 
            this.txtSvrPort.Location = new System.Drawing.Point(141, 59);
            this.txtSvrPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtSvrPort.Name = "txtSvrPort";
            this.txtSvrPort.Size = new System.Drawing.Size(132, 25);
            this.txtSvrPort.TabIndex = 16;
            this.txtSvrPort.Text = "8006";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 98);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "短信字数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "服务器端口：";
            // 
            // txtSvrIP
            // 
            this.txtSvrIP.Location = new System.Drawing.Point(141, 27);
            this.txtSvrIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtSvrIP.Name = "txtSvrIP";
            this.txtSvrIP.Size = new System.Drawing.Size(132, 25);
            this.txtSvrIP.TabIndex = 17;
            this.txtSvrIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "RTX服务器地址：";
            // 
            // txtManDaoRegPass
            // 
            this.txtManDaoRegPass.Location = new System.Drawing.Point(117, 72);
            this.txtManDaoRegPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtManDaoRegPass.Name = "txtManDaoRegPass";
            this.txtManDaoRegPass.Size = new System.Drawing.Size(171, 25);
            this.txtManDaoRegPass.TabIndex = 47;
            // 
            // txtManDaoRegNO
            // 
            this.txtManDaoRegNO.Location = new System.Drawing.Point(117, 40);
            this.txtManDaoRegNO.Margin = new System.Windows.Forms.Padding(4);
            this.txtManDaoRegNO.Name = "txtManDaoRegNO";
            this.txtManDaoRegNO.Size = new System.Drawing.Size(171, 25);
            this.txtManDaoRegNO.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 45;
            this.label2.Text = "注册密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "注册号码";
            // 
            // groupBoxRTX
            // 
            this.groupBoxRTX.Controls.Add(this.cbIsUseBizSign);
            this.groupBoxRTX.Controls.Add(this.label1);
            this.groupBoxRTX.Controls.Add(this.txtSvrIP);
            this.groupBoxRTX.Controls.Add(this.label3);
            this.groupBoxRTX.Controls.Add(this.label9);
            this.groupBoxRTX.Controls.Add(this.txtSvrPort);
            this.groupBoxRTX.Controls.Add(this.txtWordLimit);
            this.groupBoxRTX.Location = new System.Drawing.Point(26, 142);
            this.groupBoxRTX.Name = "groupBoxRTX";
            this.groupBoxRTX.Size = new System.Drawing.Size(318, 166);
            this.groupBoxRTX.TabIndex = 48;
            this.groupBoxRTX.TabStop = false;
            this.groupBoxRTX.Text = "RTX";
            // 
            // groupBoxManDao
            // 
            this.groupBoxManDao.Controls.Add(this.label4);
            this.groupBoxManDao.Controls.Add(this.label2);
            this.groupBoxManDao.Controls.Add(this.txtManDaoRegPass);
            this.groupBoxManDao.Controls.Add(this.txtManDaoRegNO);
            this.groupBoxManDao.Location = new System.Drawing.Point(26, 12);
            this.groupBoxManDao.Name = "groupBoxManDao";
            this.groupBoxManDao.Size = new System.Drawing.Size(318, 124);
            this.groupBoxManDao.TabIndex = 49;
            this.groupBoxManDao.TabStop = false;
            this.groupBoxManDao.Text = "漫道";
            // 
            // cbIsUseBizSign
            // 
            this.cbIsUseBizSign.AutoSize = true;
            this.cbIsUseBizSign.Location = new System.Drawing.Point(26, 136);
            this.cbIsUseBizSign.Name = "cbIsUseBizSign";
            this.cbIsUseBizSign.Size = new System.Drawing.Size(200, 19);
            this.cbIsUseBizSign.TabIndex = 48;
            this.cbIsUseBizSign.Text = "使用企业后缀 [天朗地产]";
            this.cbIsUseBizSign.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(50, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(167, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 362);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxManDao);
            this.Controls.Add(this.groupBoxRTX);
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.groupBoxRTX.ResumeLayout(false);
            this.groupBoxRTX.PerformLayout();
            this.groupBoxManDao.ResumeLayout(false);
            this.groupBoxManDao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtWordLimit;
        private System.Windows.Forms.TextBox txtSvrPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSvrIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtManDaoRegPass;
        private System.Windows.Forms.TextBox txtManDaoRegNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxRTX;
        private System.Windows.Forms.GroupBox groupBoxManDao;
        private System.Windows.Forms.CheckBox cbIsUseBizSign;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}