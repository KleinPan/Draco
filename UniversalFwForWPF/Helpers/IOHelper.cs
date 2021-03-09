using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

 

using Newtonsoft.Json;

using UniversalFwForWPF.Configs;
using UniversalFwForWPF.Models.Project;

namespace UniversalFwForWPF.Helpers
{
    public class IOHelper
    {
        public static IOHelper Instance = new Lazy<IOHelper>(() => new IOHelper()).Value;

        private JsonSerializerSettings jsonSerializerSettings;

        public IOHelper()
        {
            jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
        }

        private T JsonDeserialize<T>(string str)
        {
            //var result = System.Text.Json.JsonSerializer.Deserialize<T>(str);
            var result = JsonConvert.DeserializeObject<T>(str, jsonSerializerSettings);
            return result;
        }

        #region 读写文件列表

        public IEnumerable<ProjectModel> ReadDirectoryListFromLocal()
        {
            DirectoryInfo dirs = new DirectoryInfo(PathConfig.projectPath); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象

            var list = dir.Select(x => new ProjectModel() { Name = x.Name, CreateTime = x.CreationTime });

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

        #region 读写内容

        public T ReadContentFromLocal<T>(string directoryPath, string fileName)
        {
            try
            {
                T Config;

                #region 基本信息

                //var GatewayConfigJson = System.IO.File.ReadAllText(directoryPath + @"\GatewayConfig.json");
                var content = System.IO.File.ReadAllText(directoryPath + "\\" + fileName + ".json");

                Config = JsonDeserialize<T>(content);

                #endregion 基本信息

                return Config;
            }
            catch (Exception ex)
            {
                MessageHelper.MessageShow(ex.Message, "找不到配置!");

                return default(T);
            }
        }

        public void WriteContentTolocal<T>(T allGatewayConfig, string path, string fileName)
        {
            try
            {
                string newpath = path;
                //string newpath = PathConfig.projectPath + "\\" + path;
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                var json = JsonConvert.SerializeObject(allGatewayConfig, Formatting.Indented, jsonSerializerSettings);
                System.IO.File.WriteAllText(newpath + "\\" + fileName + ".json", json);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        #endregion 读写内容
    }
}
