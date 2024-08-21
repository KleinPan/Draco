using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Draco.Datas;
using Draco.Helpers;

namespace Draco
{
    /// <summary> Interaction logic for App.xaml </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Init();
            // MainViewModel mainViewModel=new MainViewModel();
        }

        private void Init()
        {
            ConfigHelper.Instance.Read();
            ConfigHelper.Instance.SetLang(ConfigHelper.Instance.AppConfig.Lang);
        }
    }
}
