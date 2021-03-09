using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
 
using UniversalFwForWPF.ViewModels.Basics;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.ViewModels.Basics;
using UniversalFwForWPF.Helpers;

namespace UniversalFwForWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Command

        public ReactiveCommand<Unit, Unit> NewProjectCmd { get; set; }

        public ReactiveCommand<Unit, Unit> OpenProjectCmd { get; set; }

        public ReactiveCommand<Unit, Unit> SaveProjectCmd { get; set; }

        public ReactiveCommand<object, Unit> SelectedConfigurationCmd { get; set; }

        public ReactiveCommand<object, Unit> SelectedAssistToolChangedCmd { get; set; }

        #endregion Command

        [Reactive] public string ProjectName { get; set; }

        [Reactive] public bool ShowMainContent { get; set; }

        public MainWindow mainWindow;

        public MainViewModel()
        {
        }

        #region Init

        public override void Init()
        {
            InitCommand();

            InitBindings();
            InitOthers();
            InitStartWindow();

            // InitFrameWork();
        }

        public override void InitOthers()
        {
        }

        public override void InitCommand()
        {
            NewProjectCmd = ReactiveCommand.Create(NewProject);
            OpenProjectCmd = ReactiveCommand.Create(OpenProject);
            SaveProjectCmd = ReactiveCommand.Create(SaveProjectEvent);
            //SelectedConfigurationCmd = ReactiveCommand.Create<object>(SelectedConfiguration);

            // SelectedAssistToolChangedCmd = ReactiveCommand.Create<object>(SelectedAssistToolChanged);
        }

        private async void InitStartWindow()
        {
            //var res = await DialogHelper.Instance.ShowSelectListDialog();
            //if (!string.IsNullOrEmpty(res))
            //{
            //    string configPath = PathConfig.projectPath + "\\" + res;
            //    var configs = IOHelper.Instance.ReadProjectContentFromLocal(configPath);

            //    if (configs == null || configs.GatewayConfigModel == null)
            //    {
            //        return;
            //    }

            //    ProjectName = res;
            //    InitFrameWork();
            //    InitProject(configs);
            //}
            //else
            //{
            //    InitNullFrameWork();
            //}
        }

        public override void InitBindings()
        {
            MessageBus.Current.Listen<string>()
                .Where(e => e.ToString() == "LangUpdated")
                .Subscribe(x =>
                {
                    Debug.WriteLine("LangUpdated");
                });

            this.WhenAnyValue(x => x.ProjectName)
                .ObserveOnDispatcher()
                .Subscribe(x =>
                {
                    if (string.IsNullOrEmpty(x))
                    {
                        ShowMainContent = false;
                    }
                    else
                    {
                        ShowMainContent = true;
                    }
                });
        }

        public void InitNullFrameWork()
        {
        }

        public void InitFrameWork()
        {
        }

        #endregion Init

        #region Project

        private async void NewProject()
        {
            var temp = DialogHelper.Instance.ShowInteractiveDialog("请输入新项目名称:");
            var newt = await temp;

            if (newt == null) return;

            ProjectName = newt.Trim();

            var list = IOHelper.Instance.ReadDirectoryListFromLocal();

            var exist = list.Select(x => x.Name).Any(p => p == ProjectName);

            if (exist)
            {
                MessageHelper.MessageShow("当前项目已存在!");
                ProjectName = null;
                return;
            }

            InitFrameWork();
        }

        private void OpenProject()
        {
            InitStartWindow();
        }

        private void SaveProjectEvent()
        {
            SaveProject();
            HandyControl.Controls.Growl.InfoGlobal("保存成功!");
        }

        private async void SaveProject()
        {
        }

        #endregion Project
    }
}