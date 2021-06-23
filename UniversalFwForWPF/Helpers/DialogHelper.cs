﻿ 

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using HandyControl.Controls;
using HandyControl.Tools.Extension;

using UniversalFwForWPF.Datas;
using UniversalFwForWPF.Models;
using UniversalFwForWPF.ViewModels;

using UniversalFwForWPF.ViewModels.Dialogs;
using UniversalFwForWPF.Views;
using UniversalFwForWPF.Views.Common;
using UniversalFwForWPF.Views.Dialogs;

using UniversalFWForWPF.Common.Datas;
using UniversalFWForWPF.Common.ViewModels.Basics;
using UniversalFWForWPF.Common.ViewModels.Common;
using UniversalFWForWPF.Common.Views.CommonDialog;

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

        public async Task<string> ShowProjectSelectDialog()
        {
            var myDialog = Dialog.Show<ProjectSelectDialog>();

            myDialog.DataContext = new ProjectDialogVM();

            var DialogResult1 = await myDialog.GetResultAsync<string>();

            return await Task.FromResult(DialogResult1);
        }
        /// <summary>
        /// ShowYesOrNoDialog
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public async Task<DialogResult> ShowResultDialog(string header)
        {
            var myDialog = Dialog.Show<ResultDialog>();

            myDialog.DataContext = new DialogVMBase()
            {
                Header = header,
            };

            var DialogResult1 = await myDialog.GetResultAsync<DialogResult>();

            return await Task.FromResult(DialogResult1);
        }

        public Task<DialogResultEnum> ShowSerialportSettingDialog(string header = "串口设置")
        {
            var myDialog = Dialog.Show<SerialportSettingDialog>();

            myDialog.DataContext = new SerialPortVM()
            {
                Header = header,
            };

            return myDialog.GetResultAsync<DialogResultEnum>();
        }
        public Task<DialogResultEnum> ShowLoginDialog(string header = "登陆")
        {
            var myDialog = Dialog.Show<LoginDialog>();

            myDialog.DataContext = new LoginDialogVM()
            {
                Header = header,
            };

            return myDialog.GetResultAsync<DialogResultEnum>();
        }
    }
}
