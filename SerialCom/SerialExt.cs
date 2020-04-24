using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialExt {
    [Serializable]
    class SelfLog {
        public string Path { set; get; }       /* log path */
        public string Name { set; get; }       /* log name */
        private string Timestamp;               /* log name timestamp */
        public bool SaveEnable { set; get; }    /* save log enable */
        public bool tsNameEnable { set; get; }  /* log file name add timestamp enable */
        public string ExeLog { set; get; }      /* excute open log program */
        private UInt32 maxSize = 256;           /* log max size, unit:(MB)*/
        private UInt16 sameCnt;
        
        private void CheckLogPath()
        {
            if (System.IO.Directory.Exists(Path) == false)
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Path);
                } catch (Exception ex)
                {
                    Path = Directory.GetCurrentDirectory();
                    //throw ex;
                }
            }
        }
       
        public void DefaultConfig()
        {
            Path = System.IO.Directory.GetCurrentDirectory() + @"\Log";
            Name = "SerialLog";
            SaveEnable = false;
            tsNameEnable = true;
            ExeLog = "";
            sameCnt = 0;
        }
        public void SetFileName(string filename)
        {
            if ((filename != null) && (filename != this.Name))
            {
                this.Name = filename;
                this.sameCnt = 0;
            }
        }

        /* when open save log action excute this */
        public void UpdateNameTimestamp()
        {
            this.Timestamp = "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            /*if (this.tsNameEnable)
            {
                this.Timestamp = "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            } else {
                this.Timestamp = "_" + sameCnt.ToString("#000");
            } */
            CheckLogPath();
        }
        public string GetLogName()
        {
            //UpdateNameTimestamp();
            return this.Name + this.Timestamp + ".txt";
        }
        /* record log string to file */
        public void Log(string logStr)
        {
            if (SaveEnable == false) return;
            
            try
            {
                string file = GetLogName();
                string filename = this.Path + @"\" + file;
                if (File.Exists(filename) != false)
                {

                }
                StreamWriter writer = new StreamWriter(filename, true, Encoding.ASCII);
                FileInfo fileinfo = new FileInfo(filename);
                if (fileinfo.Length / (1024*1024) >= this.maxSize)
                {
                    UpdateNameTimestamp();
                }
                if (writer != null)
                {
                    writer.Write(logStr);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public delegate void UIAsyncHandle(string data);
    [Serializable]
    class SelfdefSerial : SerialPort {
        private byte[] buffer = new byte[1024];
        private UIAsyncHandle startUIAsyncHandle;
        private UIAsyncHandle stopUIAsyncHandle;
        private int lineRecvDataCnt;
        public string savePath;
        public string saveName;
        public bool timeStampEnable { get; set; }
        public string tsFormat { get; set; }
        public UInt32 totalRecvDataCnt { set; get; }
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
        public void ClosePort()
        {
            this.DataReceived -= Uart_DataReceived;
            stopUIAsyncHandle?.Invoke("");
            this.Close();
            this.Dispose();
        }
        public void ConfigPort(SelfdefSerial port)
        {
            this.BaudRate = port.BaudRate;
            this.Parity = port.Parity;
            this.PortName = port.PortName;
            this.DataBits = port.DataBits;
            this.StopBits = port.StopBits;
            this.ReadTimeout = port.ReadTimeout;
            this.WriteTimeout = port.WriteTimeout;
        }
        public void setStartUIAsyncHandle(UIAsyncHandle func)
        {
            startUIAsyncHandle += new UIAsyncHandle(func);
        }
        public void setStoptUIAsyncHandle(UIAsyncHandle func)
        {
            stopUIAsyncHandle += new UIAsyncHandle(func);
        }
        private string RecvDataToString()
        {
            string val = "";
            if (this.Encoding == Encoding.ASCII) {
                val = this.Encoding.GetString(buffer, 0, this.lineRecvDataCnt);
            } else if (this.Encoding == Encoding.Default) {
                int cnt = 0;
                foreach (var item in buffer) {
                    if (cnt++ >= this.lineRecvDataCnt) break;
                    val += item.ToString("X2") + " ";
                }
                val += "\n";
            }
            
            Array.Clear(buffer, 0, buffer.Length);
            this.lineRecvDataCnt = 0;
            return val;
        }

        private string CurrentTimeStampToString()
        {
            string val = "";
            if (this.timeStampEnable) {
                val = $"[{ DateTime.Now.ToString(this.tsFormat) }]: ";
            }
            return val;
        }
        private void Uart_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] temp = new byte[this.BytesToRead];
            bool is_one_line = false;
            if (this.Read(temp, 0, temp.Length) == 0) {
                return;
            }
            foreach (var item in temp) {
                if (item == 0x0d) {
                    is_one_line = true;
                    break;
                }
            }
            Array.Copy(temp, buffer, temp.Length);
            lineRecvDataCnt += temp.Length;
            totalRecvDataCnt += (UInt32)temp.Length;
            if (is_one_line) {
                string ts = CurrentTimeStampToString();
                string data = RecvDataToString();
                startUIAsyncHandle?.Invoke(ts + data);
            }
        }   
    }
}
