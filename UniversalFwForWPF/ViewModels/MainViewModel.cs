using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Configs;
using UniversalFwForWPF.Helpers;
using UniversalFwForWPF.Models.Project;
using UniversalFwForWPF.ViewModels.Basics;
using UniversalFwForWPF.ViewModels.Dialogs;

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

        public ReactiveCommand<Unit, Unit> TestCmd { get; set; }

        #endregion Command

        #region Property

        [Reactive] public string ProjectName { get; set; }

        [Reactive] public bool ShowMainContent { get; set; }

        public MainWindow mainWindow;

        #endregion Property

        #region Const

        public const string SettingFileName = "Setting";

        #endregion Const

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

            InitFrameWork();
        }

        public override void InitOthers()
        {
        }

        public override void InitCommand()
        {
            NewProjectCmd = ReactiveCommand.Create(NewProject);
            OpenProjectCmd = ReactiveCommand.Create(OpenProject);
            SaveProjectCmd = ReactiveCommand.Create(SaveProjectEvent);

            TestCmd = ReactiveCommand.Create(TestEvent);
            //SelectedConfigurationCmd = ReactiveCommand.Create<object>(SelectedConfiguration);

            // SelectedAssistToolChangedCmd = ReactiveCommand.Create<object>(SelectedAssistToolChanged);
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

        #region CmdEvent

        private void TestEvent()
        {
            MessageHelper.MessageShow(SettingFileName);

            ListMessageHelper.Notify(SettingFileName);
        }

        #endregion CmdEvent

        #region Project

        private async void InitStartWindow()
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

        private async void NewProject()
        {
            var temp = DialogHelper.Instance.ShowInteractiveDialog("请输入新项目名称:");
            var newt = await temp;

            if (newt == null) return;

            ProjectName = newt.Trim();

            var f = ProjectViewModel.GetLocalProjects();

            var list = IOHelper.Instance.ReadDirectoryListFromLocal();

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
                f.Add(new ProjectModel()
                {
                    Name = newt,
                    CreateTime = DateTime.Now,
                });

                System.IO.Directory.CreateDirectory(PathConfig.projectPath + "\\" + newt);

                IOHelper.Instance.WriteContentTolocal(f, PathConfig.projectPath, AppConfig.ProjectHistory);

                HandyControl.Controls.Growl.InfoGlobal("新建项目成功!");
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
            HandyControl.Controls.Growl.InfoGlobal("保存项目成功!");
        }

        private async void SaveProject()
        {
        }

        #endregion Project
    }
}