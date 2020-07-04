using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using SerialExt;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerialCom
{
    public delegate void FuncUart(string m);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ~Form1()
        {
            com.ClosePort();
            base.Dispose();
            logOpt.logSaveChecked = false;
            logOpt.Serialize("serial.dat");
        }
    
        private void FormInit()
        {
            String[] portname;
            portname = SerialPort.GetPortNames();
            dsPortName.DataSource = portname;
            dsBaudrate.SelectedIndex = 3;
            dsDataBit.SelectedIndex = 0;
            dsParity.SelectedIndex = 0;
            dsStopBit.SelectedIndex = 1;
            quikOpenLog.Text = "Click to open log";
        }

        private void CheckConfigFile(string file)
        {
            string path = Directory.GetCurrentDirectory();
            path += "\\" + file;

            if (File.Exists(path))
            {
                logOpt = LogOptionParam.Deserialize(path);
            } 
            
            if ((File.Exists(path) != true) || (Directory.Exists(logOpt.logPath) != true))
            {
                //DefaultLogOptInit();
                logOpt.DefaultInit();
                logOpt.Serialize(path);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FormInit();
            btnColor = btnOpenUart.BackColor;
            checkBoxSelectTimestamp.Checked = true;
            dsAssic.Checked = true;
            dsHex.Checked = false;
            CheckConfigFile("serial.dat");
            logOpt.logSaveChecked = false;
            checkBoxAutoSave.Checked = logOpt.logSaveChecked;
            log.Path = logOpt.logPath;
            log.Name = logOpt.logName;
            log.SaveEnable = logOpt.logSaveChecked;
            log.ExeLog = logOpt.logExe;
        }

        private void btnOpenUart_Click(object sender, EventArgs e)
        {
            OpenOrCloseSerial();
        }
        private void btnChangeOpenUartUI()
        {
            btnOpenUart.BackColor = System.Drawing.Color.FromArgb(0, 128, 255);
            btnOpenUart.Text = "关闭串口";
            btnOpenUart.ForeColor = System.Drawing.Color.White;
        }
        private void btnChangeCloseUartUI()
        {
            btnOpenUart.BackColor = btnColor;
            btnOpenUart.ForeColor = System.Drawing.Color.Black;
            btnOpenUart.Text = "打开串口";
        }
        private void OpenOrCloseSerial()
        {
            if (dsPortName.Text == string.Empty) {
                MessageBox.Show("请选择串口！");
                return;
            }
            if (com.IsOpen == false) {
                try {
                    com.ConfigPort(dsPortName.Text, int.Parse(dsBaudrate.Text),
                        int.Parse(dsDataBit.Text), int.Parse(dsStopBit.Text));
                    if (com.OpenPort()) {
                        com.AddUIAsyncHandle(DispUartData);
                        com.AddUIAsyncHandle(SaveUartData);
                        btnChangeOpenUartUI();
                    } else {
                        MessageBox.Show("串口打开失败");
                    }
                } catch(Exception e) {
                    MessageBox.Show(e.Message);
                }
            } else {
                com.ClosePort();
                com.ClearUIAsyncHandle();
                btnChangeCloseUartUI();
            }
        }

        private void DispUartData(string Data)
        {
            if (dsRecvData.InvokeRequired) {
                UIAsyncHandle func = new UIAsyncHandle(DispUartData);
                this.Invoke(func, new object[] { Data });
            } else {
                if (dsRecvData.TextLength > 256 * 1024) dsRecvData.Text = "";
                dsRecvData.AppendText(Data);
            }
        }
        
        private void SaveUartData(string data)
        {
            if (checkBoxAutoSave.InvokeRequired) {
                UIAsyncHandle func = new UIAsyncHandle(SaveUartData);
                this.Invoke(func, new object[] { data });
            } else {
                log.SaveEnable = checkBoxAutoSave.Checked;
                log.Log(data);
            }
        }

        private SelfLog log = new SelfLog();
        private void checkBoxAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            logOpt.logSaveChecked = checkBoxAutoSave.Checked;
            log.SaveEnable = logOpt.logSaveChecked;
            if (checkBoxAutoSave.Checked) {
                log.Path = logOpt.logPath;
                log.Name = logOpt.logName;
                log.UpdateNameTimestamp();
                quikOpenLog.Text = log.Path + "\\" + log.GetLogName();
            } else {
                quikOpenLog.Text = "Click to open log file";
            }

            logOpt.Serialize("serial.dat");
        }

        private void quickOpenLog_Click(object sender, EventArgs e) {
            OpenFileDialog a = new OpenFileDialog();
            a.InitialDirectory = log.Path;
            if (a.ShowDialog() == DialogResult.OK)
            {
                Process.Start(log.ExeLog, a.FileName);
            }
        }

        private Color btnColor;
        private SelfdefSerial com = new SelfdefSerial();
        private LogOptionParam logOpt = new LogOptionParam();

        private void 参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logOpt = LogOptionParam.Deserialize("serial.dat");
            if (Directory.Exists(logOpt.logPath) == false)
            {
                logOpt.DefaultInit();
            }
            SetOption optDialog = new SetOption();
            optDialog.StartPosition = FormStartPosition.CenterParent;
            optDialog.SetOptLogParam(logOpt);
            if (optDialog.ShowDialog() == DialogResult.OK)
            {
                logOpt = optDialog.GetOptLogParam();
                logOpt.Serialize("serial.dat");
                checkBoxAutoSave.Checked = logOpt.logSaveChecked;
                log.Path = logOpt.logPath;
                log.Name = logOpt.logName;
                log.SaveEnable = logOpt.logSaveChecked;
                log.ExeLog = logOpt.logExe;
                if (checkBoxAutoSave.Checked)
                {
                    log.UpdateNameTimestamp();
                    quikOpenLog.Text = log.Path + "\\" + log.GetLogName();
                }
            }
        }

        private void dsPortName_DropDown(object sender, EventArgs e)
        {
            string []portname = SelfdefSerial.GetPortNames();
            dsPortName.DataSource = portname;
        }
    }
}
