﻿using Draco.Common.Communication.Serialport;
using Draco.Common.Configs;
using Draco.Common.Helpers;
using Draco.Common.ViewModels.Basics;

using System.Collections.ObjectModel;
using System.IO.Ports;

namespace Draco.Common.ViewModels.Common
{
    public partial class SerialPortVM : DialogVMBase
    {
        public const string SerialportSettingFileName = "SerialportSetting";

        public SerialportModel SerialportModel { get; set; }

        #region SerialPort参数

        public ObservableCollection<string> SerialPortNameList { get; set; } = new ObservableCollection<string>();

        [ObservableProperty]
        private string serialPortName;


        [ObservableProperty]
        private int baudrate = 115200;



        private ParityEnum parity = ParityEnum.NONE;

        public ParityEnum Parity
        {
            get { return parity; }
            set { SetProperty(ref parity, value); }
        }
        [ObservableProperty]
        private StopBitsEnum stopBit = StopBitsEnum.USART_StopBits_1;

        [ObservableProperty]
        private DataBitsEnum dataBit = DataBitsEnum.USART_WordLength_8b;


        public int WriteTimeout { get; set; }
        public int ReadTimeout { get; set; }

        #endregion SerialPort参数



        public SerialPort SerialPort1 { get; set; }

        public SerialPortVM()
        {
            Init();
        }

        public override void Init()
        {
            SerialportModel = One.Core.Helpers.IOHelper.Instance.ReadContentFromLocal<SerialportModel>(PathConfig.ConfigPath + SerialportSettingFileName);

            if (SerialportModel != null)
            {
                Baudrate = SerialportModel.Baudrate;
                Parity = (ParityEnum)((int)SerialportModel.Parity);
                DataBit = (DataBitsEnum)((int)SerialportModel.DataBit);
                StopBit = (StopBitsEnum)(int)SerialportModel.StopBit;
                WriteTimeout = SerialportModel.WriteTimeout;
                ReadTimeout = SerialportModel.ReadTimeout;
            }
        }

        private void InitSP()
        {
            InitSerialPort();
        }

        /// <summary> 第一步，初始化 </summary>
        /// <returns> </returns>
        public SerialPort InitSerialPort()
        {
            if (SerialPort1 == null)
            {
                SerialPort1 = new SerialPort();
            }
            //通过WMI获取COM端口
            //string[] slist = Helpers.HardwareInfoHelper. MulGetHardwareInfo(Helpers.HardwareEnum.Win32_PnPEntity, "Name");

            string[] slist = System.IO.Ports.SerialPort.GetPortNames();
            SerialPortNameList.Clear();
            foreach (var item in slist)
            {
                SerialPortNameList.Add(item);
            }

            if (SerialPortNameList.Count > 0)
            {
                SerialPortName = SerialPortNameList[0];
            }
            else
            {
                System.Windows.MessageBox.Show("没有串口可用！");
                return null;
            }

            SerialPort1.BaudRate = Baudrate;
            SerialPort1.Parity = (Parity)Parity;
            SerialPort1.DataBits = (int)DataBit;
            SerialPort1.StopBits = (StopBits)StopBit;

            if (WriteTimeout != 0)
            {
                SerialPort1.WriteTimeout = WriteTimeout;
            }
            else
            {
                SerialPort1.WriteTimeout = 3000;
            }
            if (ReadTimeout != 0)
            {
                SerialPort1.ReadTimeout = ReadTimeout;
            }
            else
            {
                SerialPort1.ReadTimeout = 10000;
            }

            return SerialPort1;
        }

        /// <summary> 内部使用 </summary>
        private void OpenPort()
        {
            try
            {
                if (!string.IsNullOrEmpty(SerialPortName))
                {
                    Open(SerialPortName);
                }
                else
                {
                    System.Windows.MessageBox.Show("没有串口可用！");
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageHelper.MessageShow(exception.Message);
            }
        }

        public override void Sure()
        {
            SaveSerialportData();
            base.Sure();
        }

        public void SaveSerialportData()
        {
            try
            {
                SerialportModel = new SerialportModel();
                SerialportModel.Baudrate = Baudrate;
                SerialportModel.Parity = (Parity)Parity;
                SerialportModel.DataBit = (int)DataBit;
                SerialportModel.StopBit = (StopBits)StopBit;
                SerialportModel.WriteTimeout = 3000;
                SerialportModel.ReadTimeout = 10000;

                One.Core.Helpers.IOHelper.Instance.WriteContentTolocal(SerialportModel, PathConfig.ConfigPath + SerialportSettingFileName);
            }
            catch (Exception exception)
            {
                MessageHelper.MessageShow(exception.Message);
            }
        }

        /// <summary> 第二部，打开 可在外部直接调用 </summary>
        public bool Open(string portName)
        {
            try
            {
                if (SerialPort1 == null)
                {
                    return false;
                }
                if (SerialPort1.IsOpen)
                {
                    SerialPort1.Close();
                }

                SerialPort1.PortName = portName;

                SerialPort1.Open();
                return true;
            }
            catch (Exception exception)
            {
                MessageHelper.MessageShow(exception.Message);
                return false;
            }
        }

        public bool IsPortExists(int port)
        {
            try
            {
                if (Open($"COM{port}"))
                {
                    Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                MessageHelper.MessageShow(exception.Message);
                return false;
            }
        }

        public void SendMessage(byte[] mes)
        {
            if (SerialPort1.IsOpen)
            {
                SerialPort1.Write(mes, 0, mes.Length);
            }
        }

        public void SendMessage(string mes)
        {
            if (SerialPort1.IsOpen)
            {
                SerialPort1.Write(mes);
            }
        }

        public string SendMessageWithReturn(string mes, int timeoutSec = 2)
        {
            string res = "";
            try
            {
                if (SerialPort1.IsOpen)
                {
                    SerialPort1.Write(mes);
                }

                TimeSpan timeoutSpan = new TimeSpan(0, 0, timeoutSec);

                DateTime startTime = DateTime.Now;

                do
                {
                    int a = SerialPort1.BytesToRead;
                    res += SerialPort1.ReadExisting();
                    if (!(res.ToUpper().Contains("OK") || res.ToUpper().Contains("FAIL") || res.ToUpper().Contains("ERROR")))
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                    else
                    {
                        break;
                    }
                } while ((DateTime.Now - startTime) < timeoutSpan);
            }
            catch (Exception exception)
            {
                MessageHelper.MessageShow(exception.Message);
                return "ERROR";
            }

            return res;
        }

        private void ClosePort()
        {
            try
            {
                if (SerialPort1.IsOpen)
                {
                    SerialPort1.DiscardInBuffer();
                    SerialPort1.DiscardOutBuffer();

                    SerialPort1.Close();
                }
            }
            catch (Exception exception)
            {
                MessageHelper.MessageShow(exception.Message);
            }
        }
    }
}
