using CommunityToolkit.Mvvm.Input;
using Draco.Common.ViewModels.Basics;
using Draco.Models.Common;
using HandyControl.Tools.Extension;

namespace Draco.ViewModels.Dialogs
{
    public class LoginResult
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    public partial class LoginDialogVM : DialogVMBase, IDialogResultable<LoginResult>
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

        [RelayCommand]
        public override void Sure()
        {
            //替换当前信息
            //constConfig.UserAccount.UserName = Result.userName;
            //constConfig.UserAccount.Password = Result.password;

            //IOHelper.Instance.WriteContentTolocal(constConfig, PathConfig.ConfigPath, MainViewModel.SettingFileName);
            base.Sure();
        }

        public new LoginResult Result { get; set; } = new LoginResult();
    }
}
