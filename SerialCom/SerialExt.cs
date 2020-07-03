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
        //public bool tsNameEnable { set; get; }  /* log file name add timestamp enable */
        public string ExeLog { set; get; }      /* excute open log program */
        private UInt32 maxSize = 256;           /* log max size, unit:(MB)*/
        private UInt16 sameCnt;
        private long logSize;

        public void DefaultConfig()
        {
            Path = System.IO.Directory.GetCurrentDirectory() + @"\Log";
            Name = "SerialLog";
            SaveEnable = false;
            //tsNameEnable = true;
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
        private void CheckLogPath() {
            if (System.IO.Directory.Exists(Path) == false)
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Path);
                }
                catch (Exception ex)
                {
                    Path = Directory.GetCurrentDirectory();
                    throw ex;
                }
            }
        }
        /* when open save log action excute this */
        public void UpdateNameTimestamp()
        {
            this.Timestamp = "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            CheckLogPath();
        }
        public string GetLogName()
        {
            if (logSize / (1024 * 1024) >= this.maxSize)
            {
                UpdateNameTimestamp();
            }
            return this.Name + this.Timestamp + ".txt";
        }
        /* record log string to file */
        public void Log(string logStr)
        {
            if (SaveEnable == false)
                return;
            try {
                string file = GetLogName();
                string filename = this.Path + @"\" + file;
                StreamWriter writer = new StreamWriter(filename, true, Encoding.ASCII);
                FileInfo fileinfo = new FileInfo(filename);
                logSize = fileinfo.Length;
                if (writer != null)
                {
                    writer.Write(logStr);
                    writer.Flush();
                    writer.Close();
                }
            } catch (Exception ex) {
                throw (ex);
            }
        }
    }
    public delegate void UIAsyncHandle(string data);
    [Serializable]
    class SelfdefSerial : SerialPort {
        private byte[] buffer = new byte[1024];
        private UIAsyncHandle UIAsyncHandleFunc;
        private int lineRecvDataCnt;
       
        public bool timeStampEnable { get; set; }
        public string tsFormat { get; set; }
        public UInt32 totalRecvDataCnt { set; get; }
        public bool isDispAsiic { set; get; }   /* display uart data assic or not */
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
        public void AddUIAsyncHandle(UIAsyncHandle func)
        {
            UIAsyncHandleFunc += new UIAsyncHandle(func);
        }
        public void SubUIAsyncHandle(UIAsyncHandle func)
        {
            UIAsyncHandleFunc -= new UIAsyncHandle(func);
        }
        public void ClearUIAsyncHandle() {
            UIAsyncHandleFunc = null;
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

        private List<string> HandleRCVFrameData(byte[] recvData, string curTime, bool is_to_hex) {
            List<string> res_list = new List<string>();
            if (recvData == null) return null;
            int linecnt = 0;
            int offset = 0;
            foreach (var item in recvData)
            {
                linecnt++;
                if (item == 0x0a)
                {
                    string linestr = "";
                    if (is_to_hex)
                    {
                        for (int i = 0; i < linecnt; i++)
                        {
                            linestr += recvData[offset + i].ToString("X2") + " ";
                        }
                        linestr += "\n";
                    }
                    else
                    {
                        linestr = this.Encoding.GetString(recvData, offset, linecnt);
                    }
                    res_list.Add(curTime + linestr);
                    offset += linecnt;
                    linecnt = 0;
                }
            }
            return res_list;
        }
        private void Uart_DataReceived(object sender, SerialDataReceivedEventArgs e) 
        {
            try
            {
                byte[] tmp = new byte[this.BytesToRead + 10];
                int cnt = this.Read(tmp, 0, tmp.Length);
                if (cnt == 0) return;
                List<string> list_str = HandleRCVFrameData(tmp, $"[{DateTime.Now.ToString("HH:mm:ss.fff")}]: ", isDispAsiic);
                foreach (var item in list_str)
                {
                    UIAsyncHandleFunc?.Invoke(item);
                }
            } catch (Exception ex) {
                string disp = ex.GetType().Name + ", " + ex.Message;
                MessageBox.Show(disp);
            }
        }
    }
}
