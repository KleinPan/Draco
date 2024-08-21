using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Draco.Common.Configs;
using Draco.Common.Enums;
using Draco.Common.ViewModels.Basics;
using Draco.Configs;
using Draco.Helpers;
using Draco.Models.Project;

using HandyControl.Tools.Extension;

using One.Core.ExtensionMethods;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Draco.ViewModels.Dialogs
{
    public partial class ProjectDialogVM : DialogVMBase, IDialogResultable<string>
    {
        public ObservableCollection<ProjectModel> ProjctList { get; set; } = new ObservableCollection<ProjectModel>();

        #region Property
        [ObservableProperty]
        ProjectModel selectedProject;

        [ObservableProperty]
        string header;

        [ObservableProperty]
        string result;
        #endregion
        public ProjectDialogVM()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();

            UpdateUI();
        }

        private void UpdateUI()
        {
            var temp = GetLocalProjects();
            ProjctList = new ObservableCollection<ProjectModel>();
            if (temp != null)
            {
                ProjctList.AddRange(temp);
            }
        }

        public static List<ProjectModel> GetLocalProjects()
        {
            try
            {
                var list = One.Core.Helpers.IOHelper.Instance.ReadContentFromLocal<List<ProjectModel>>(PathConfig.ConfigPath + AppConfig.ProjectHistory);
                if (list == null)
                {
                    return new List<ProjectModel>();
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [RelayCommand]
        private void Close()
        {
            CloseAction?.Invoke();
        }

        [RelayCommand]
        private async Task DeleteProject()
        {
            if (SelectedProject == null)
            {
                return;
            }

            var res = await DialogHelper.Instance.ShowResultDialog("确认删除所选项目?");

            if (res == DialogResultEnum.OK)
            {
                string configPath = PathConfig.projectPath + "\\" + SelectedProject.Name;
                System.IO.Directory.Delete(configPath, true);

                UpdateUI();
            }
        }

        [RelayCommand]
        private void OpenProject(object obj)
        {
            if (SelectedProject == null)
            {
                return;
            }

            Result = SelectedProject.Name;
            Close();
        }
    }
}
