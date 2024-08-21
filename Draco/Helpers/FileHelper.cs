using Draco.Common.Helpers;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Draco.Models.File;

using Draco.Common.Configs;

namespace Draco.Helpers
{
    public class FileHelper
    {
        public static FileHelper Instance = new Lazy<FileHelper>(() => new FileHelper()).Value;

        private JsonSerializerSettings jsonSerializerSettings;

        public FileHelper()
        {
        }

        #region 读写文件列表

        public IEnumerable<FileModel> ReadDirectoryListFromLocal()
        {
            DirectoryInfo dirs = new DirectoryInfo(PathConfig.projectPath); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象

            var list = dir.Select(x => new FileModel() { Name = x.Name, CreateTime = x.CreationTime });

            return list;
        }

        public List<string> ReadFileListFromLocal()
        {
            try
            {
                List<string> listNames = new List<string>();

                string configPath = PathConfig.templatePath + "\\";

                var list = System.IO.Directory.EnumerateFiles(configPath).Select(x => Path.GetFileNameWithoutExtension(x));
                listNames.AddRange(list);

                return listNames;
            }
            catch (Exception ex)
            {
                MessageHelper.MessageShow(ex.Message, "读取模板出错!");

                return null;
            }
        }

        #endregion 读写文件列表
    }
}
