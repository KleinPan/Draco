using HandyControl.Tools.Extension;

using System;
using System.Collections.Generic;
using System.Text;

using UniversalFWForWPF.Common.ViewModels.Basics;

namespace UniversalFWForWPF.Common.ViewModels.Common
{
    public class DialogVMString : DialogVMBase, IDialogResultable<string>
    {

        public new string Result { get; set; }

        public DialogVMString()
        {
        }
    }
}
