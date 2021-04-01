using HandyControl.Tools.Extension;

using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.ViewModels.Dialogs;

namespace UniversalFwForWPF.ViewModels.Common
{
    public class DialogVMString : DialogVMBase, IDialogResultable<string>
    {
        [Reactive] public new string Result { get; set; }

        public DialogVMString()
        {
        }
    }
}