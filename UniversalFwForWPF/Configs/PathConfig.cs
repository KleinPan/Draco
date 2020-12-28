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

        /// <summary> 项目文件夹 </summary>
        public static string projectPath { get; set; }

        /// <summary> 模板文件夹 </summary>
        public static string templatePath { get; set; }

        /// <summary> 临时文件夹 </summary>
        public static string tempPath { get; set; }

        static PathConfig()
        {
            exePath = System.IO.Directory.GetCurrentDirectory();

            ConfigPath = basePath + @"\Configs";
            Directory.CreateDirectory(ConfigPath);

            downloadPath = exePath + @"\Download";
            Directory.CreateDirectory(downloadPath);

            resourcePath = exePath + @"\Resources";
            Directory.CreateDirectory(resourcePath);

            dataPath = exePath + @"\Data";
            Directory.CreateDirectory(dataPath);

            projectPath = exePath + @"\Project";
            Directory.CreateDirectory(projectPath);

            templatePath = exePath + @"\Template";
            Directory.CreateDirectory(templatePath);

            tempPath = exePath + @"\Temp";
            Directory.CreateDirectory(tempPath);
        }
    }
}