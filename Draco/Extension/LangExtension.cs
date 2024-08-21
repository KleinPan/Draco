using System;
using System.Collections.Generic;
using System.Text;

 

namespace Draco.Extension
{
    public class LangExtension : HandyControl.Tools.Extension.LangExtension
    {
        public LangExtension()
        {
            Source = Draco.Properties.Langs. LangProvider.Instance;
        }
    }
}
