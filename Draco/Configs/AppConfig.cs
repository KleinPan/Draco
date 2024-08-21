using System;

namespace Draco.Configs
{
    public class AppConfig
    {
        public string Lang { get; set; } = "zh-cn";
        public static readonly string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}AppConfig.json";

        public static readonly string ProjectHistory = "ProjectHistory";
    }
}
