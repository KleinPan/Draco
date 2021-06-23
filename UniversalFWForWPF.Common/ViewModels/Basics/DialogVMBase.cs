using HandyControl.Tools.Extension;

using System;
using System.Collections.Generic;
using System.Text;

using UniversalFWForWPF.Common.Datas;
using UniversalFWForWPF.Common.Helpers;

namespace UniversalFWForWPF.Common.ViewModels.Basics
{
    public class DialogVMBase : ViewModelBaseB, IDialogResultable<DialogResultEnum>
    {
        public DelegateCommand CloseCmd { get; private set; }
        public DelegateCommand SureCmd { get; private set; }

        public DialogVMBase()
        {
            CloseCmd = new DelegateCommand(CloseEvent);

            SureCmd = new DelegateCommand(SureEvent);
        }

        public virtual void SureEvent()
        {
            Result = DialogResultEnum.OK;
            CloseAction?.Invoke();
        }

        public void CloseEvent()
        {
            Result = DialogResultEnum.Cancel;
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        public string Header { get; set; }
        public DialogResultEnum Result { get; set; }
    }
}
