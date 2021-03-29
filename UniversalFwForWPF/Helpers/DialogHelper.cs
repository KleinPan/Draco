using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using HandyControl.Controls;
using HandyControl.Tools.Extension;

using UniversalFwForWPF.Datas;
using UniversalFwForWPF.ViewModels;
using UniversalFwForWPF.ViewModels.Dialogs;
using UniversalFwForWPF.Views;
using UniversalFwForWPF.Views.Dialogs;

namespace UniversalFwForWPF.Helpers
{
    public class DialogHelper
    {
        public static DialogHelper Instance = new Lazy<DialogHelper>(() => new DialogHelper()).Value;

        public async Task<string> ShowInteractiveDialog(string header)
        {
            var myDialog = Dialog.Show<InteractiveDialog>();

            myDialog.DataContext = new DialogVMString()
            {
                Header = header,
            };
            var DialogResult1 = await myDialog.GetResultAsync<string>();

            return await Task.FromResult(DialogResult1);
        }

        public async Task<string> ShowInteractiveDialog(string header, string text)
        {
            var myDialog = Dialog.Show<InteractiveDialog>();

            myDialog.DataContext = new DialogVMString()
            {
                Header = header,
                Result = text,
            };
            var DialogResult1 = await myDialog.GetResultAsync<string>();

            return await Task.FromResult(DialogResult1);
        }

        public async Task<DialogResultEnum> ShowTimerDialog(string header)
        {
            var myDialog = Dialog.Show<InfoDialogWithTimer>();

            myDialog.DataContext = new DialogVMDefault()
            {
                Header = header,
            };

            var DialogResult1 = await myDialog.GetResultAsync<DialogResultEnum>();

            return await Task.FromResult(DialogResult1);
        }

        public async Task<Dialog> ShowWaiterDialog(string header)
        {
            var myDialog = Dialog.Show<WaiterDialog>();

            myDialog.DataContext = new DialogVMDefault()
            {
                Header = header,
            };

            return await Task.FromResult(myDialog);
        }

        public async Task<DialogResultEnum> ShowSettingDialog(string header = "设置")
        {
            var myDialog = Dialog.Show<SettingDialog>();

            myDialog.DataContext = new SettingDialogVM()
            {
                Header = header,
            };

            var DialogResult1 = await myDialog.GetResultAsync<DialogResultEnum>();

            return await Task.FromResult(DialogResult1);
        }
    }
}
