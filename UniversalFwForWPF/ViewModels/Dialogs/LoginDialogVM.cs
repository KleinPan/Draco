using HandyControl.Tools.Extension;

using System;
using System.Collections.Generic;
using System.Text;
using UniversalFWForWPF.Common.Configs;
using UniversalFWForWPF.Common.Helpers;
using UniversalFWForWPF.Common.ViewModels.Basics;

using UniversalFwForWPF.Models.Common;

namespace UniversalFwForWPF.ViewModels.Dialogs
{
    public class LoginResult
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    public class LoginDialogVM : DialogVMBase, IDialogResultable<LoginResult>
    {
        public LoginDialogVM()
        {
            InitData();
        }

        public CommonSettingModel constConfig { get; set; }
        public override void InitData()
        {
            base.InitData();

            //constConfig = IOHelper.Instance.ReadContentFromLocal<CommonSettingModel>(MainViewModel.SettingFileName, PathConfig.ConfigPath);

            //读取当前需要的信息
            //LoginResult=constConfig.

        }
        public override void SureEvent()
        {
            //替换当前信息
            //constConfig.UserAccount.UserName = Result.userName;
            //constConfig.UserAccount.Password = Result.password;

            //IOHelper.Instance.WriteContentTolocal(constConfig, PathConfig.ConfigPath, MainViewModel.SettingFileName);
            base.SureEvent();
        }

        public new LoginResult Result { get; set; } = new LoginResult();
    }
}
