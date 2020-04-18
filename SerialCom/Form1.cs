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
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FormInit();
            btnColor = btnOpenUart.BackColor;
            label7.Text = "No port open";
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
                if (sp.IsOpen == true) return true;
                
            }
            catch(Exception e)
            {
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

                while (serialBusy)
                {
                    Application.DoEvents();
                }
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
            port.DataReceived += Port_DataReceived;
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

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnOpenUart_Click(object sender, EventArgs e)
        {
            button1_Click();
        }
        private void button1_Click()
        {
            label7.Text = dsPortName.Text + " " + dsBaudrate.Text + " " + dsDataBit.Text + " " 
                + dsStopBit.Text + " " + dsParity.Text;
            if (dsPortName.Text == string.Empty)
            {
                MessageBox.Show("请选择串口！");
                return;
            }
            if (portState == false)
            {
                label7.Text = dsPortName.Text + " " + dsBaudrate.Text + " " + dsDataBit.Text + " "
                + dsStopBit.Text + " " + dsParity.Text;
                if (UpdateSerialPortParameter(dsPortName.Text, int.Parse(dsBaudrate.Text), 
                    int.Parse(dsDataBit.Text), int.Parse(dsStopBit.Text)) == true)
                {
                    portState = true;
                    btnOpenUart.BackColor = System.Drawing.Color.Blue;
                    btnOpenUart.Text = "关闭串口";
                    btnOpenUart.ForeColor = System.Drawing.Color.White;
                    isClosing = false;
                } else
                {
                    MessageBox.Show("串口打开失败");
                } 
            } else {
                label7.Text = "Port Closed";
                CloseSerialPort();
                portState = false;
                btnOpenUart.BackColor = btnColor;
                btnOpenUart.ForeColor = System.Drawing.Color.Black;
                btnOpenUart.Text = "打开串口";
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
        private MySerial com = new MySerial();
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isClosing == true)
            {
                serialBusy = false;
                return;
            }
            serialBusy = true;
            bool isRowComplete = false;
            try
            {
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
                if (isRowComplete)
                {
                    string str = "";
                    if (dsAssic.Checked == true)
                    {
                        EncodingType = Encoding.ASCII;
                        str = EncodingType.GetString(buffer);
                    }
                    else
                    {
                        int i = 0;
                        foreach (var item1 in buffer)
                        {
                            if (i++ >= rcvRowBytes) break;
                            str += item1.ToString("X2") + " ";
                        }
                    }

                    string time = DateTime.Now.ToString("HH:mm:ss.fff");
                    Invoke((EventHandler)(delegate
                    {
                        if (checkBoxSelectTimestamp.Checked == true)
                        {
                            dsRecvData.AppendText($"[{time}] {str}\n");
                        }
                        else
                        {
                            dsRecvData.AppendText($"{str}");
                        }
                    }
                    ));
                    rcvRowBytes = 0;
                    Array.Clear(buffer, 0, buffer.Length);
                }
                
                /*Invoke((EventHandler)(delegate
                {
                    if (checkBoxSelectTimestamp.Checked == true) {
                        dsRecvData.AppendText($"[{time}] {str}\n");
                    } else {
                        dsRecvData.AppendText($"{str}");
                    } 
                }
                ));*/
            } 
            catch(Exception ex)
            {
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
            com.savePath = @"K:\BaiduNetdiskDownload\SerialCom-Enhance\SerialCom";
            com.saveName = DateTime.Now.ToString("yy-mm-dd_hh-mm.txt");
        }
        private void DispUartData(string Data)
        {
            dsRecvData.Text += Data;
        }
        private void SaveUartData(string data)
        {
            StreamWriter writer = new StreamWriter(com.savePath + com.saveName, true, Encoding.ASCII);
            if (writer != null)
            {
                writer.WriteLine(data);
                writer.Close();
            }
        }
    }
    public delegate void UartDataHandleFunc(string data);
    class MySerial : SerialPort
    {
        private byte[] buffer = new byte[4096];
        private UartDataHandleFunc dispUartFunc;
        private UartDataHandleFunc saveUartFunc;
        public bool autoSave { get; set; }
        public bool addTs { get; set; }
        public string saveName { get; set; }
        public string savePath { get; set; }
        public string tsFormat { get; set; }
        public bool OpenPort()
        {
            this.DataReceived += Uart_DataReceived;
            if (this.IsOpen == false)
            {
                this.Open();
                if (this.IsOpen)
                {
                    return true;
                }
            }
            return false;
        }
        public void ConfigPort(MySerial port)
        {
            this.BaudRate = port.BaudRate;
            this.Parity = port.Parity;
            this.PortName = port.PortName;
            this.DataBits = port.DataBits;
            this.StopBits = port.StopBits;
            this.ReadTimeout = port.ReadTimeout;
            this.WriteTimeout = port.WriteTimeout;
        }
        public void setUartDataHandleFunc(UartDataHandleFunc func) {
            dispUartFunc = new UartDataHandleFunc(func);
        }
        public void setSaveDataHandleFunc(UartDataHandleFunc func)
        {
            saveUartFunc = new UartDataHandleFunc(func);
        }
        private void Uart_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[this.BytesToRead];
            if (this.Read(buffer, 0, buffer.Length) == 0)
            {
                return;
            }

            //string str = GetString(buffer);
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            dispUartFunc?.Invoke("this is a test");
            saveUartFunc?.Invoke("this is a test");
        }
        public bool ClosePort()
        {
            return false;
        }
    }
}
