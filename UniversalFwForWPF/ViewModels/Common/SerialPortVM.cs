using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Datas;
using UniversalFwForWPF.ViewModels.Basics;

namespace UniversalFwForWPF.ViewModels.Common
{
    public class SerialPortVM : ViewModelBase
    {
        #region SerialPort参数

        [Reactive] public ObservableCollection<string> SerialPortNameList { get; set; } = new ObservableCollection<string>();

        [Reactive] public string SerialPortName { get; set; }
        [Reactive] public int Baudrate { get; set; } = 115200;
        [Reactive] public ParityEnum Parity { get; set; } = ParityEnum.NONE;
        [Reactive] public StopBitsEnum StopBit { get; set; } = StopBitsEnum.USART_StopBits_1;
        [Reactive] public DataBitsEnum DataBit { get; set; } = DataBitsEnum.USART_WordLength_8b;

        #endregion SerialPort参数

        [Reactive] public string ButtonContent { get; set; } = "打开串口";

        [Reactive] public bool IsOpen { get; set; }
        [Reactive] public BitmapImage LigthImage { get; set; }

        public ReactiveCommand<Unit, Unit> InitSPCommand { get; set; }
        public ReactiveCommand<Unit, Unit> OpenSPCommand { get; set; }

        public SerialPort SerialPort1 { get; set; }

        public delegate void MessageEvent(string message);

        public event MessageEvent NotifyMessage;

        public SerialPortVM()
        {
        }

        public override void Init()
        {
            InitCommand();
            InitBindings();
        }

        public override void InitCommand()
        {
            InitSPCommand = ReactiveCommand.Create(InitSP);
            OpenSPCommand = ReactiveCommand.Create(OpenOrCloseSP);
        }

        private void InitSP()
        {
            InitSerialPort();
        }

        public override void InitBindings()
        {
            this.WhenAnyValue(x => x.SerialPortName)
                .ObserveOnDispatcher()
                .Subscribe(x =>
                {
                    if (!string.IsNullOrEmpty(x))
                    {
                        if (SerialPort1 != null)
                        {
                            SerialPort1.Close();
                            IsOpen = false;
                            ButtonContent = "打开串口";
                        }
                    }
                });

            this.WhenAnyValue(x => x.IsOpen)
               .ObserveOnDispatcher()
               .Subscribe(x =>
               {
                   //if (x)
                   //{
                   //    LigthImage = One.Control.Helper.ImageHelper.FindImage("img_light_on.png");
                   //}
                   //else
                   //{
                   //    LigthImage = One.Control.Helper.ImageHelper.FindImage("img_light_off.png");
                   //}
                   if (x)
                   {
                       ButtonContent = "关闭串口";
                   }
                   else
                   {
                       ButtonContent = "打开串口";
                   }
               });
        }

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

            if (NotifyMessage != null)
            {
                // SerialPort1.DataReceived += SerialPort1_DataReceived;
            }

            return SerialPort1;
        }

        private void OpenOrCloseSP()
        {
            try
            {
                if (SerialPort1.IsOpen)
                {
                    SerialPort1.Close();
                    IsOpen = false;

                    ButtonContent = "打开串口";
                }
                else
                {
                    if (!string.IsNullOrEmpty(SerialPortName))
                    {
                        SerialPort1.PortName = SerialPortName;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("没有串口可用！");
                        return;
                    }
                        
                    SerialPort1.BaudRate = Baudrate;
                    SerialPort1.Parity = (Parity)Parity;
                    SerialPort1.DataBits = (int)DataBit;
                    SerialPort1.StopBits = (StopBits)StopBit;
                    SerialPort1.WriteTimeout = 3000;
                    SerialPort1.ReadTimeout = 10000;

                    SerialPort1.Open();
                    IsOpen = true;
                    ButtonContent = "关闭串口";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            NotifyMessage?.Invoke(SerialPort1.ReadExisting());
        }

        public void Open()
        {
            try
            {
                if (!string.IsNullOrEmpty(SerialPortName))
                {
                    SerialPort1.PortName = SerialPortName;
                }
                else
                {
                    System.Windows.MessageBox.Show("没有串口可用！");
                    return;
                }

                SerialPort1.BaudRate = Baudrate;
                SerialPort1.Parity = (Parity)Parity;
                SerialPort1.DataBits = (int)DataBit;
                SerialPort1.StopBits = (StopBits)StopBit;
                SerialPort1.WriteTimeout = 3000;
                SerialPort1.ReadTimeout = 10000;

                SerialPort1.Open();
                IsOpen = true;
                ButtonContent = "关闭串口";
            }
            catch (Exception exception)
            {
                // MessageHelper.MessageShow(exception.Message);
                MessageBox.Show(exception.Message);
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
                MessageBox.Show(exception.Message);
                return "ERROR";
            }

            return res;
        }

        public void Close()
        {
            try
            {
                SerialPort1.DiscardInBuffer();
                SerialPort1.DiscardOutBuffer();

                SerialPort1.Close();
                IsOpen = false;

                ButtonContent = "打开串口";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
