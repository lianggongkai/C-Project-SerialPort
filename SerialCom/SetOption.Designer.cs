namespace SerialCom {
    partial class SetOption {
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
            this.tabCtrlSetOpt = new System.Windows.Forms.TabControl();
            this.btnOptConfirm = new System.Windows.Forms.Button();
            this.btnOptCancel = new System.Windows.Forms.Button();
            this.btnOptApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabCtrlSetOpt
            // 
            this.tabCtrlSetOpt.Location = new System.Drawing.Point(15, 12);
            this.tabCtrlSetOpt.Name = "tabCtrlSetOpt";
            this.tabCtrlSetOpt.SelectedIndex = 0;
            this.tabCtrlSetOpt.Size = new System.Drawing.Size(550, 342);
            this.tabCtrlSetOpt.TabIndex = 0;
            // 
            // btnOptConfirm
            // 
            this.btnOptConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOptConfirm.Location = new System.Drawing.Point(120, 363);
            this.btnOptConfirm.Name = "btnOptConfirm";
            this.btnOptConfirm.Size = new System.Drawing.Size(75, 31);
            this.btnOptConfirm.TabIndex = 1;
            this.btnOptConfirm.Text = "OK";
            this.btnOptConfirm.UseVisualStyleBackColor = true;
            this.btnOptConfirm.Click += new System.EventHandler(this.btnOptConfirm_Click);
            // 
            // btnOptCancel
            // 
            this.btnOptCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOptCancel.Location = new System.Drawing.Point(257, 363);
            this.btnOptCancel.Name = "btnOptCancel";
            this.btnOptCancel.Size = new System.Drawing.Size(75, 31);
            this.btnOptCancel.TabIndex = 1;
            this.btnOptCancel.Text = "Cancel";
            this.btnOptCancel.UseVisualStyleBackColor = true;
            this.btnOptCancel.Click += new System.EventHandler(this.btnOptCancel_Click);
            // 
            // btnOptApply
            // 
            this.btnOptApply.Location = new System.Drawing.Point(394, 363);
            this.btnOptApply.Name = "btnOptApply";
            this.btnOptApply.Size = new System.Drawing.Size(75, 31);
            this.btnOptApply.TabIndex = 1;
            this.btnOptApply.Text = "Apply";
            this.btnOptApply.UseVisualStyleBackColor = true;
            // 
            // SetOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 403);
            this.Controls.Add(this.btnOptApply);
            this.Controls.Add(this.btnOptCancel);
            this.Controls.Add(this.btnOptConfirm);
            this.Controls.Add(this.tabCtrlSetOpt);
            this.Name = "SetOption";
            this.Text = "SetOption";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlSetOpt;
        private System.Windows.Forms.Button btnOptConfirm;
        private System.Windows.Forms.Button btnOptCancel;
        private System.Windows.Forms.Button btnOptApply;
    }
}