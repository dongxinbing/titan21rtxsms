namespace SmsObj
{
    partial class RTXDemoForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSvrIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAppGUID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSvrPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.btnRegApp = new System.Windows.Forms.Button();
            this.btnUnRegApp = new System.Windows.Forms.Button();
            this.btnStartApp = new System.Windows.Forms.Button();
            this.btnStopApp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRtxToMoContent = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMoToRTXContent = new System.Windows.Forms.TextBox();
            this.txtRevUIN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRevUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtWordLimit = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址：";
            // 
            // txtSvrIP
            // 
            this.txtSvrIP.Location = new System.Drawing.Point(136, 8);
            this.txtSvrIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtSvrIP.Name = "txtSvrIP";
            this.txtSvrIP.Size = new System.Drawing.Size(132, 25);
            this.txtSvrIP.TabIndex = 1;
            this.txtSvrIP.Text = "127.0.0.1";
            this.txtSvrIP.TextChanged += new System.EventHandler(this.txtSvrIP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "应用GUID：";
            // 
            // txtAppGUID
            // 
            this.txtAppGUID.Location = new System.Drawing.Point(136, 41);
            this.txtAppGUID.Margin = new System.Windows.Forms.Padding(4);
            this.txtAppGUID.Name = "txtAppGUID";
            this.txtAppGUID.Size = new System.Drawing.Size(132, 25);
            this.txtAppGUID.TabIndex = 1;
            this.txtAppGUID.Text = "{54567dfb-9d81-4382-8f0a-4301761029bf}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "服务器端口：";
            // 
            // txtSvrPort
            // 
            this.txtSvrPort.Location = new System.Drawing.Point(472, 8);
            this.txtSvrPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtSvrPort.Name = "txtSvrPort";
            this.txtSvrPort.Size = new System.Drawing.Size(132, 25);
            this.txtSvrPort.TabIndex = 1;
            this.txtSvrPort.Text = "8006";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "应用名称：";
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(472, 41);
            this.txtAppName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(132, 25);
            this.txtAppName.TabIndex = 1;
            this.txtAppName.Text = "Tencent.RTX.Sms";
            this.txtAppName.TextChanged += new System.EventHandler(this.txtAppName_TextChanged);
            // 
            // btnRegApp
            // 
            this.btnRegApp.Location = new System.Drawing.Point(21, 141);
            this.btnRegApp.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegApp.Name = "btnRegApp";
            this.btnRegApp.Size = new System.Drawing.Size(131, 30);
            this.btnRegApp.TabIndex = 2;
            this.btnRegApp.Text = "注册应用";
            this.btnRegApp.UseVisualStyleBackColor = true;
            this.btnRegApp.Click += new System.EventHandler(this.btnRegApp_Click);
            // 
            // btnUnRegApp
            // 
            this.btnUnRegApp.Location = new System.Drawing.Point(179, 141);
            this.btnUnRegApp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnRegApp.Name = "btnUnRegApp";
            this.btnUnRegApp.Size = new System.Drawing.Size(131, 30);
            this.btnUnRegApp.TabIndex = 2;
            this.btnUnRegApp.Text = "注销应用";
            this.btnUnRegApp.UseVisualStyleBackColor = true;
            this.btnUnRegApp.Click += new System.EventHandler(this.btnUnRegApp_Click);
            // 
            // btnStartApp
            // 
            this.btnStartApp.Location = new System.Drawing.Point(339, 141);
            this.btnStartApp.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartApp.Name = "btnStartApp";
            this.btnStartApp.Size = new System.Drawing.Size(131, 30);
            this.btnStartApp.TabIndex = 2;
            this.btnStartApp.Text = "启动应用";
            this.btnStartApp.UseVisualStyleBackColor = true;
            this.btnStartApp.Click += new System.EventHandler(this.btnStartApp_Click);
            // 
            // btnStopApp
            // 
            this.btnStopApp.Location = new System.Drawing.Point(501, 141);
            this.btnStopApp.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopApp.Name = "btnStopApp";
            this.btnStopApp.Size = new System.Drawing.Size(131, 30);
            this.btnStopApp.TabIndex = 2;
            this.btnStopApp.Text = "停止应用";
            this.btnStopApp.UseVisualStyleBackColor = true;
            this.btnStopApp.Click += new System.EventHandler(this.btnStopApp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRtxToMoContent);
            this.groupBox1.Location = new System.Drawing.Point(21, 196);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(279, 302);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "收到的下行短信：";
            // 
            // txtRtxToMoContent
            // 
            this.txtRtxToMoContent.Location = new System.Drawing.Point(8, 25);
            this.txtRtxToMoContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtRtxToMoContent.Multiline = true;
            this.txtRtxToMoContent.Name = "txtRtxToMoContent";
            this.txtRtxToMoContent.Size = new System.Drawing.Size(261, 269);
            this.txtRtxToMoContent.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.txtMoToRTXContent);
            this.groupBox2.Controls.Add(this.txtRevUIN);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtRevUserName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMobile);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(323, 196);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(349, 306);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "上行短信示例：";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(109, 265);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(131, 30);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMoToRTXContent
            // 
            this.txtMoToRTXContent.Location = new System.Drawing.Point(17, 155);
            this.txtMoToRTXContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoToRTXContent.Multiline = true;
            this.txtMoToRTXContent.Name = "txtMoToRTXContent";
            this.txtMoToRTXContent.Size = new System.Drawing.Size(309, 94);
            this.txtMoToRTXContent.TabIndex = 4;
            // 
            // txtRevUIN
            // 
            this.txtRevUIN.Location = new System.Drawing.Point(135, 92);
            this.txtRevUIN.Margin = new System.Windows.Forms.Padding(4);
            this.txtRevUIN.Name = "txtRevUIN";
            this.txtRevUIN.Size = new System.Drawing.Size(132, 25);
            this.txtRevUIN.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 136);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "短信内容：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "接收者Uin：";
            // 
            // txtRevUserName
            // 
            this.txtRevUserName.Location = new System.Drawing.Point(135, 59);
            this.txtRevUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtRevUserName.Name = "txtRevUserName";
            this.txtRevUserName.Size = new System.Drawing.Size(132, 25);
            this.txtRevUserName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "接收者呢称：";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(135, 25);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(132, 25);
            this.txtMobile.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "手机号码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 79);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "短信字数：";
            // 
            // txtWordLimit
            // 
            this.txtWordLimit.Location = new System.Drawing.Point(136, 75);
            this.txtWordLimit.Margin = new System.Windows.Forms.Padding(4);
            this.txtWordLimit.Name = "txtWordLimit";
            this.txtWordLimit.Size = new System.Drawing.Size(132, 25);
            this.txtWordLimit.TabIndex = 1;
            this.txtWordLimit.Text = "70";
            // 
            // RTXDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 518);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStopApp);
            this.Controls.Add(this.btnStartApp);
            this.Controls.Add(this.btnUnRegApp);
            this.Controls.Add(this.btnRegApp);
            this.Controls.Add(this.txtAppName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWordLimit);
            this.Controls.Add(this.txtAppGUID);
            this.Controls.Add(this.txtSvrPort);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSvrIP);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RTXDemoForm";
            this.Text = "RTXDemoForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSvrIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAppGUID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSvrPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Button btnRegApp;
        private System.Windows.Forms.Button btnUnRegApp;
        private System.Windows.Forms.Button btnStartApp;
        private System.Windows.Forms.Button btnStopApp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRtxToMoContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMoToRTXContent;
        private System.Windows.Forms.TextBox txtRevUIN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRevUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtWordLimit;
    }
}

