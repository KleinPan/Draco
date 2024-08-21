using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Draco.Common.Configs;
using Draco.Common.ViewModels.Basics;
using Draco.Models;

using HandyControl.Tools.Extension;

namespace Draco.ViewModels
{
    public partial class SettingDialogVM : DialogVMBase, IDialogResultable<SettingModel>
    {
        [ObservableProperty]
        private int uperLimit;

        [ObservableProperty]
        private int lowerLimit;

        [ObservableProperty]
        SettingModel result;

        public SettingDialogVM()
        {
            InitData();
        }

        public override void InitData()
        {
            base.InitData();

            var temp = One.Core.Helpers.IOHelper.Instance.ReadContentFromLocal<SettingModel>(PathConfig.ConfigPath + MainWindowVM.SettingFileName);
            Result = temp;
            UperLimit = Result.UperLimit;
            LowerLimit = Result.LowerLimit;
        }

        [RelayCommand]
        public override void Sure()
        {
            SettingModel settingModel = new SettingModel();
            settingModel.UperLimit = UperLimit;
            settingModel.LowerLimit = LowerLimit;

            One.Core.Helpers.IOHelper.Instance.WriteContentTolocal(settingModel, PathConfig.ConfigPath + MainWindowVM.SettingFileName);
            Result = settingModel;
            base.Sure();
        }
    }
}
