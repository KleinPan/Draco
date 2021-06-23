using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using UniversalFWForWPF.Common.ViewModels.Common;

namespace UniversalFWForWPF.Common.Helpers
{
    public class ATCommandHelper : AAHelperBase
    {
        public SerialPortVM SerialPortVM { get; set; }

        public ATCommandHelper(Action<string, SolidColorBrush> messageEvent) : base(messageEvent)
        {

        }

        public async Task<string> SendATCommand(int comPort, string command)
        {
            string res1 = "";
            await Task.Run(() =>
            {
                if (SerialPortVM.Open("COM" + comPort.ToString()))
                {
                    NLogger.Trace("AT_发送：" + command);
                    res1 = SerialPortVM.SendMessageWithReturn(command + "\r");
                    NLogger.Trace("AT_接收：" + res1);

                    SerialPortVM.Close();
                }
                else
                {
                    res1 = "ComPort do not open!";
                }
            });
            return res1;
        }
    }
}
