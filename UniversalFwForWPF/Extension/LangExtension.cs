using System;
using System.Collections.Generic;
using System.Text;

 

namespace UniversalFwForWPF.Extension
{
    public class LangExtension : HandyControl.Tools.Extension.LangExtension
    {
        public LangExtension()
        {
            Source = UniversalFwForWPF.Properties.Langs. LangProvider.Instance;
        }
    }
}
