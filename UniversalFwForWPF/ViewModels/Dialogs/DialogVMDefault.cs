using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using HandyControl.Tools.Extension;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using UniversalFwForWPF.Datas;

using UniversalFwForWPF.ViewModels.Basics;

namespace UniversalFwForWPF.ViewModels.Dialogs
{
    public class DialogVMDefault : ViewModelBase, IDialogResultable<DialogResultEnum>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }
        public ReactiveCommand<Unit, Unit> SureCmd { get; set; }

        public DialogVMDefault()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);
            SureCmd = ReactiveCommand.Create(SureEvent);
        }

        public virtual void SureEvent()
        {
            Result = DialogResultEnum.OK;
            CloseEvent();
        }

        public void CloseEvent()
        {
            Result = DialogResultEnum.Cancel;
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public string Header { get; set; }
        [Reactive] public DialogResultEnum Result { get; set; }
    }

    public class DialogVMString : ViewModelBase, IDialogResultable<string>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }
        public ReactiveCommand<Unit, Unit> SureCmd { get; set; }

        public DialogVMString()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);
            SureCmd = ReactiveCommand.Create(SureEvent);
        }

        public virtual void SureEvent()
        {
            CloseEvent();
        }

        public void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public string Header { get; set; }
        [Reactive] public string Result { get; set; }
    }
}
