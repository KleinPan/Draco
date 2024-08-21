using System.Windows;

namespace Draco.CommonWnd
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

            AppName = One.Core.Helpers.AssemblyHelper.Instance.ProductInfo.Product;
            ProductVersion = "Ver " + One.Core.Helpers.AssemblyHelper.Instance.ProductVersion;
        }

        public string AppName { get; set; }

        public static readonly DependencyProperty ProductVersionProperty = DependencyProperty.Register(
            "AssemblyVersion",
            typeof(string),
            typeof(AboutWindow),
            new PropertyMetadata(default(string))
        );

        public string ProductVersion
        {
            get => (string)GetValue(ProductVersionProperty);
            set => SetValue(ProductVersionProperty, value);
        }
    }
}
