using QiShiLog;
using QiShiLog.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06TryCatchConsole
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Logger.Instance.EnableInfoFile = true; // Enable info file logging

            for (int i = 0; i < 5; i++)
            {
                
                
                try
                {
                    int result = 10 / i; // This will throw an exception when i is 0

                    Console.WriteLine($"Result: {result}");
                    Logger.Instance.Info($"Result: {result}"); // Log the result
                }

                catch (Exception ex)
                {


                    Logger.Instance.Info($"Error Log, {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("This block always executes, regardless of an exception.");
                }
                Process.Start(Path.Combine(QiShiCore.WorkSpace.Dir, "Log")); // 打开日志文件

            }


        }
    }
}
