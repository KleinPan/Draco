using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HandyControl.Tools.Extension;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.Datas;
using UniversalFwForWPF.ViewModels.Basics;

namespace UniversalFwForWPF.ViewModels.Dialogs
{
  

    public class ResultDialogViewModel : ViewModelBase, IDialogResultable<DialogResultEnum>
    {
        public ReactiveCommand<Unit, Unit> CloseCmd { get; set; }
        public ReactiveCommand<Unit, Unit> YesCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; set; }

        public ResultDialogViewModel()
        {
            CloseCmd = ReactiveCommand.Create(CloseEvent);
            YesCommand = ReactiveCommand.Create(YesEvent);
            CancelCommand = ReactiveCommand.Create(CancelEvent);
        }

        private void CancelEvent()
        {
            Result = DialogResultEnum.Cancel;
            CloseEvent();
        }

        private void YesEvent()
        {
            Result = DialogResultEnum.OK;
            CloseEvent();
          
        }

        private void CloseEvent()
        {
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [Reactive] public string Header { get; set; }
        [Reactive] public DialogResultEnum Result { get; set; }

        //[Reactive] public string Message { get; set; }
    }
}
