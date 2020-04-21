using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCom {
    public partial class SetOptLog : Form {
        public LogOptionParam logOpt = new LogOptionParam();
        public SetOptLog()
        {
            InitializeComponent();
            UpdateUIFromLogParameter();
        }
        public void UpdateLogParameterFromUI()
        {
            logOpt.logName = textBox_logName.Text;
            logOpt.logPath = textBox_logPath.Text;
            logOpt.logSaveChecked = checkBox_optCheckSave.Checked;
            logOpt.logMaxSize = UInt32.Parse(textBox_logSize.Text);
        }
        public void UpdateUIFromLogParameter()
        {
            textBox_logName.Text = logOpt.logName;
            textBox_logPath.Text = logOpt.logPath;
            checkBox_optCheckSave.Checked = logOpt.logSaveChecked;
            textBox_logSize.Text = logOpt.logMaxSize.ToString();
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (textBox_logPath.Text == string.Empty)
                textBox_logPath.Text = Directory.GetCurrentDirectory();

            var fd = new FolderBrowserDialog();
            fd.RootFolder = Environment.SpecialFolder.MyComputer;
            fd.SelectedPath = textBox_logPath.Text;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox_logPath.Text = fd.SelectedPath;
            }
        }
    }
    [Serializable]
    public class LogOptionParam {
        public string logName { set; get; }
        public string logPath { set; get; }
        public bool logSaveChecked { set; get; }
        public UInt32 logMaxSize { set; get; }
    }
}
