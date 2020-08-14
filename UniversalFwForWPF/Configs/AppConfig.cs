using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalFwForWPF.Configs
{
    class AppConfig
    {
        public string Lang { get; set; } = "zh-cn";
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";
    }
}
