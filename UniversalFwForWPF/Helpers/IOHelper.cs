﻿using System;
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

        #region Json
        public T ReadContentFromLocal<T>(string fileName, string directoryPath = "", string ext = ".json")
        {
            try
            {
                T Config;

                #region 基本信息

                //var GatewayConfigJson = System.IO.File.ReadAllText(directoryPath + @"\GatewayConfig.json");

                string content = "";
                if (string.IsNullOrEmpty(directoryPath))
                {
                    content = System.IO.File.ReadAllText(fileName + ext);

                }
                else
                {
                    content = System.IO.File.ReadAllText(directoryPath + "\\" + fileName + ext);

                }


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
        #endregion
        #region Xml
        /// <summary>
        /// XML序列化某一类型到指定的文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        public static void SerializeToXml<T>(string filePath, T obj)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    xs.Serialize(writer, obj);
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 从某一XML文件反序列化到某一类型
        /// </summary>
        /// <param name="filePath">待反序列化的XML文件名称</param>
        /// <param name="type">反序列化出的</param>
        /// <returns></returns>
        public static T DeserializeFromXml<T>(string filePath)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                    throw new ArgumentNullException(filePath + " not Exists");

                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    T ret = (T)xs.Deserialize(reader);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        #endregion

        #endregion 读写内容
    }
}
