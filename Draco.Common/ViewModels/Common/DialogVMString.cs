using CommunityToolkit.Mvvm.ComponentModel;

using Draco.Common.ViewModels.Basics;

using HandyControl.Tools.Extension;

namespace Draco.Common.ViewModels.Common
{
    public partial class DialogVMString : DialogVMBase, IDialogResultable<string>
    {
        [ObservableProperty]
        string result;

        public DialogVMString() { }
    }
}
