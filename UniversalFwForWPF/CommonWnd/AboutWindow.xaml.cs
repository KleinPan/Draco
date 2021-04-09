using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace UniversalFwForWPF.CommonWnd
{
    /// <summary>
    /// AboutWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AboutWindow
    {

        public AboutWindow()
        {
            InitializeComponent();

            DataContext = this;

            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            CopyRight = versionInfo.LegalCopyright;

            ProductVersion = $"v {versionInfo.ProductVersion} ";//{netVersion}
            FileVersion = $"v {versionInfo.FileVersion} ";//{netVersion}

        }

        public static readonly DependencyProperty CopyRightProperty = DependencyProperty.Register(
            "CopyRight", typeof(string), typeof(AboutWindow), new PropertyMetadata(default(string)));

        public string CopyRight
        {
            get => (string)GetValue(CopyRightProperty);
            set => SetValue(CopyRightProperty, value);
        }

        public static readonly DependencyProperty ProductVersionProperty = DependencyProperty.Register(
            "AssemblyVersion", typeof(string), typeof(AboutWindow), new PropertyMetadata(default(string)));

        public string ProductVersion
        {
            get => (string)GetValue(ProductVersionProperty);
            set => SetValue(ProductVersionProperty, value);
        }



        public string FileVersion
        {
            get { return (string)GetValue(FileVersionProperty); }
            set { SetValue(FileVersionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileVersion.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileVersionProperty =
            DependencyProperty.Register("FileVersion", typeof(string), typeof(AboutWindow), new PropertyMetadata(default(string)));







    }
}
