using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Draco.Common.Datas;
using HandyControl.Tools.Extension;

namespace Draco.Common.ViewModels.Basics
{
    public partial class DialogVMBase : ViewModelBase, IDialogResultable<DialogResultEnum>
    {
        public DialogVMBase() { }

        public virtual void Sure()
        {
            Result = DialogResultEnum.OK;
            CloseAction?.Invoke();
        }

        public virtual void Close()
        {
            Result = DialogResultEnum.Cancel;
            CloseAction?.Invoke();
        }

        public Action CloseAction { get; set; }

        [ObservableProperty]
        string header;

        [ObservableProperty]
        DialogResultEnum result;
    }
}
