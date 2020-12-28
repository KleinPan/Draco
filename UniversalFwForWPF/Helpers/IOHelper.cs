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

        #region 项目管理

        public IEnumerable<ProjectModel> ReadProjectListFromLocal()
        {
            DirectoryInfo dirs = new DirectoryInfo(PathConfig.projectPath); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象

            var list = dir.Select(x => new ProjectModel() { Name = x.Name, CreateTime = x.CreationTime });

            return list;
        }

        public T ReadProjectContentFromLocal<T>(string directoryPath)
        {
            try
            {
                T allGatewayConfig;

                #region 基本信息

                var GatewayConfigJson = System.IO.File.ReadAllText(directoryPath + @"\GatewayConfig.json");

                allGatewayConfig = JsonDeserialize<T>(GatewayConfigJson);

                #endregion 基本信息

                return allGatewayConfig;
            }
            catch (Exception ex)
            {
                MessageHelper.MessageShow(ex.Message, "找不到配置!");

                return default(T);
            }
        }

        public void WriteProjectContentTolocal<T>(string path, T allGatewayConfig)
        {
            try
            {
                string newpath = PathConfig.projectPath + "\\" + path;
                if (!Directory.Exists(newpath))
                {
                    Directory.CreateDirectory(newpath);
                }
                var json = JsonConvert.SerializeObject(allGatewayConfig, Formatting.Indented, jsonSerializerSettings);
                System.IO.File.WriteAllText(newpath + @"\GatewayConfig.json", json);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        #endregion 项目管理

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
    }
}
