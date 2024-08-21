using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Draco.Common.Helpers;
namespace Draco.Common.Views.CommonDialog
{
    /// <summary>
    /// SerialportSettingDialog.xaml 的交互逻辑
    /// </summary>
    public partial class SerialportSettingDialog
    {
        public SerialportSettingDialog()
        {
            //InitializeComponent();
            this.LoadViewFromUri("/Draco.Common;component/Views/CommonDialog/SerialportSettingDialog.xaml");
        }
    }
}
