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
            this.components = new System.ComponentModel.Container();
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
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.dsAssic = new System.Windows.Forms.RadioButton();
            this.dsHex = new System.Windows.Forms.RadioButton();
            this.gr = new System.Windows.Forms.GroupBox();
            this.checkBoxSelectTimestamp = new System.Windows.Forms.CheckBox();
            this.dsRecvData = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSave = new System.Windows.Forms.CheckBox();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.PortSet.SuspendLayout();
            this.gr.SuspendLayout();
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
            this.PortSet.Location = new System.Drawing.Point(29, 24);
            this.PortSet.Name = "PortSet";
            this.PortSet.Size = new System.Drawing.Size(194, 241);
            this.PortSet.TabIndex = 0;
            this.PortSet.TabStop = false;
            this.PortSet.Text = "串口设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(8, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "校验位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "停止位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "端   口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 26);
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
            this.dsParity.Location = new System.Drawing.Point(71, 196);
            this.dsParity.Name = "dsParity";
            this.dsParity.Size = new System.Drawing.Size(114, 28);
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
            this.dsStopBit.Location = new System.Drawing.Point(71, 154);
            this.dsStopBit.Name = "dsStopBit";
            this.dsStopBit.Size = new System.Drawing.Size(114, 28);
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
            this.dsDataBit.Location = new System.Drawing.Point(71, 112);
            this.dsDataBit.Name = "dsDataBit";
            this.dsDataBit.Size = new System.Drawing.Size(114, 28);
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
            this.dsBaudrate.Location = new System.Drawing.Point(71, 70);
            this.dsBaudrate.Name = "dsBaudrate";
            this.dsBaudrate.Size = new System.Drawing.Size(114, 28);
            this.dsBaudrate.TabIndex = 0;
            // 
            // dsPortName
            // 
            this.dsPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dsPortName.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dsPortName.FormattingEnabled = true;
            this.dsPortName.Location = new System.Drawing.Point(71, 28);
            this.dsPortName.Name = "dsPortName";
            this.dsPortName.Size = new System.Drawing.Size(114, 28);
            this.dsPortName.TabIndex = 0;
            this.dsPortName.DragDrop += new System.Windows.Forms.DragEventHandler(this.dsPortName_DragDrop);
            // 
            // btnOpenUart
            // 
            this.btnOpenUart.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenUart.Location = new System.Drawing.Point(29, 271);
            this.btnOpenUart.Name = "btnOpenUart";
            this.btnOpenUart.Size = new System.Drawing.Size(194, 44);
            this.btnOpenUart.TabIndex = 2;
            this.btnOpenUart.Text = "打开串口";
            this.btnOpenUart.UseVisualStyleBackColor = true;
            this.btnOpenUart.Click += new System.EventHandler(this.btnOpenUart_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(0, 540);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "label7";
            // 
            // dsAssic
            // 
            this.dsAssic.AutoSize = true;
            this.dsAssic.Location = new System.Drawing.Point(12, 16);
            this.dsAssic.Name = "dsAssic";
            this.dsAssic.Size = new System.Drawing.Size(68, 19);
            this.dsAssic.TabIndex = 5;
            this.dsAssic.TabStop = true;
            this.dsAssic.Text = "ASIIC";
            this.dsAssic.UseVisualStyleBackColor = true;
            // 
            // dsHex
            // 
            this.dsHex.AutoSize = true;
            this.dsHex.Location = new System.Drawing.Point(89, 16);
            this.dsHex.Name = "dsHex";
            this.dsHex.Size = new System.Drawing.Size(52, 19);
            this.dsHex.TabIndex = 5;
            this.dsHex.TabStop = true;
            this.dsHex.Text = "HEX";
            this.dsHex.UseVisualStyleBackColor = true;
            // 
            // gr
            // 
            this.gr.Controls.Add(this.dsAssic);
            this.gr.Controls.Add(this.dsHex);
            this.gr.Location = new System.Drawing.Point(31, 326);
            this.gr.Name = "gr";
            this.gr.Size = new System.Drawing.Size(157, 42);
            this.gr.TabIndex = 7;
            this.gr.TabStop = false;
            // 
            // checkBoxSelectTimestamp
            // 
            this.checkBoxSelectTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSelectTimestamp.AutoSize = true;
            this.checkBoxSelectTimestamp.Location = new System.Drawing.Point(44, 384);
            this.checkBoxSelectTimestamp.Name = "checkBoxSelectTimestamp";
            this.checkBoxSelectTimestamp.Size = new System.Drawing.Size(74, 19);
            this.checkBoxSelectTimestamp.TabIndex = 8;
            this.checkBoxSelectTimestamp.Text = "时间戳";
            this.checkBoxSelectTimestamp.UseVisualStyleBackColor = true;
            // 
            // dsRecvData
            // 
            this.dsRecvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dsRecvData.Location = new System.Drawing.Point(247, 38);
            this.dsRecvData.Multiline = true;
            this.dsRecvData.Name = "dsRecvData";
            this.dsRecvData.ReadOnly = true;
            this.dsRecvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dsRecvData.Size = new System.Drawing.Size(623, 365);
            this.dsRecvData.TabIndex = 9;
            // 
            // checkBoxAutoSave
            // 
            this.checkBoxAutoSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoSave.AutoSize = true;
            this.checkBoxAutoSave.Location = new System.Drawing.Point(124, 384);
            this.checkBoxAutoSave.Name = "checkBoxAutoSave";
            this.checkBoxAutoSave.Size = new System.Drawing.Size(83, 19);
            this.checkBoxAutoSave.TabIndex = 8;
            this.checkBoxAutoSave.Text = "存储log";
            this.checkBoxAutoSave.UseVisualStyleBackColor = true;
            this.checkBoxAutoSave.CheckedChanged += new System.EventHandler(this.checkBoxAutoSave_CheckedChanged);
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(124, 409);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(78, 34);
            this.btnOpenLog.TabIndex = 10;
            this.btnOpenLog.Text = "打开log";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 555);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.dsRecvData);
            this.Controls.Add(this.checkBoxAutoSave);
            this.Controls.Add(this.checkBoxSelectTimestamp);
            this.Controls.Add(this.gr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOpenUart);
            this.Controls.Add(this.PortSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "串口工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PortSet.ResumeLayout(false);
            this.PortSet.PerformLayout();
            this.gr.ResumeLayout(false);
            this.gr.PerformLayout();
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
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton dsAssic;
        private System.Windows.Forms.RadioButton dsHex;
        private System.Windows.Forms.GroupBox gr;
        private System.Windows.Forms.CheckBox checkBoxSelectTimestamp;
        private System.Windows.Forms.TextBox dsRecvData;
        private System.Windows.Forms.CheckBox checkBoxAutoSave;
        private System.Windows.Forms.Button btnOpenLog;
    }
}

