namespace SmsObj
{
    partial class LogForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lable2 = new System.Windows.Forms.Label();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.btnSearchDetail = new System.Windows.Forms.Button();
            this.btnSearchGroupDetail = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 434);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志清单查询";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchGroupDetail);
            this.panel1.Controls.Add(this.btnSearchDetail);
            this.panel1.Controls.Add(this.txtSender);
            this.panel1.Controls.Add(this.lable2);
            this.panel1.Controls.Add(this.dtpEndTime);
            this.panel1.Controls.Add(this.dtpBeginTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 63);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "时段";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(46, 15);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.Size = new System.Drawing.Size(136, 25);
            this.dtpBeginTime.TabIndex = 1;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(188, 15);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(136, 25);
            this.dtpEndTime.TabIndex = 2;
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Location = new System.Drawing.Point(330, 20);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(37, 15);
            this.lable2.TabIndex = 3;
            this.lable2.Text = "用户";
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(373, 17);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(100, 25);
            this.txtSender.TabIndex = 4;
            // 
            // btnSearchDetail
            // 
            this.btnSearchDetail.Location = new System.Drawing.Point(480, 20);
            this.btnSearchDetail.Name = "btnSearchDetail";
            this.btnSearchDetail.Size = new System.Drawing.Size(75, 23);
            this.btnSearchDetail.TabIndex = 5;
            this.btnSearchDetail.Text = "查询清单";
            this.btnSearchDetail.UseVisualStyleBackColor = true;
            // 
            // btnSearchGroupDetail
            // 
            this.btnSearchGroupDetail.Location = new System.Drawing.Point(577, 20);
            this.btnSearchGroupDetail.Name = "btnSearchGroupDetail";
            this.btnSearchGroupDetail.Size = new System.Drawing.Size(75, 23);
            this.btnSearchGroupDetail.TabIndex = 6;
            this.btnSearchGroupDetail.Text = "查询组帐单";
            this.btnSearchGroupDetail.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 347);
            this.panel2.TabIndex = 1;
            // 
            // dgvLog
            // 
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.RowTemplate.Height = 27;
            this.dgvLog.Size = new System.Drawing.Size(829, 347);
            this.dgvLog.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 434);
            this.Controls.Add(this.groupBox1);
            this.Name = "LogForm";
            this.Text = "日志清单查询";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.Button btnSearchGroupDetail;
        private System.Windows.Forms.Button btnSearchDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvLog;
    }
}