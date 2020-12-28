using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyControl.Controls;
using HandyControl.Tools.Extension;

using UniversalFwForWPF.ViewModels.Dialogs;
using UniversalFwForWPF.Views.Dialogs;

namespace UniversalFwForWPF.Helpers
{
    public static class MessageHelper
    {
        public async static void MessageShow(string mes, string header = "提示:")
        {
            // System.Windows.MessageBox.Show(mes);
            var myDialog = Dialog.Show<InfoDialog>();

            myDialog.DataContext = new InfoDialogViewModel()
            {
                Header = header,
                Message = mes,
            };
            var DialogResult1 = await myDialog.GetResultAsync<string>();

            // ProjectName = DialogResult1;
        }



    }
}
