using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using ReactiveUI;

using UniversalFwForWPF.Datas;
using UniversalFwForWPF.Helpers;
using UniversalFwForWPF.Properties.Langs;

namespace UniversalFwForWPF.Views.Common
{
    /// <summary> SettingUc.xaml 的交互逻辑 </summary>
    public partial class SettingUc : UserControl
    {
        public SettingUc()
        {
            InitializeComponent();

            token = tokenSource.Token;
        }

        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e)
        {
            PopupConfig.IsOpen = true;
        }

        private void selectlanguage_onclick(object sender, RoutedEventArgs e)
        {
            //if (e.OriginalSource is Button button && button.Tag is string langName)
            //{
            //    //PopupConfig.IsOpen = false;
            //    if (langName.Equals(GlobalData.Config.Lang)) return;
            //    ConfigHelper.Instance.SetLang(langName);
            //    LangProvider.Culture = new CultureInfo(langName);

            // MessageBus.Current.SendMessage("LangUpdated");

            //    GlobalData.Config.Lang = langName;
            //    GlobalData.Save();
            //}

            if (e.OriginalSource is MenuItem menu && menu.Tag is string langName)
            {
                //PopupConfig.IsOpen = false;
                if (langName.Equals(GlobalData.Config.Lang)) return;
                ConfigHelper.Instance.SetLang(langName);
                LangProvider.Culture = new CultureInfo(langName);

                MessageBus.Current.SendMessage("LangUpdated");

                GlobalData.Config.Lang = langName;
                GlobalData.Save();
            }
        }

        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token;
        private Task task;
        private Task lasttask;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // ManualResetEvent resetEvent = new ManualResetEvent(true);

            // task.RunSynchronously();

            new AboutWindow
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential()
            {
                UserName = "AutoUpdater",
                Password = "123456",
            };

            //One.AutoUpdater.AutoUpdater.Start("ftp://117.33.179.181//SmartGateway//Version.json", networkCredential);
        }
    }
}
