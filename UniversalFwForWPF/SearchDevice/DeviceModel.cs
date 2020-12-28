using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace UniversalFwForWPF.SearchDevice
{
    public class DeviceModel
    {
        public string DeviceName { get; set; }

        public string SerialNo { get; set; }

        public string IPAddr1 { get; set; }

        public string NetMask1 { get; set; }

        public string MacAddr1 { get; set; }

        public string IPAddr2 { get; set; }

        public string NetMask2 { get; set; }

        public string MacAddr2 { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class NetParam
    {
        /// <summary> 网卡1 IP 地址 </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string IPAddr1;

        /// <summary> 网卡1 子网掩码 </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string NetMask1;

        /// <summary> 网卡1 子网掩码 </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string MacAddr1;

        /// <summary> 网卡2 IP 地址 </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string IPAddr2;

        /// <summary> 网卡2 子网掩码 </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string NetMask2;

        /// <summary> 网卡2 子网掩码 </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string MacAddr2;
    }
}
