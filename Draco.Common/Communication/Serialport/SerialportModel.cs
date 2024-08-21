using System.IO.Ports;

namespace Draco.Common.Communication.Serialport
{
    public class SerialportModel
    {
        public int Baudrate { get; set; }
        public Parity Parity { get; set; }
        public int DataBit { get; set; }
        public StopBits StopBit { get; set; }
        public int WriteTimeout { get; set; }
        public int ReadTimeout { get; set; }
    }
}
