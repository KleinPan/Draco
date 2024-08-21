using Draco.ViewModels;
using Draco.Views;
using Draco.Views.Controls;

using System;

namespace Draco
{
    /// <summary> Interaction logic for MainWindow.xaml </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            NonClientAreaContent = new SettingUc();

            MainContenUc mainContenUc = new MainContenUc();

            MainWindowVM mainViewModel = new MainWindowVM();
            mainViewModel.mainWindow = this;

            mainContenUc.DataContext = mainViewModel;
            //UI控件
            ControlMain.Content = mainContenUc;
            mainViewModel.Init();
        }
    }
}