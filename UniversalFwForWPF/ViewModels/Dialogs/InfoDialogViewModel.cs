using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.ViewModels.Basics;

namespace UniversalFwForWPF.ViewModels.Dialogs
{
    public class InfoDialogViewModel : ViewModelBase, IDialogResultable<string>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }

        public InfoDialogViewModel()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);
        }

        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public string Header { get; set; }
        [Reactive] public string Result { get; set; }

        [Reactive] public string Message { get; set; }
    }
}
