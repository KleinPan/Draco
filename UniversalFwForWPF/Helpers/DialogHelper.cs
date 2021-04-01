using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using HandyControl.Controls;
using HandyControl.Tools.Extension;

using UniversalFwForWPF.Datas;
using UniversalFwForWPF.Models;
using UniversalFwForWPF.ViewModels;
using UniversalFwForWPF.ViewModels.Common;
using UniversalFwForWPF.ViewModels.Dialogs;
using UniversalFwForWPF.Views;
using UniversalFwForWPF.Views.Common;

namespace UniversalFwForWPF.Helpers
{
  
    public class DialogHelper
    {
        public static DialogHelper Instance = new Lazy<DialogHelper>(() => new DialogHelper()).Value;

        public Task<string> ShowInteractiveDialog(string header)
        {
            var myDialog = Dialog.Show<InteractiveDialog>();

            myDialog.DataContext = new DialogVMString()
            {
                Header = header,
            };
            return myDialog.GetResultAsync<string>();
        }

        public Task<string> ShowInteractiveDialog(string header, string text)
        {
            var myDialog = Dialog.Show<InteractiveDialog>();

            myDialog.DataContext = new DialogVMString()
            {
                Header = header,
                Result = text,
            };
            return myDialog.GetResultAsync<string>();
        }

        public Task<DialogResultEnum> ShowTimerDialog(string header)
        {
            var myDialog = Dialog.Show<InfoDialogWithTimer>();

            myDialog.DataContext = new DialogVMBase()
            {
                Header = header,
            };

            return myDialog.GetResultAsync<DialogResultEnum>();
        }

        public Task<Dialog> ShowWaiterDialog(string header)
        {
            var myDialog = Dialog.Show<WaiterDialog>();

            myDialog.DataContext = new DialogVMBase()
            {
                Header = header,
            };
            var DialogResult1 = myDialog.GetResultAsync<Dialog>();

            return DialogResult1;
        }

        public Task<SettingModel> ShowSettingDialog(string header = "设置")
        {
            var myDialog = Dialog.Show<SettingDialog>();

            myDialog.DataContext = new SettingDialogVM()
            {
                Header = header,
            };

            return myDialog.GetResultAsync<SettingModel>();
        }
    }
}
