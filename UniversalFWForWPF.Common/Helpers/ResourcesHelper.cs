using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Reflection;
using System.Text;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Windows;

namespace UniversalFWForWPF.Common.Helpers
{
   public static class ResourcesHelper
    {
        public static void LoadViewFromUri(this FrameworkElement userControl, string baseUri)
        {
            try
            {
                var resourceLocater = new Uri(baseUri, UriKind.Relative);
                var exprCa = (PackagePart)typeof(Application).GetMethod("GetResourceOrContentPart", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { resourceLocater });
                var stream = exprCa.GetStream();
                var uri = new Uri((Uri)typeof(BaseUriHelper).GetProperty("PackAppBaseUri", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null), resourceLocater);
                var parserContext = new ParserContext
                {
                    BaseUri = uri
                };
                typeof(XamlReader).GetMethod("LoadBaml", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { stream, parserContext, userControl, true });
            }
            catch (Exception ex)
            {
                //log
                MessageBox.Show(ex.Message);
            }
        }
    }
   
}
