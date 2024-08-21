using Draco.Common.Configs;

using One.Core.Helpers;

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Draco.Common.Helpers
{
    public class CmdHelper : BaseHelper
    {
        public string toolPath { get; set; } = PathConfig.exePath + "\\EXEs\\";

        public Process ProcessHandle
        {
            get
            {
                return process;
            }
        }

        private Process process;

        public CmdHelper(Action<string, SolidColorBrush> messageEvent) : base(messageEvent)
        {
            process = new Process();
        }

        public bool ExecCMD(String exeFileName, string parameter, out string Res)
        {
            ShowMessageWithColor(ReflectionHelper.GetParentMethodName(), Resources.Brushes.MethodColor);
            return RunExeAndReadResult(toolPath, exeFileName, parameter, out Res);
        }

        public bool RunExeAndReadResult(string startdir, string exeName, string parmams, out string res)
        {
            ShowMessageWithColor(ReflectionHelper.GetParentMethodName(), Resources.Brushes.MethodColor);

            String commandLineString = "";
            process = new Process();
            res = "";
            ShowMessage("WorkingDirectory:" + startdir + ",FileName:" + exeName + ",Param: " + parmams);
            process.StartInfo.WorkingDirectory = startdir;
            process.StartInfo.FileName = startdir + exeName;
            process.StartInfo.Arguments = parmams;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            while (!process.HasExited)
            {
                //                if (MainForm.IsUserStop())
                //                {
                //                    ShowMessage("User Stopped");
                //                    return false;
                //}
                commandLineString = process.StandardOutput.ReadLine();

                res += commandLineString;
                ShowMessage(commandLineString);
            }
            commandLineString = process.StandardOutput.ReadToEnd();
            res += commandLineString;
            ShowMessage(commandLineString);

            process.WaitForExit(1000);
            ShowMessage("ExecCMD ... exit code is ..." + process.ExitCode.ToString());

            if (process.ExitCode != 0)
            {
                res += process.StandardError.ReadToEnd();
                ShowMessage(res);
                return false;
            }
            else
            {
                return true;
            }
             ;
        }
        /// <summary>
        /// 读输出流，3秒内要做完，不然杀进程
        /// </summary>
        /// <param name="startdir"></param>
        /// <param name="exeName"></param>
        /// <param name="parmams"></param>
        /// <param name="res"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public int RunExeAndReadResultWithTimeLimit(string startdir, string exeName, string parmams, out string res, int second = 3)
        {
            ShowMessageWithColor(ReflectionHelper.GetParentMethodName(), Resources.Brushes.MethodColor);

            string commandLineString = "";

            res = "";
            process = new Process();
            ShowMessage("WorkingDirectory:" + startdir + ",FileName:" + exeName + ",Param: " + parmams);
            process.StartInfo.WorkingDirectory = startdir;
            process.StartInfo.FileName = exeName;
            process.StartInfo.Arguments = parmams;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                ShowMessage("ERROR Start");
                ShowMessage($"ErrorDataReceived={e.Data}");
                ShowMessage("ERROR End");
            });

            process.Start();



            try
            {
                Debug.WriteLine($"Process ID={process.Id}");

                bool check = true;
                Task.Run(() =>
                {
                    DateTime start = DateTime.Now;
                    DateTime end = start;

                    while (true)
                    {
                        end = DateTime.Now;
                        Thread.Sleep(1000);
                        bool bFlag = (end - start) < TimeSpan.FromSeconds(second);

                        if (check)
                        {
                            if (!bFlag)
                            {
                                process.Kill();

                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                });
                while (!process.HasExited)
                {
                    commandLineString = process.StandardOutput.ReadLine();

                    res += commandLineString;

                    Debug.WriteLine($"Process ReadLine={res}");
                    NLogger.Debug($"Process ReadLine={res}");
                }

                commandLineString = process.StandardOutput.ReadToEnd();
                res += commandLineString;
                NLogger.Debug($"Read End={res}");
                process.StandardOutput.Close();
                Debug.WriteLine($"Process ID ={process.Id} StandardOutput.Close()");

                process.WaitForExit();
                check = false;
                if (process.ExitCode != 0)
                {

                    int code = process.ExitCode;
                    process.Kill();

                    return code;
                }
                else
                {
                    //process.Close();
                    //process.Kill();
                    process.Dispose();

                    Thread.Sleep(100);

                    return 0;
                }
            }
            catch (Exception exception)
            {

                return -1;
            }
        }
    }
}
