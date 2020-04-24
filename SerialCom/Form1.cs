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
            sp = new SerialPort();
            InitializeComponent();
        }
        ~Form1()
        {
            CloseSerialPort();
            com.ClosePort();
            base.Dispose();
            logOpt.logSaveChecked = false;
            SerialConfig("serial.dat", sp, logOpt);
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
            quikOpenLog.Text = "no file";
            //UartExtConfig();
        }
        private void StartUIAsyncHandle(string data)
        {
            try
            {
                InvokeRes = BeginInvoke((EventHandler)(delegate {
                    DispUartData(data);
                    SaveUartData(data);
                }));
            } catch (Exception ex) {
                throw (ex);
            }
        }
        private void StopUIAsyncHandle(string data)
        {
            if (InvokeRes != null)
                EndInvoke(InvokeRes);
        }
        private void CheckConfigFile(string file)
        {
            string path = Directory.GetCurrentDirectory();
            path += "\\" + file;
            bool res1 = File.Exists(path);
            bool res2 = DeserizeConfig(file, sp, logOpt);
            if ((File.Exists(path) != true) || (DeserizeConfig(file, sp, logOpt) != true))
            {
                DefaultLogOptInit();
                this.SerialConfig(file, sp, logOpt);
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
            log.Name = logOpt.logName;//log.GetLogName();
            log.SaveEnable = logOpt.logSaveChecked;
            log.ExeLog = logOpt.logExe;
        }

        public bool UpdateSerialPortParameter(string portName, int boudRate = 115200, int dataBit = 8, 
            int stopBit = 1, int timeOut = 5000)
        {
            if (portName == string.Empty) return false;
            sp.PortName = portName;
            sp.BaudRate = boudRate;
            sp.DataBits = dataBit;
            sp.StopBits = (StopBits)stopBit;
            sp.ReadTimeout = timeOut;
            sp.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            try {
                sp.Open();
                if (sp.IsOpen) return true;
            } catch(Exception e) {
                throw e;
            }
            
            return false;
        }

        private void CloseSerialPort()
        {
            StopUIAsyncHandle("");
            sp.DataReceived -= SerialPort_DataReceived;
            try {
                sp.Close();
                sp.Dispose();
            } catch(Exception e) {
                throw e;
            }
        }
        private SerialPort GetUartConfig()
        {
            if (dsPortName.Text == string.Empty)
            {
                return null;
            }
            SerialPort port = new SerialPort();
            port.PortName = dsPortName.Text;
            port.BaudRate = int.Parse(dsBaudrate.Text);
            port.DataBits = int.Parse(dsDataBit.Text);
            port.ReadTimeout = 5000;
            port.WriteTimeout = 1000;
            
            switch (dsParity.Text)
            {
                case "None":
                    port.Parity = Parity.None;
                    break;
                case "Odd":
                    port.Parity = Parity.Odd;
                    break;
                case "Even":
                    port.Parity = Parity.Even;
                    break;
                default:
                    break;
            }
            switch (dsStopBit.Text)
            {
                case "0":
                    port.StopBits = StopBits.None;
                    break;
                case "1":
                    port.StopBits = StopBits.One;
                    break;       
                case "2":
                    port.StopBits = StopBits.Two;
                    break;     
                case "1.5":
                    port.StopBits = StopBits.OnePointFive;
                    break;
                default:break;
            }
            
            return port;
        }
        private void UartExtConfig()
        {
            //com.autoSave = checkBoxAutoSave.Checked;
            com.savePath = System.IO.Directory.GetCurrentDirectory() + @"\SerialLog";
            com.saveName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            if (Directory.Exists(com.savePath) == false)
            {
                try {
                    Directory.CreateDirectory(com.savePath);
                } catch(Exception ex) {
                    throw ex;
                } 
            }
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
            if (sp.IsOpen == false) {
                try {
                    if (UpdateSerialPortParameter(dsPortName.Text, int.Parse(dsBaudrate.Text),
                        int.Parse(dsDataBit.Text), int.Parse(dsStopBit.Text)) == true) {
                        btnChangeOpenUartUI();
                    } else {
                        MessageBox.Show("串口打开失败");
                    }
                } catch(Exception e) {
                    MessageBox.Show(e.Message);
                }
            } else {
                CloseSerialPort();
                btnChangeCloseUartUI();
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bool isRowComplete = false;
            try {
                byte[] tmp = new byte[sp.BytesToRead+10];
                int cnt = sp.Read(tmp, 0, tmp.Length);
                if (cnt == 0) return;
                foreach (var item in tmp) {
                    if (item == 0x0d) {
                        isRowComplete = true;
                    }
                }
                if (cnt + rcvRowBytes <= buffer.Length) {
                    tmp.CopyTo(buffer, rcvRowBytes);
                }

                rcvRowBytes += cnt;
                rcvBytes += (UInt32)cnt;
                if (isRowComplete)
                {
                    string str = "";
                    if (dsAssic.Checked == true) {
                        sp.Encoding = Encoding.ASCII;
                        str = sp.Encoding.GetString(buffer, 0, rcvRowBytes);
                        //str = EncodingType.GetString(buffer, 0, rcvRowBytes);
                    } else {
                        int i = 0;
                        foreach (var item1 in buffer) {
                            if (i++ >= rcvRowBytes) break;
                            str += item1.ToString("X2") + " ";
                        }
                        str += "\n";
                    }
                    string time = "";
                    string disp = "";
                    if (checkBoxSelectTimestamp.Checked) {
                        time = $"[{DateTime.Now.ToString("HH:mm:ss.fff")}]: ";
                    }
                    disp = time + str;
                    StartUIAsyncHandle(disp);
                    rcvRowBytes = 0;
                    Array.Clear(buffer, 0, buffer.Length);
                }
            } catch(Exception ex) {
                string disp = ex.GetType().Name + ", " + ex.Message;
                MessageBox.Show(disp);
                //throw ex;
            }
        }

        private void dsPortName_DragDrop(object sender, DragEventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            dsPortName.DataSource = ports;
        }

        private void DispUartData(string Data)
        {
            if (dsRecvData.TextLength > 256 * 1024) dsRecvData.Text = "";
            dsRecvData.AppendText(Data);
        }
        
        private void SaveUartData(string data)
        {  
            if (checkBoxAutoSave.Checked) log.Log(data);
        }
        private SelfLog log = new SelfLog();
        private void checkBoxAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            //UartExtConfig();
            logOpt.logSaveChecked = checkBoxAutoSave.Checked;
            log.SaveEnable = logOpt.logSaveChecked;
            if (checkBoxAutoSave.Checked) {
                //saveFileName.Text = com.savePath + "\\" + com.PortName + "-" + com.saveName + ".txt";
                log.Path = logOpt.logPath;
                log.Name = logOpt.logName;
                log.UpdateNameTimestamp();
                quikOpenLog.Text = log.Path + "\\" + log.GetLogName();
                
            } else {
                quikOpenLog.Text = "Click to open log file";
            }
            SerialConfig("serial.dat", sp, logOpt);
        }

        private void quickOpenLog_Click(object sender, EventArgs e) {
            OpenFileDialog a = new OpenFileDialog();
            a.InitialDirectory = log.Path;
            if (a.ShowDialog() == DialogResult.OK)
            {
                Process.Start(log.ExeLog, a.FileName);
            }
        }

        private SerialPort sp;
        private Color btnColor;
        private byte[] buffer = new byte[4096];
        private UInt32 rcvBytes;
        private int rcvRowBytes;
        private SelfdefSerial com = new SelfdefSerial();
        private IAsyncResult InvokeRes;
        private LogOptionParam logOpt = new LogOptionParam();
        private void DefaultLogOptInit()
        {
            logOpt.logMaxSize = 256;
            logOpt.logName = "SerialCom";
            logOpt.logPath = Directory.GetCurrentDirectory();
            logOpt.logSaveChecked = false;
            logOpt.logExe = "notepad.exe";
        }

        private void SerialConfig(string path, SerialPort sp, LogOptionParam log)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                //bf.Serialize(fs, sp);
                bf.Serialize(fs, log);
                fs.Flush();
                fs.Close();
            }
        }
        private bool DeserizeConfig(string path, SerialPort sp, LogOptionParam log)
        {
            bool res = true; 
            BinaryFormatter bf = new BinaryFormatter();
            try { 
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    //sp = bf.Deserialize(fs) as SerialPort;
                    var ss = bf.Deserialize(fs);
                    if (ss != null)
                    {
                        logOpt = (LogOptionParam)(ss);
                    }
                    fs.Close();
                    //return res;
                }
                
            } catch (Exception ex) {
                res = false;
            }
            /* check log path */
            res = Directory.Exists(logOpt.logPath);
            return res;
        }

        private void 参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DeserizeConfig("serial.dat", sp, logOpt) == false)
            {
                this.DefaultLogOptInit();
            }
            SetOption optDialog = new SetOption();
            optDialog.StartPosition = FormStartPosition.CenterParent;
            optDialog.SetOptLogParam(logOpt);
            if (optDialog.ShowDialog() == DialogResult.OK)
            {
                logOpt = optDialog.GetOptLogParam();
                SerialConfig("serial.dat", sp, logOpt);
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
    }
}
