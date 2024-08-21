using System;
using System.Collections.Generic;
using System.Text;

namespace Draco.Models.Common
{
    public class CommunicationMessageBase
    {
        public int Index { get; set; }

        public int MessageLength { get; set; }

        public DateTime ReceiveTime { get; set; }
        public string Message { get; set; }


    }
}
