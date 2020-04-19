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

namespace SerialCom
{
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
            saveFileName.Text = "no file";
            UartExtConfig();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FormInit();
            btnColor = btnOpenUart.BackColor;
            //label7.Text = "No port open";
            checkBoxSelectTimestamp.Checked = true;
            dsAssic.Checked = true;
            dsHex.Checked = false;
            if (portState == false)
            {
                btnOpenUart.BackColor = btnColor;
                btnOpenUart.Text = "打开串口";
                btnOpenUart.ForeColor = System.Drawing.Color.Black;
            } else
            {
                btnOpenUart.BackColor = System.Drawing.Color.Cyan;
                btnOpenUart.Text = "关闭串口";
                btnOpenUart.ForeColor = System.Drawing.Color.White;
            }
        }

        public bool UpdateSerialPortParameter(string portName, int boudRate = 115200, int dataBit = 8, 
            int stopBit = 1, int timeOut = 5000)
        {
            if (portName == string.Empty)
            {
                return false;
            }
            try
            {
                sp.PortName = portName;
                sp.BaudRate = boudRate;
                sp.DataBits = dataBit;
                sp.StopBits = (StopBits)stopBit;
                sp.ReadTimeout = timeOut;
                sp.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                sp.Open();
                if (sp.IsOpen) return true;
            } catch(Exception e) {
                throw e;
            }
            
            return false;
        }

        private void CloseSerialPort()
        {
            isClosing = true;
            sp.DataReceived -= SerialPort_DataReceived;
            try
            {
                /*while (serialBusy)
                {
                    Application.DoEvents();
                }*/
                sp.Close();
            }
            catch(Exception e)
            {
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
            com.autoSave = true;
            com.savePath = System.IO.Directory.GetCurrentDirectory() + @"\SerialLog";
            com.saveName = DateTime.Now.ToString("yy-MM-dd_HH-mm");
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
        private void OpenOrCloseSerial()
        {
            //label7.Text = dsPortName.Text + " " + dsBaudrate.Text + " " + dsDataBit.Text + " " 
             //   + dsStopBit.Text + " " + dsParity.Text;
            if (dsPortName.Text == string.Empty)
            {
                MessageBox.Show("请选择串口！");
                return;
            }
            if (portState == false)
            {
                //label7.Text = dsPortName.Text + " " + dsBaudrate.Text + " " + dsDataBit.Text + " "
                //+ dsStopBit.Text + " " + dsParity.Text;
                try
                {
                    if (UpdateSerialPortParameter(dsPortName.Text, int.Parse(dsBaudrate.Text),
                    int.Parse(dsDataBit.Text), int.Parse(dsStopBit.Text)) == true)
                    {
                        portState = true;
                        btnOpenUart.BackColor = System.Drawing.Color.FromArgb(0, 128, 255);
                        btnOpenUart.Text = "关闭串口";
                        btnOpenUart.ForeColor = System.Drawing.Color.White;
                        isClosing = false;
                    } else {
                        MessageBox.Show("串口打开失败");
                    }
                } catch(Exception e) {
                    MessageBox.Show(e.Message);
                }
            } else {
                //label7.Text = "Port Closed";
                CloseSerialPort();
                portState = false;
                btnOpenUart.BackColor = btnColor;
                btnOpenUart.ForeColor = System.Drawing.Color.Black;
                btnOpenUart.Text = "打开串口";
            }
        }

        

        private string UartDataToSting(byte[] data)
        {
            string val = "";
            if (data != null)
            {
                val = EncodingType.GetString(data, 0, data.Length);
            }
            return val;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isClosing == true)
            {
                serialBusy = false;
                return;
            }
            serialBusy = true;
            bool isRowComplete = false;
            try {
                byte[] tmp = new byte[sp.BytesToRead+10];
                int cnt = sp.Read(tmp, 0, tmp.Length);
                if (cnt == 0) goto exit;
                foreach (var item in tmp)
                {
                    if (item == 0x0d)
                    {
                        isRowComplete = true;
                    }
                }
                if (cnt + rcvRowBytes <= buffer.Length)
                {
                    tmp.CopyTo(buffer, rcvRowBytes);
                }

                rcvRowBytes += cnt;
                rcvBytes += (UInt32)cnt;
                if (isRowComplete)
                {
                    string str = "";
                    if (dsAssic.Checked == true)
                    {
                        EncodingType = Encoding.ASCII;
                        str = EncodingType.GetString(buffer, 0, rcvRowBytes);
                    }
                    else
                    {
                        int i = 0;
                        foreach (var item1 in buffer)
                        {
                            if (i++ >= rcvRowBytes) break;
                            str += item1.ToString("X2") + " ";
                        }
                        str += "\n";
                    }
                    string time = "";
                    string disp = "";
                    if (checkBoxSelectTimestamp.Checked)
                    {
                        time = $"[{DateTime.Now.ToString("HH:mm:ss.fff")}]: ";
                    }
                    disp = time + str;
                    BeginInvoke((EventHandler)(delegate { 
                        DispUartData(disp);
                        SaveUartData(disp);
                    }));
                    rcvRowBytes = 0;
                    Array.Clear(buffer, 0, buffer.Length);
                }
            } catch(Exception ex) {
                string disp = ex.GetType().Name + ", " + ex.Message;
                MessageBox.Show(disp);
                throw ex;
            }
 exit:
            serialBusy = false;
            isClosing = false;
        }

        private void dsPortName_DragDrop(object sender, DragEventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            dsPortName.DataSource = ports;
        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            com.autoSave = true;
            //com.savePath = @"K:\BaiduNetdiskDownload\SerialCom-Enhance\SerialCom";
            //com.savePath = System.IO.Directory.GetCurrentDirectory();
            
            OpenFileDialog a = new OpenFileDialog();
            a.InitialDirectory = com.savePath;
            
            if (a.ShowDialog() == DialogResult.OK)
            {
                Process.Start(@"C:\Program Files\Notepad++\notepad++.exe", a.FileName);
            }
        }
        private void DispUartData(string Data)
        {
            dsRecvData.AppendText(Data);
            //dsRecvData.SelectionStart = dsRecvData.Text.Length;
            //dsRecvData.ScrollToCaret();
        }
        private void SaveUartData(string data)
        {
            
            if (checkBoxAutoSave.Checked)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(com.savePath + "\\" + com.PortName + "-" + com.saveName + ".txt", true, Encoding.ASCII);
                    if (writer != null)
                    {
                        writer.Write(data);
                        writer.Flush();
                        writer.Close();
                    } else
                    {
                        Exception ex = new Exception("write file failed");
                        throw (ex);
                    }
                } catch (Exception ex)
                { 
                    throw (ex);
                }
                
            }
        }

        private void checkBoxAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            UartExtConfig();
            if (checkBoxAutoSave.Checked)
            {
                saveFileName.Text = com.savePath + "\\" + com.PortName + "-" + com.saveName + ".txt";
            } else
            {
                saveFileName.Text = "Click to open log file";
            }
           
        }

        private void saveFileName_Click(object sender, EventArgs e)
        {
            com.autoSave = true;
            //com.savePath = @"K:\BaiduNetdiskDownload\SerialCom-Enhance\SerialCom";
            //com.savePath = System.IO.Directory.GetCurrentDirectory();

            OpenFileDialog a = new OpenFileDialog();
            a.InitialDirectory = com.savePath;

            if (a.ShowDialog() == DialogResult.OK)
            {
                Process.Start(@"C:\Program Files\Notepad++\notepad++.exe", a.FileName);
            }
        }
        public Encoding EncodingType { get; set; } = Encoding.ASCII;
        private Boolean portState = false;
        private Boolean serialBusy = false;
        private Boolean isClosing = false;
        private SerialPort sp;
        private Color btnColor;
        private byte[] buffer = new byte[1024];
        private UInt32 rcvBytes;
        private int rcvRowBytes;
        private SelfdefSerial com = new SelfdefSerial();
        private string saveFileFullPath;
    }
}
