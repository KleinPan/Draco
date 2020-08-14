using System.IO;

namespace UniversalFwForWPF.Configs
{
    public class PathConfig
    {

        /// <summary> 当前程序路径 </summary>
        public static string exePath { get; set; }

        public static string ConfigPath { get; set; }

        /// <summary> 当前程序路径 </summary>
        public static string basePath { get; set; } = System.IO.Directory.GetCurrentDirectory();

        /// <summary> 下载文件路径 </summary>
        public static string downloadPath { get; set; }

        /// <summary> 资源文件路径 </summary>
        public static string resourcePath { get; set; }

        /// <summary> 数据路径 </summary>
        public static string dataPath { get; set; }
        static PathConfig()
        {
            exePath = System.IO.Directory.GetCurrentDirectory();

            ConfigPath = basePath + @"\Configs";

            Directory.CreateDirectory(ConfigPath);

            downloadPath = exePath + @"\Download";
            Directory.CreateDirectory(downloadPath);

            resourcePath = exePath + @"\Resources";
            Directory.CreateDirectory(downloadPath);

            dataPath = exePath + @"\Resources";
            Directory.CreateDirectory(downloadPath);


        }

      
    }
}