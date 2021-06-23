using System;
using System.Collections.Generic;

using System.Reflection;
using System.Text;
using UniversalFWForWPF.Common.Configs;
using UniversalFWForWPF.Common.Helpers;

using UniversalFwForWPF.Models.Plugin;

using UniversalFwForWPF.ViewModels;
using System.Linq;
using System.IO;
using Autofac;

namespace UniversalFwForWPF.Configs
{
    public class AppBootstrapper
    {
        public static IContainer Container { get; set; }
        public static readonly NLog.Logger NLogger = NLog.LogManager.GetCurrentClassLogger();

        public AppBootstrapper()
        {
            try
            {
                ContainerBuilder containerBuilder = new ContainerBuilder();

                //加载实现类的程序集

                List<string> defaultFileList = System.IO.Directory.EnumerateFiles(PathConfig.pluginPathDefault).Where(x => x.EndsWith(".dll")).ToList();
                List<string> userFileList = System.IO.Directory.EnumerateFiles(PathConfig.pluginPathForUser).Where(x => x.EndsWith(".dll")).ToList();


                var temp = IOHelper.Instance.ReadContentFromLocal<PluginSettingModel>(MainViewModel.PluginSettingFileName, PathConfig.ConfigPath);


                foreach (var item in temp.AllLoadPlugins)
                {

                    string plugPath = PathConfig.pluginPathDefault + "\\" + item.Name + ".dll";
                    if (File.Exists(plugPath))
                    {
                        Assembly asm = Assembly.LoadFrom(plugPath);


                        containerBuilder.RegisterAssemblyTypes(asm)
                            .PublicOnly()//只要public访问权限的
                            .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型） 
                            .AsImplementedInterfaces()
                            .PropertiesAutowired();
                    }

                    string plugPath2 = PathConfig.pluginPathForUser + "\\" + item.Name + ".dll";
                    if (File.Exists(plugPath2))
                    {
                        Assembly asm = Assembly.LoadFile(plugPath2);

                        containerBuilder.RegisterAssemblyTypes(asm)
                             .PublicOnly()//只要public访问权限的
                             .Where(cc => cc.IsClass)//只要class型（主要为了排除值和interface类型） 
                             .AsImplementedInterfaces()
                             .PropertiesAutowired();
                    }
                }

                //foreach (var item in defaultFileList)
                //{

                //    Assembly asm = Assembly.LoadFile(item);

                //    containerBuilder.RegisterAssemblyTypes(asm).AsImplementedInterfaces().PropertiesAutowired();
                //}
                //foreach (var item in userFileList)
                //{
                //    Assembly asm = Assembly.LoadFile(item);

                //    containerBuilder.RegisterAssemblyTypes(asm).AsImplementedInterfaces().PropertiesAutowired();
                //}

                //Assembly asm = Assembly.Load("PluginAppFramework");

                //builder.RegisterAssemblyTypes(asm).AsImplementedInterfaces();

                Container = containerBuilder.Build();
            }
            catch (Exception ex)
            {
                NLogger.Error(ex);

                MessageHelper.MessageShow(ex.Message);
            }
        }
    }
}
