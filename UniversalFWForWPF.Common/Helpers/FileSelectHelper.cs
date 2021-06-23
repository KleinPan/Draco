using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalFWForWPF.Common.Helpers
{
    public class FileSelectHelper
    {
        public static string OpenFileDialog(string fileExt = "")
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//允许打开多个文件
            dialog.DefaultExt = fileExt;//打开文件时显示的可选文件类型
            //dialog.Filter = fileExt + "xlsx文件|" + "*." + fileExt + "|xls文件|*.xls";//打开多个文件
            if (dialog.ShowDialog() == true)
                return dialog.FileNames[0];
            else
            {
                MessageHelper.MessageShow("返回文件路径失败");

                return null;
            }
        }

        public static List<string> OpenMultiFileDialog(string fileExt = "")
        {
            List<string> vs = new List<string>();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//允许打开多个文件
            dialog.DefaultExt = fileExt;//打开文件时显示的可选文件类型
            //dialog.Filter = fileExt + "xlsx文件|" + "*." + fileExt + "|xls文件|*.xls";//打开多个文件
            if (dialog.ShowDialog() == true)
            {
                foreach (var item in dialog.FileNames)
                {
                    vs.Add(item);
                }
            }
            else
            {
                MessageHelper.MessageShow("返回文件路径失败");
            }
            return vs;
        }
    }
}
