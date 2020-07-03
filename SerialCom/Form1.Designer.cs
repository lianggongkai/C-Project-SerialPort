namespace SerialCom
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PortSet = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dsParity = new System.Windows.Forms.ComboBox();
            this.dsStopBit = new System.Windows.Forms.ComboBox();
            this.dsDataBit = new System.Windows.Forms.ComboBox();
            this.dsBaudrate = new System.Windows.Forms.ComboBox();
            this.dsPortName = new System.Windows.Forms.ComboBox();
            this.btnOpenUart = new System.Windows.Forms.Button();
            this.dsAssic = new System.Windows.Forms.RadioButton();
            this.dsHex = new System.Windows.Forms.RadioButton();
            this.gr = new System.Windows.Forms.GroupBox();
            this.checkBoxSelectTimestamp = new System.Windows.Forms.CheckBox();
            this.dsRecvData = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSave = new System.Windows.Forms.CheckBox();
            this.quikOpenLog = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PortSet.SuspendLayout();
            this.gr.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortSet
            // 
            this.PortSet.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PortSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PortSet.Controls.Add(this.label6);
            this.PortSet.Controls.Add(this.label5);
            this.PortSet.Controls.Add(this.label4);
            this.PortSet.Controls.Add(this.label3);
            this.PortSet.Controls.Add(this.label2);
            this.PortSet.Controls.Add(this.label1);
            this.PortSet.Controls.Add(this.dsParity);
            this.PortSet.Controls.Add(this.dsStopBit);
            this.PortSet.Controls.Add(this.dsDataBit);
            this.PortSet.Controls.Add(this.dsBaudrate);
            this.PortSet.Controls.Add(this.dsPortName);
            this.PortSet.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PortSet.Location = new System.Drawing.Point(27, 50);
            this.PortSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PortSet.Name = "PortSet";
            this.PortSet.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PortSet.Size = new System.Drawing.Size(218, 289);
            this.PortSet.TabIndex = 0;
            this.PortSet.TabStop = false;
            this.PortSet.Text = "串口设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(9, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 24);
            this.label6.TabIndex = 2;
            this.label6.Text = "校验位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(9, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "停止位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(9, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "端   口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 30);
            this.label1.TabIndex = 1;
            // 
            // dsParity
            // 
            this.dsParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dsParity.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dsParity.FormattingEnabled = true;
            this.dsParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.dsParity.Location = new System.Drawing.Point(80, 235);
            this.dsParity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dsParity.Name = "dsParity";
            this.dsParity.Size = new System.Drawing.Size(128, 32);
            this.dsParity.TabIndex = 0;
            // 
            // dsStopBit
            // 
            this.dsStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dsStopBit.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dsStopBit.FormattingEnabled = true;
            this.dsStopBit.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "1.5"});
            this.dsStopBit.Location = new System.Drawing.Point(80, 185);
            this.dsStopBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dsStopBit.Name = "dsStopBit";
            this.dsStopBit.Size = new System.Drawing.Size(128, 32);
            this.dsStopBit.TabIndex = 0;
            // 
            // dsDataBit
            // 
            this.dsDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dsDataBit.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dsDataBit.FormattingEnabled = true;
            this.dsDataBit.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
            this.dsDataBit.Location = new System.Drawing.Point(80, 134);
            this.dsDataBit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dsDataBit.Name = "dsDataBit";
            this.dsDataBit.Size = new System.Drawing.Size(128, 32);
            this.dsDataBit.TabIndex = 0;
            // 
            // dsBaudrate
            // 
            this.dsBaudrate.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dsBaudrate.FormattingEnabled = true;
            this.dsBaudrate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "115200",
            "3000000"});
            this.dsBaudrate.Location = new System.Drawing.Point(80, 84);
            this.dsBaudrate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dsBaudrate.Name = "dsBaudrate";
            this.dsBaudrate.Size = new System.Drawing.Size(128, 32);
            this.dsBaudrate.TabIndex = 0;
            // 
            // dsPortName
            // 
            this.dsPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dsPortName.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dsPortName.FormattingEnabled = true;
            this.dsPortName.Location = new System.Drawing.Point(80, 34);
            this.dsPortName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dsPortName.Name = "dsPortName";
            this.dsPortName.Size = new System.Drawing.Size(128, 32);
            this.dsPortName.TabIndex = 0;
         
            // 
            // btnOpenUart
            // 
            this.btnOpenUart.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenUart.Location = new System.Drawing.Point(27, 347);
            this.btnOpenUart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenUart.Name = "btnOpenUart";
            this.btnOpenUart.Size = new System.Drawing.Size(218, 53);
            this.btnOpenUart.TabIndex = 2;
            this.btnOpenUart.Text = "打开串口";
            this.btnOpenUart.UseVisualStyleBackColor = true;
            this.btnOpenUart.Click += new System.EventHandler(this.btnOpenUart_Click);
            // 
            // dsAssic
            // 
            this.dsAssic.AutoSize = true;
            this.dsAssic.Location = new System.Drawing.Point(14, 19);
            this.dsAssic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dsAssic.Name = "dsAssic";
            this.dsAssic.Size = new System.Drawing.Size(78, 22);
            this.dsAssic.TabIndex = 5;
            this.dsAssic.TabStop = true;
            this.dsAssic.Text = "ASIIC";
            this.dsAssic.UseVisualStyleBackColor = true;
            // 
            // dsHex
            // 
            this.dsHex.AutoSize = true;
            this.dsHex.Location = new System.Drawing.Point(100, 19);
            this.dsHex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dsHex.Name = "dsHex";
            this.dsHex.Size = new System.Drawing.Size(60, 22);
            this.dsHex.TabIndex = 5;
            this.dsHex.TabStop = true;
            this.dsHex.Text = "HEX";
            this.dsHex.UseVisualStyleBackColor = true;
            // 
            // gr
            // 
            this.gr.Controls.Add(this.dsAssic);
            this.gr.Controls.Add(this.dsHex);
            this.gr.Location = new System.Drawing.Point(29, 413);
            this.gr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gr.Name = "gr";
            this.gr.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gr.Size = new System.Drawing.Size(177, 50);
            this.gr.TabIndex = 7;
            this.gr.TabStop = false;
            // 
            // checkBoxSelectTimestamp
            // 
            this.checkBoxSelectTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSelectTimestamp.AutoSize = true;
            this.checkBoxSelectTimestamp.Location = new System.Drawing.Point(44, 482);
            this.checkBoxSelectTimestamp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxSelectTimestamp.Name = "checkBoxSelectTimestamp";
            this.checkBoxSelectTimestamp.Size = new System.Drawing.Size(88, 22);
            this.checkBoxSelectTimestamp.TabIndex = 8;
            this.checkBoxSelectTimestamp.Text = "时间戳";
            this.checkBoxSelectTimestamp.UseVisualStyleBackColor = true;
            // 
            // dsRecvData
            // 
            this.dsRecvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dsRecvData.Location = new System.Drawing.Point(272, 67);
            this.dsRecvData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dsRecvData.Multiline = true;
            this.dsRecvData.Name = "dsRecvData";
            this.dsRecvData.ReadOnly = true;
            this.dsRecvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dsRecvData.Size = new System.Drawing.Size(1150, 675);
            this.dsRecvData.TabIndex = 9;
            // 
            // checkBoxAutoSave
            // 
            this.checkBoxAutoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoSave.AutoSize = true;
            this.checkBoxAutoSave.Location = new System.Drawing.Point(134, 482);
            this.checkBoxAutoSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxAutoSave.Name = "checkBoxAutoSave";
            this.checkBoxAutoSave.Size = new System.Drawing.Size(97, 22);
            this.checkBoxAutoSave.TabIndex = 8;
            this.checkBoxAutoSave.Text = "存储log";
            this.checkBoxAutoSave.UseVisualStyleBackColor = true;
            this.checkBoxAutoSave.CheckedChanged += new System.EventHandler(this.checkBoxAutoSave_CheckedChanged);
            // 
            // quikOpenLog
            // 
            this.quikOpenLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.quikOpenLog.AutoSize = true;
            this.quikOpenLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quikOpenLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quikOpenLog.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quikOpenLog.Location = new System.Drawing.Point(14, 866);
            this.quikOpenLog.Name = "quikOpenLog";
            this.quikOpenLog.Size = new System.Drawing.Size(156, 26);
            this.quikOpenLog.TabIndex = 11;
            this.quikOpenLog.Text = "quickOpenLog";
            this.quikOpenLog.Click += new System.EventHandler(this.quickOpenLog_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.设置ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1442, 32);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.设置ToolStripMenuItem.Text = "文件";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 设置ToolStripMenuItem1
            // 
            this.设置ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.参数ToolStripMenuItem});
            this.设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            this.设置ToolStripMenuItem1.Size = new System.Drawing.Size(58, 28);
            this.设置ToolStripMenuItem1.Text = "设置";
            // 
            // 参数ToolStripMenuItem
            // 
            this.参数ToolStripMenuItem.Name = "参数ToolStripMenuItem";
            this.参数ToolStripMenuItem.Size = new System.Drawing.Size(128, 30);
            this.参数ToolStripMenuItem.Text = "选项";
            this.参数ToolStripMenuItem.Click += new System.EventHandler(this.参数ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 904);
            this.Controls.Add(this.quikOpenLog);
            this.Controls.Add(this.dsRecvData);
            this.Controls.Add(this.checkBoxAutoSave);
            this.Controls.Add(this.checkBoxSelectTimestamp);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.btnOpenUart);
            this.Controls.Add(this.PortSet);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "串口工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PortSet.ResumeLayout(false);
            this.PortSet.PerformLayout();
            this.gr.ResumeLayout(false);
            this.gr.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PortSet;
        private System.Windows.Forms.ComboBox dsParity;
        private System.Windows.Forms.ComboBox dsStopBit;
        private System.Windows.Forms.ComboBox dsDataBit;
        private System.Windows.Forms.ComboBox dsBaudrate;
        private System.Windows.Forms.ComboBox dsPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenUart;
        private System.Windows.Forms.RadioButton dsAssic;
        private System.Windows.Forms.RadioButton dsHex;
        private System.Windows.Forms.GroupBox gr;
        private System.Windows.Forms.CheckBox checkBoxSelectTimestamp;
        private System.Windows.Forms.TextBox dsRecvData;
        private System.Windows.Forms.CheckBox checkBoxAutoSave;
        private System.Windows.Forms.Label quikOpenLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 参数ToolStripMenuItem;
    }
}

