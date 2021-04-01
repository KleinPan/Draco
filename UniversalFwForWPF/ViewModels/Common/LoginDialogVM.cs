using System;
using System.Collections.Generic;
using System.Text;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Configs;
using UniversalFwForWPF.Helpers;
using UniversalFwForWPF.Models;
using UniversalFwForWPF.ViewModels.Dialogs;

namespace UniversalFwForWPF.ViewModels.Common
{
    public class LoginResult : ReactiveObject
    {
        [Reactive] public string userName { get; set; }
        [Reactive] public string password { get; set; }
    }

    public class LoginDialogVM : DialogVMBase, IDialogResultable<LoginResult>
    {
        public LoginDialogVM()
        {
            InitData();
        }

        public SettingModel constConfig { get; set; }
        public override void InitData()
        {
            base.InitData();

            constConfig = IOHelper.Instance.ReadContentFromLocal<SettingModel>(MainViewModel.SettingFileName, PathConfig.ConfigPath);

            //读取当前需要的信息
            //LoginResult=constConfig.

        }
        public override void SureEvent()
        {
            //替换当前信息
            constConfig.userInfo.UserName = Result.userName;
            constConfig.userInfo.Password = Result.password;

            IOHelper.Instance.WriteContentTolocal(constConfig, PathConfig.ConfigPath, MainViewModel.SettingFileName);
            base.SureEvent();
        }

        public new LoginResult Result { get; set; } = new LoginResult();
    }
}
