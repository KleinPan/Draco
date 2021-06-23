using System;
using System.Collections.Generic;
using System.Text;

using HandyControl.Tools.Extension;

using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Configs;
using UniversalFwForWPF.Helpers;
using UniversalFwForWPF.Models;
using UniversalFwForWPF.ViewModels.Dialogs;

using UniversalFWForWPF.Common.Configs;
using UniversalFWForWPF.Common.Helpers;
using UniversalFWForWPF.Common.ViewModels.Basics;

namespace UniversalFwForWPF.ViewModels
{
    public class SettingDialogVM : DialogVMBase, IDialogResultable<SettingModel>
    {
        [Reactive] public int UperLimit { get; set; }
        [Reactive] public int LowerLimit { get; set; }

        [Reactive] public new SettingModel Result { get; set; }

        public SettingDialogVM()
        {
            InitData();
        }

        public override void InitData()
        {
            base.InitData();

            var temp = IOHelper.Instance.ReadContentFromLocal<SettingModel>(MainViewModel.SettingFileName, PathConfig.ConfigPath);
            Result = temp;
            UperLimit = Result.UperLimit;
            LowerLimit = Result.LowerLimit;
        }

        public override void SureEvent()
        {
            SettingModel settingModel = new SettingModel();
            settingModel.UperLimit = UperLimit;
            settingModel.LowerLimit = LowerLimit;

            IOHelper.Instance.WriteContentTolocal(settingModel, PathConfig.ConfigPath, MainViewModel.SettingFileName);
            Result = settingModel;
            base.SureEvent();
        }
    }
}
