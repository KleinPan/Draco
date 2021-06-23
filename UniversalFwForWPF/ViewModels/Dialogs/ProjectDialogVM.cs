using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;

using DynamicData;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Configs;
using UniversalFwForWPF.Helpers;
using UniversalFwForWPF.Models.Project;

using UniversalFwForWPF.ViewModels.Basics;

using UniversalFWForWPF.Common.Configs;
using UniversalFWForWPF.Common.Helpers;

namespace UniversalFwForWPF.ViewModels.Dialogs
{
    public class ProjectDialogVM : ViewModelBaseR, IDialogResultable<string>
    {
        [Reactive]
        public ObservableCollection<ProjectModel> ProjctList { get; set; } = new ObservableCollection<ProjectModel>();

        [Reactive]
        public ProjectModel SelectedProject { get; set; }

        #region Command

        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }

        public ReactiveCommand<object, Unit> OpenProjectCmd { get; set; }
        public ReactiveCommand<Unit, Unit> DeleteProjectCmd { get; set; }

        #endregion Command

        public Action CloseAction { get; set; }

        [Reactive] public string Header { get; set; }
        [Reactive] public string Result { get; set; }

        public ProjectDialogVM()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            InitCommand();

            UpdateUI();
        }

        private void UpdateUI()
        {
            var temp = GetLocalProjects();
            ProjctList = new ObservableCollection<ProjectModel>();
            ProjctList.AddRange(temp);
        }

        public static List<ProjectModel> GetLocalProjects()
        {
            var list = IOHelper.Instance.ReadContentFromLocal<List<ProjectModel>>(AppConfig.ProjectHistory, PathConfig.ConfigPath);
            if (list == null)
            {
                return new List<ProjectModel>();
            }
            return list;
        }

        public override void InitCommand()
        {
            base.InitCommand();
            OpenProjectCmd = ReactiveCommand.Create<object>(OpenProject);

            DeleteProjectCmd = ReactiveCommand.Create(DeleteProject);
            CloseCmd = ReactiveCommand.Create(CloseEvent);
        }

        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        private async void DeleteProject()
        {
            if (SelectedProject == null)
            {
                return;
            }

            var res = await DialogHelper.Instance.ShowResultDialog("确认删除所选项目?");

            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                string configPath = PathConfig.projectPath + "\\" + SelectedProject.Name;
                System.IO.Directory.Delete(configPath, true);

                UpdateUI();
            }
        }

        private void OpenProject(object obj)
        {
            if (SelectedProject == null)
            {
                return;
            }

            Result = SelectedProject.Name;
            CloseEvent();
        }
    }
}