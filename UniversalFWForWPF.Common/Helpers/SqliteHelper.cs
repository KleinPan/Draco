using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

using UniversalFWForWPF.Common.Configs;

namespace UniversalFwForWPF.Common.Helpers
{
    class SqliteHelper
    {

        public const string databaseName = "database.db3";

        public static SqliteConnection conn;

        public static SqliteConnection GetConnection()
        {

           

            var connectionString = "Data Source=" + PathConfig.exePath + $"\\Data\\{databaseName};Pooling=true;";
            var connection = new SqliteConnection(connectionString);

            connection.Open();
            return connection;


            
        }

        #region 例子

        #endregion
        /*
        public static async void ExecuteAsyncInsert(object model)
        {
            try
            {
                conn = GetConnection();
               
                    using (IDbConnection connection = SqliteHelper.conn)
                    {
                        var temp = await connection.ExecuteAsync("insert into RunningInfo(StartTime,EndTime,SelectedGame,SelectedGameTrackName,ErrorCode) " +
                            "values(@StartTime,@EndTime,@SelectedGame,@SelectedGameTrackName,@alarm_value)", running);
                        if (temp == 1)
                        {
                            //Debug.WriteLine("插入成功!");
                            Console.WriteLine("插入成功!");
                        }
                    }
                
             
            }
            catch (Exception exception)
            {
               
            }
        }
        */
        /*
        /// <summary> 查询是否有记录 </summary>
        /// <param name="model"> </param>
        /// <returns> </returns>
        public static async Task<bool> QuaryIfExist(StatisticsInfoModel model)
        {
            try
            {
                conn = GetConnection();
                using (IDbConnection connection = SqliteHelper.conn)
                {
                    var temp = await connection.QueryAsync<StatisticsInfoModel>("select * from StatisticsInfo where   RunningDate = @RunningDate", new { RunningDate = model.RunningDate });

                    if (temp.Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

                return false;
            }
        }
        */
        /*
        /// <summary> 更新记录 </summary>
        /// <param name="model"> </param>
        /// <returns> </returns>
        public static async void ExecuteAsyncUpdate(StatisticsInfoModel model)
        {
            try
            {
                conn = GetConnection();
                using (IDbConnection connection1 = SqliteHelper.conn)
                {
                    // var temp = await connection.ExecuteAsync("select * From  StatisticsInfo where RunningDate = @start", new { start = model.RunningDate });
                    //dataPowers.Clear();
                    //dataPowers.AddRange(connection.GetList<DataPower>("where data_time >= @start and data_time <= @end", new { start = SelevtStart, end = SelevtEnd }).ToList());

                    var temp = await connection1.ExecuteAsync("update  StatisticsInfo set  Count=@Count where RunningDate = @RunningDate ", new { RunningDate = model.RunningDate, Count = model.Count });

                    if (temp > 0)
                    {
                        // return true;
                    }
                    else
                    {
                        // return false;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

                // return false;
            }
        }
        */

        /*
        public static async Task<List<StatisticsInfoModel>> QuaryCount(DateTime start, DateTime end)
        {
            try
            {
                conn = GetConnection();
                List<StatisticsInfoModel> list = new List<StatisticsInfoModel>();
                using (IDbConnection connection = SqliteHelper.conn)
                {
                    var temp = await connection.QueryAsync<StatisticsInfoModel>("select * from StatisticsInfo where   RunningDate >= @startTime and RunningDate <@endTime", new { startTime = start, endTime = end });

                    if (temp.Count() > 0)
                    {
                        list.AddRange(temp);
                    }

                    return list;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

                return null;
            }
        }
        */
        /*
        public static async Task<List<RunningInfoModel>> QuaryData(DateTime start, DateTime end)
        {
            try
            {
                conn = GetConnection();
                List<RunningInfoModel> list = new List<RunningInfoModel>();
                using (IDbConnection connection = SqliteHelper.conn)
                {
                    var temp = await connection.QueryAsync<RunningInfoModel>("select * from RunningInfo where   StartTime >= @startTime and StartTime <@endTime", new { startTime = start, endTime = end });

                    if (temp.Count() > 0)
                    {
                        list.AddRange(temp);
                    }

                    return list;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

                return null;
            }
        }
        */
    }

    /*
    /// <summary> 根据官方文档编写 </summary>
    public class DatabaseHelper
    {
        public DatabaseHelper()
        {
        }
        #region Mysql
        /// <summary> 查询操作 </summary>
        public void Quary()
        {
            string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent='Oceania'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " -- " + rdr[1]);
            }
            rdr.Close();
        }
        // ExecuteNonQuery is only used for inserting, updating and deleting data.
        // the ExecuteScalar method can be used to return a single value
        public void QuarySingle()
        {
            string sql = "SELECT COUNT(*) FROM Country";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                int r = Convert.ToInt32(result);
                Console.WriteLine("Number of countries in the world database is: " + r);
            }
        }
        #endregion Mysql
    }
    */

}

