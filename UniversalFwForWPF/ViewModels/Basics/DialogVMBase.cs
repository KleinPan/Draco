using System;
using System.Reactive;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Datas;
using UniversalFwForWPF.ViewModels.Basics;

namespace UniversalFwForWPF.ViewModels.Dialogs
{

    public class DialogVMBase : ViewModelBase, IDialogResultable<DialogResultEnum>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }
        public ReactiveCommand<Unit, Unit> SureCmd { get; set; }

        public DialogVMBase()
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

   
}
