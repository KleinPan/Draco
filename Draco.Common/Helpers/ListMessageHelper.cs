using System;
using System.Windows.Media;

namespace Draco.Common.Helpers
{
    public class ListMessageHelper
    {
        //public delegate void MessageEvent(string message, SolidColorBrush color = null);

        public Action<string, SolidColorBrush> NotifyActionWithColor;
        //public Action<string> NotifyAction;

        //public event MessageEvent NotifyMessage;

        /// <summary> 使用方法 Mes.NotifyMessage += SetNotifyMessage; SetNotifyMessage(string message, SolidColorBrush fc) </summary>
        /// <param name="message"> </param>
        /// <param name="color">   </param>
        public void Notify(string message, SolidColorBrush color = null)
        {
            if (color == null)
            {
                color = Brushes.Black;
            }
            //NotifyMessage?.Invoke(DateTime.Now.ToString("MM月dd日 HH:mm:ss :\r\n") + message, color);

            //if (NotifyMessage != null)
            //{
            //    NotifyMessage?.Invoke(message, color);
            //}
            //if (NotifyAction!=null)
            //{
            //    NotifyActionWithColor(message, color);
            //    return;
            //}
            if (NotifyActionWithColor != null)
            {
                NotifyActionWithColor(message, color);

            }

        }
    }
}
