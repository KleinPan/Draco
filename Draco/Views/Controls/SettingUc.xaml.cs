using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Draco.CommonWnd;
using Draco.Datas;
using Draco.Helpers;

namespace Draco.Views.Controls
{
    /// <summary> SettingUc.xaml 的交互逻辑 </summary>
    public partial class SettingUc : UserControl
    {
        public string AppName { get; set; }
        public string AppVersion { get; set; }

        public SettingUc()
        {
            InitializeComponent();

            DataContext = this;

            AppName = One.Core.Helpers.AssemblyHelper.Instance.ProductInfo.Product;
            AppVersion = "Ver " + One.Core.Helpers.AssemblyHelper.Instance.ProductVersion;


            ConfigHelper.Instance.Read();
        }

        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e)
        {
            PopupConfig.IsOpen = true;
        }

        private void selectlanguage_onclick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem menu && menu.Tag is string langName)
            {
                //PopupConfig.IsOpen = false;
                if (langName.Equals(ConfigHelper.Instance.Lang ))
                    return;
                ConfigHelper.Instance.SetLang(langName);
                //LangProvider.Culture = new CultureInfo(langName);

                //MessageBus.Current.SendMessage("LangUpdated");

                ConfigHelper.Instance.AppConfig.Lang = langName;
                ConfigHelper.Instance.Save();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow { Owner = Application.Current.MainWindow }.ShowDialog();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential() { UserName = "AutoUpdater", Password = "123456" };
        }
    }
}
