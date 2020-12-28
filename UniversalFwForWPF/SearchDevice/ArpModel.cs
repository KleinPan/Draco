using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace UniversalFwForWPF.SearchDevice
{
    [StructLayout(LayoutKind.Sequential)]
    public class PayLoadData
    {
        /// <summary>
        /// 标志 0x11 22 33 44
        /// </summary>
        public int flag;

        /// <summary>
        /// 设备名字
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string DeviceName;

        /// <summary>
        /// 终端编号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string SerialNo;




    }
}
