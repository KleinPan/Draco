using System;
using System.Collections.Generic;
using System.Text;

namespace Draco.Common.Helpers
{
    public static class MessageHelper
    {
        public static readonly NLog.Logger NLogger = NLog.LogManager.GetCurrentClassLogger();

        public static void MessageShow(string mes, string header = "提示:")
        {
            NLogger.Warn(mes);



            HandyControl.Controls.MessageBox.Show(mes, header);
        }
    }
}
