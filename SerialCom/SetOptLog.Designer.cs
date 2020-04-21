namespace SerialCom {
    partial class SetOptLog {
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
            this.textBox_logName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_optCheckSave = new System.Windows.Forms.CheckBox();
            this.textBox_logPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_logSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_logName
            // 
            this.textBox_logName.Location = new System.Drawing.Point(105, 65);
            this.textBox_logName.Name = "textBox_logName";
            this.textBox_logName.Size = new System.Drawing.Size(378, 25);
            this.textBox_logName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "日志名称:";
            // 
            // checkBox_optCheckSave
            // 
            this.checkBox_optCheckSave.AutoSize = true;
            this.checkBox_optCheckSave.Location = new System.Drawing.Point(25, 32);
            this.checkBox_optCheckSave.Name = "checkBox_optCheckSave";
            this.checkBox_optCheckSave.Size = new System.Drawing.Size(89, 19);
            this.checkBox_optCheckSave.TabIndex = 2;
            this.checkBox_optCheckSave.Text = "保存日志";
            this.checkBox_optCheckSave.UseVisualStyleBackColor = true;
            // 
            // textBox_logPath
            // 
            this.textBox_logPath.Location = new System.Drawing.Point(105, 101);
            this.textBox_logPath.Name = "textBox_logPath";
            this.textBox_logPath.Size = new System.Drawing.Size(378, 25);
            this.textBox_logPath.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "存储路径:";
            // 
            // textBox_logSize
            // 
            this.textBox_logSize.Location = new System.Drawing.Point(105, 137);
            this.textBox_logSize.Name = "textBox_logSize";
            this.textBox_logSize.Size = new System.Drawing.Size(378, 25);
            this.textBox_logSize.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "日志上限:";
            // 
            // open
            // 
            this.open.BackgroundImage = global::SerialCom.Properties.Resources.文件blue;
            this.open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.open.Location = new System.Drawing.Point(489, 95);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(37, 35);
            this.open.TabIndex = 3;
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // SetOptLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 350);
            this.Controls.Add(this.open);
            this.Controls.Add(this.checkBox_optCheckSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_logSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_logPath);
            this.Controls.Add(this.textBox_logName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetOptLog";
            this.Text = "SetOptLog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_logName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_optCheckSave;
        private System.Windows.Forms.TextBox textBox_logPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_logSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button open;
    }
}