using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Ink;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Draco.Common.Configs;
using Draco.Common.Helpers;
using Draco.Common.ViewModels.Basics;
using Draco.Configs;
using Draco.Helpers;
using Draco.Models.Project;
using Draco.ViewModels.Dialogs;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using One.Core.ExtensionMethods;
using One.Core.Helpers;
using SkiaSharp;
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

        public MainWindowVM()
        {
           InitData();
        }

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
        private void SaveProject()
        {
            HandyControl.Controls.Growl.InfoGlobal("保存项目成功!");
        }

        private void TestEvent()
        {
            MessageHelper.MessageShow(SettingFileName);

            //ListMessageHelper.Notify(SettingFileName);
        }

        #endregion CmdEvent

        #region LiveChart 
        public ObservableCollection<ISeries> Series0 { get; set; } = new();
        public ObservableCollection<ISeries> Series1 { get; set; } = new();
        public ObservableCollection<ISeries> Series2 { get; set; } = new();
        public ObservableCollection<ISeries> Series3 { get; set; } = new();
        public ObservableCollection<ISeries> Series4 { get; set; } = new();
        public ObservableCollection<ISeries> Series5 { get; set; } = new();
        public ObservableCollection<ISeries> Series6 { get; set; } = new();
        public ObservableCollection<ISeries> Series7 { get; set; } = new();
        public ObservableCollection<ISeries> Series8 { get; set; } = new();

        public override void InitData()
        {
            base.InitData();

            var line0 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection0 = new ObservableCollection<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line0.Values = valuesCollection0;
            Series0.Add(line0);

            var line1 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection1 = new ObservableCollection<int>() { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line1.Values = valuesCollection1;
            Series1.Add(line1);

            var line2 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection2 = new ObservableCollection<int>() { 2, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line2.Values = valuesCollection2;
            Series2.Add(line2);

            var line3 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection3 = new ObservableCollection<int>() { 3, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line3.Values = valuesCollection3;
            Series3.Add(line3);

            var line4 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection4 = new ObservableCollection<int>() { 4, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line4.Values = valuesCollection4;
            Series4.Add(line4);

            var line5 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection5 = new ObservableCollection<int>() { 5, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line5.Values = valuesCollection5;
            Series5.Add(line5);

            var line6 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection6 = new ObservableCollection<int>() { 6, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line6.Values = valuesCollection6;
            Series6.Add(line6);

            var line7 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection7 = new ObservableCollection<int>() { 7, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line7.Values = valuesCollection7;
            Series7.Add(line7);

            var line8 = new LineSeries<int> { Fill = null, GeometrySize = 3 }; //Stroke = new SolidColorPaint(SKColors.CadetBlue) { StrokeThickness = 3 }
            var valuesCollection8 = new ObservableCollection<int>() { 8, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            line8.Values = valuesCollection8;
            Series8.Add(line8);

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var a = Random.Shared.Next(0, 100);

                    valuesCollection0.Add(a);
                    valuesCollection1.Add(a);
                    valuesCollection2.Add(a);
                    valuesCollection3.Add(a);
                    valuesCollection4.Add(a);
                    valuesCollection5.Add(a);
                    valuesCollection6.Add(a);
                    valuesCollection7.Add(a);
                    valuesCollection8.Add(a);
                  

                    Thread.Sleep(100);
                    
                    valuesCollection0.RemoveAt(0);
                    valuesCollection1.RemoveAt(0);
                    valuesCollection2.RemoveAt(0);
                    valuesCollection3.RemoveAt(0);
                    valuesCollection4.RemoveAt(0);
                    valuesCollection5.RemoveAt(0);
                    valuesCollection6.RemoveAt(0);
                    valuesCollection7.RemoveAt(0);
                    valuesCollection8.RemoveAt(0);
                }
            });
        }
        #endregion

    }
}
