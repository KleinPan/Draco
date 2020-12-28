using System;
using System.Collections.Generic;
using System.Text;

using UniversalFwForWPF.Properties.Langs;

namespace UniversalFwForWPF.Extension
{
    public class LangExtension : HandyControl.Tools.Extension.LangExtension
    {
        public LangExtension()
        {
            Source = LangProvider.Instance;
        }
    }
}
