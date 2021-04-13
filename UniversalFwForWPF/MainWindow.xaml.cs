using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using UniversalFwForWPF.Controls;
using UniversalFwForWPF.ViewModels;
using UniversalFwForWPF.Views;

namespace UniversalFwForWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
