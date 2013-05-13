namespace SmsObj
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopService = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.btnCheckBalance = new System.Windows.Forms.Button();
            this.btnSearchLog = new System.Windows.Forms.Button();
            this.btnSetLimit = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnStopService);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.btnCheckBalance);
            this.groupBox1.Controls.Add(this.btnSearchLog);
            this.groupBox1.Controls.Add(this.btnSetLimit);
            this.groupBox1.Controls.Add(this.btnConfig);
            this.groupBox1.Controls.Add(this.btnStartService);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 456);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能";
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(19, 92);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(111, 36);
            this.btnStopService.TabIndex = 1;
            this.btnStopService.Text = "停  止";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(29, 373);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 19);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "开机自动启动";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(19, 403);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 36);
            this.button5.TabIndex = 7;
            this.button5.Text = "退出";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnCheckBalance
            // 
            this.btnCheckBalance.Enabled = false;
            this.btnCheckBalance.Location = new System.Drawing.Point(19, 310);
            this.btnCheckBalance.Name = "btnCheckBalance";
            this.btnCheckBalance.Size = new System.Drawing.Size(111, 36);
            this.btnCheckBalance.TabIndex = 5;
            this.btnCheckBalance.Text = "余额查询";
            this.btnCheckBalance.UseVisualStyleBackColor = true;
            this.btnCheckBalance.Click += new System.EventHandler(this.btnCheckBalance_Click);
            // 
            // btnSearchLog
            // 
            this.btnSearchLog.Location = new System.Drawing.Point(19, 254);
            this.btnSearchLog.Name = "btnSearchLog";
            this.btnSearchLog.Size = new System.Drawing.Size(111, 36);
            this.btnSearchLog.TabIndex = 4;
            this.btnSearchLog.Text = "日志查询";
            this.btnSearchLog.UseVisualStyleBackColor = true;
            this.btnSearchLog.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSetLimit
            // 
            this.btnSetLimit.Location = new System.Drawing.Point(19, 203);
            this.btnSetLimit.Name = "btnSetLimit";
            this.btnSetLimit.Size = new System.Drawing.Size(111, 36);
            this.btnSetLimit.TabIndex = 3;
            this.btnSetLimit.Text = "限额设置";
            this.btnSetLimit.UseVisualStyleBackColor = true;
            this.btnSetLimit.Click += new System.EventHandler(this.btnSetLimit_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(19, 150);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(111, 36);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "参数设置";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(19, 33);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(111, 36);
            this.btnStartService.TabIndex = 0;
            this.btnStartService.Text = "启  动";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartServices_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtLog);
            this.groupBox2.Location = new System.Drawing.Point(180, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 456);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLog.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtLog.Location = new System.Drawing.Point(10, 24);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(507, 426);
            this.txtLog.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 480);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "天朗RTX短信网关";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnCheckBalance;
        private System.Windows.Forms.Button btnSearchLog;
        private System.Windows.Forms.Button btnSetLimit;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.NotifyIcon notifyIcon1;

    }
}