using HandyControl.Controls;
using HandyControl.Tools.Extension;

using UniversalFwForWPF.ViewModels.Common;
using UniversalFwForWPF.Views.Common;

namespace UniversalFwForWPF.Helpers
{
    public static class MessageHelper
    {
        public static void MessageShow(string mes, string header = "提示:")
        {
            // System.Windows.MessageBox.Show(mes);
            var myDialog = Dialog.Show<InfoDialog>();

            myDialog.DataContext = new InfoDialogVM()
            {
                Header = header,
                Message = mes,
            };
            // await myDialog.GetResultAsync<string>();
            myDialog.Show();

            // ProjectName = DialogResult1;
        }
    }
}