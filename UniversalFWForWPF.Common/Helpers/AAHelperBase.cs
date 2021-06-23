using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace UniversalFWForWPF.Common.Helpers
{
    public class AAHelperBase
    {
        public static readonly NLog.Logger NLogger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary> 消息通知事件 </summary>
        public Action<string> ShowMessage { get; set; }

        /// <summary> 消息通知事件 </summary>
        public Action<string, SolidColorBrush> ShowMessageWithColor { get; set; }


        public static bool IsCancel { get; set; } = false;
        public AAHelperBase(Action<string, SolidColorBrush> messageEvent)
        {
            ShowMessageWithColor = messageEvent;
            ShowMessage += SetNotifyMessageWithoutColor;
        }

        private void SetNotifyMessageWithoutColor(string obj)
        {
            ShowMessageWithColor(obj, Brushes.Black);
        }


    }
}
