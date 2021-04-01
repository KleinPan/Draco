using System;
using System.Collections.Generic;
using System.Text;

using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Configs;
using UniversalFwForWPF.Helpers;
using UniversalFwForWPF.Models;
using UniversalFwForWPF.ViewModels.Dialogs;

namespace UniversalFwForWPF.ViewModels
{
    public class SettingDialogVM : DialogVMBase
    {
        [Reactive] public int UperLimit { get; set; }
        [Reactive] public int LowerLimit { get; set; }

        public SettingDialogVM()
        {
            InitData();
        }

        public override void InitData()
        {
            base.InitData();

            var temp = IOHelper.Instance.ReadContentFromLocal<SettingModel>(MainViewModel.SettingFileName, PathConfig.ConfigPath);
            UperLimit = temp.UperLimit;
            LowerLimit = temp.LowerLimit;
        }

        public override void SureEvent()
        {
            SettingModel settingModel = new SettingModel();
            settingModel.UperLimit = UperLimit;
            settingModel.LowerLimit = LowerLimit;

            IOHelper.Instance.WriteContentTolocal(settingModel, PathConfig.ConfigPath, MainViewModel.SettingFileName);

            base.SureEvent();
        }
    }
}
