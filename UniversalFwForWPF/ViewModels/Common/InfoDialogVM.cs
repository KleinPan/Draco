using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

using HandyControl.Tools.Extension;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using UniversalFwForWPF.ViewModels.Basics;

namespace UniversalFwForWPF.ViewModels.Common
{
    public class InfoDialogVM : DialogVMString
    {

        [Reactive] public string Message { get; set; }
        public InfoDialogVM()
        {

        }
    }
}
