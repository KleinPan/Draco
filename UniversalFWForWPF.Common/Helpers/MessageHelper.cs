using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalFWForWPF.Common.Helpers
{
    public static class MessageHelper
    {
        public static readonly NLog.Logger NLogger = NLog.LogManager.GetCurrentClassLogger();

        public static void MessageShow(string mes, string header = "提示:")
        {
            NLogger.Warn(mes);

            //Application.Current.Dispatcher.Invoke((Action)(() =>
            //{
            //    var myDialog = Dialog.Show<InfoDialog>();

            //    myDialog.DataContext = new InfoDialogVM()
            //    {
            //        Header = header,
            //        Message = mes,
            //    };
            //    myDialog.Show();
            //}));

            HandyControl.Controls.MessageBox.Show(mes, header);
        }
    }
}
