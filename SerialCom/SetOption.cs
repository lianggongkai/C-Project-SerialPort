using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCom {
    public partial class SetOption : Form {
        private SetOptLog optlogform = new SetOptLog();
        public SetOption()
        {
            InitializeComponent();
            InitTab();
        }
        public void SetOptLogParam(LogOptionParam logInit)
        {
            optlogform.logOpt = logInit;
            optlogform.UpdateUIFromLogParameter();
        }
        public LogOptionParam GetOptLogParam()
        {
            return optlogform.logOpt;
        }
        private void InitTab()
        {
            tabCtrlSetOpt.TabPages.Add("日志");
            tabCtrlSetOpt.SelectTab(tabCtrlSetOpt.TabCount - 1);
            
            optlogform.TopLevel = false;
            optlogform.Dock = DockStyle.Fill;
            optlogform.StartPosition = FormStartPosition.CenterParent;
            optlogform.Show();
            optlogform.Parent = tabCtrlSetOpt.SelectedTab;
        }

        private void btnOptConfirm_Click(object sender, EventArgs e)
        {
            optlogform.UpdateLogParameterFromUI();
            this.Close();
        }

        private void btnOptCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //~SetOption()
        //{
        //    this.tabCtrlSetOpt.Dispose();
        //    base.Dispose();
        //}
    }
}
