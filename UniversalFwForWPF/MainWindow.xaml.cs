using System;

using UniversalFwForWPF.Controls;
using UniversalFwForWPF.ViewModels;
using UniversalFwForWPF.Views;

namespace UniversalFwForWPF
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

            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.mainWindow = this;

            mainContenUc.DataContext = mainViewModel;
            //UI控件
            ControlMain.Content = mainContenUc;
            mainViewModel.Init();
        }
    }
}