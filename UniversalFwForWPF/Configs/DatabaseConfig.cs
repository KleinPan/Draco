using System;
using System.Collections.Generic;
using System.Text;

using UniversalFwForWPF.Helpers;

namespace UniversalFwForWPF.Configs
{
    public class DatabaseConfig
    {
        static DatabaseConfig()
        {

            /*
            #region Mysql
            var temp = ConfigHelper.ReadCommonConfigFromLocal();

            //MysqlConString = "server=" + temp.DatabaseInfo + ";uid=root;pwd=123456;database=znpdg";
            if (!string.IsNullOrEmpty(temp.DatabaseInfo.Port))
            {
                MysqlConString = "server=" + temp.DatabaseInfo.IPAdress + ";" + "port=" + temp.DatabaseInfo.Port + ";uid=" + temp.DatabaseInfo.UserName + ";pwd=" + temp.DatabaseInfo.Password + ";database=" + temp.DatabaseInfo.ExtraInformation + ";" + "ConnectionTimeout=5;Charset=utf8"; //+"ConnectionTimeout= 2000;"

                //MysqlConString = "server=" + temp.DatabaseInfo.IPAdress + ":" + temp.DatabaseInfo.Port + ";uid=" + temp.DatabaseInfo.UserName + ";pwd=" + temp.DatabaseInfo.Password + ";database=" + temp.DatabaseInfo.ExtraInformation + ";";
            }
            else
            {
                MysqlConString = "server=" + temp.DatabaseInfo.IPAdress + ";uid=" + temp.DatabaseInfo.UserName + ";pwd=" + temp.DatabaseInfo.Password + ";database=" + temp.DatabaseInfo.ExtraInformation + ";" + "ConnectionTimeout=5;Charset=utf8";
            }
            #endregion
            */

        }

        public static string MysqlConString;
    }
}
