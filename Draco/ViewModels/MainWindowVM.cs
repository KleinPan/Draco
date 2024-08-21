using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Draco.Common.Configs;
using Draco.Common.Helpers;
using Draco.Common.ViewModels.Basics;
using Draco.Configs;
using Draco.Helpers;
using Draco.Models.Project;
using Draco.ViewModels.Dialogs;

using One.Core.Helpers;

using System;
using System.Linq;
using System.Threading.Tasks;

using FileHelper = Draco.Helpers.FileHelper;
namespace Draco.ViewModels
{
    public partial class MainWindowVM : ViewModelBase
    {
        

        #region Property

        [ObservableProperty]
        string projectName;

        [ObservableProperty]
        bool showMainContent;

        public MainWindow mainWindow;

        #endregion Property

        #region Const

        public const string SettingFileName = "Setting";
        public const string PluginSettingFileName = "PluginSetting";
        public const string ProjectSettingFileName = "ProjectSetting";
        #endregion Const

        public MainWindowVM() { }

        #region Init

        public override void Init()
        {
           
           

            InitFrameWork();
        }

          public void InitNullFrameWork() { }

        public void InitFrameWork() { }

        #endregion Init

        #region Menu
       
       
        [RelayCommand]
        private async Task NewProject()
        {
            var temp = DialogHelper.Instance.ShowInteractiveDialog("请输入新项目名称:");
            var newt = await temp;

            if (newt == null)
                return;

            ProjectName = newt.Trim();

            var f = ProjectDialogVM.GetLocalProjects();

            var list = FileHelper.Instance.ReadDirectoryListFromLocal();

            var dirExist = list.Select(x => x.Name).Any(p => p == ProjectName);
            var hisExist = f.Select(x => x.Name).Any(p => p == ProjectName);

            if (dirExist || hisExist)
            {
                MessageHelper.MessageShow("当前项目已存在!");
                ProjectName = null;
                return;
            }
            else
            {
                f.Add(new ProjectModel() { Name = newt, CreateTime = DateTime.Now });

                System.IO.Directory.CreateDirectory(PathConfig.projectPath + "\\" + newt);

                IOHelper.Instance.WriteContentTolocal(f, PathConfig.projectPath + AppConfig.ProjectHistory);

                HandyControl.Controls.Growl.InfoGlobal("新建项目成功!");
            }

            InitFrameWork();
        }
        [RelayCommand]
        private void OpenProject()
        {
            OpenStartWindow();
        }

        private async void OpenStartWindow()
        {
            var res = await DialogHelper.Instance.ShowProjectSelectDialog();
            if (!string.IsNullOrEmpty(res))
            {
                string configPath = PathConfig.projectPath + "\\" + res;

                ProjectName = res;
                InitFrameWork();
                //InitProject(configs);
            }
            else
            {
                InitNullFrameWork();
            }
        }
        [RelayCommand]
        private void SaveProject ()
        {
            
            HandyControl.Controls.Growl.InfoGlobal("保存项目成功!");
        }
      

        private void TestEvent()
        {
            MessageHelper.MessageShow(SettingFileName);

            //ListMessageHelper.Notify(SettingFileName);
        }

        #endregion CmdEvent

      
    }
}
