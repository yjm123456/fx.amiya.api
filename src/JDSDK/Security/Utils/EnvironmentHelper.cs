using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Reflection;
using log4net;

namespace Jd.ACES.Utils
{
    public class EnvironmentHelper
    {
        private static ILog LOGGER = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static string hostInfo = null;
        private static string systemInfo = null;

        public static long GetCurrentMillis()
        {
            long currentTicks = DateTime.UtcNow.Ticks;
            DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long currentMillis = (currentTicks - dtFrom.Ticks) / 10000;
            return currentMillis;
        }
        public static string FormatMsDateToString(long ms)
        {
            DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long totalMillis = ms * 10000 + dtFrom.Ticks;
            return new DateTime(totalMillis).ToString();
        }

        public static string GetHost()
        {
            if (hostInfo == null || "Unknown host".Equals(hostInfo))
            {
                try
                {
                    IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                    foreach (IPAddress addr in localIPs)
                    {
                        if (addr.AddressFamily == AddressFamily.InterNetwork)
                        {
                            hostInfo = addr.ToString();
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    LOGGER.Fatal(e.Message);
                }
            }

            hostInfo = hostInfo ?? "Unknown host";
            return hostInfo;
        }

        public static string GetSystemInfo()
        {
            if (systemInfo == null)
            {
                OperatingSystem osInfo = Environment.OSVersion;
                string osVersion = osInfo.Version.Major.ToString() + "." + osInfo.Version.Minor.ToString();
                string osName = GetOsName();
                string languageVersion = Environment.Version.ToString();
                string cpuInfo = GetCPUInfo();

                StringBuilder buffer = new StringBuilder();
                buffer.AppendFormat("{0}|{1}|{2}|{3}", osName, osVersion, languageVersion, cpuInfo);

                systemInfo = buffer.ToString();
            }
            return systemInfo;
        }

        private static string GetOsName()
        {
            //string subKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
            //RegistryKey key = Registry.LocalMachine;
            //RegistryKey skey = key.OpenSubKey(subKey);
            //return skey.GetValue("ProductName").ToString();
            return "Windows 10 Enterprise LTSC 2019";
        }
                
        private static string GetCPUInfo()
        {
            try
            {
                // only support to fetch CPU info for windows os
                RunCMDCommand("wmic cpu get name", out string cpuInfo);
                cpuInfo = cpuInfo.Replace("Name", "").Replace("\n", "").Trim();
                return cpuInfo;
            }
            catch (Exception e)
            {
                LOGGER.Fatal(e);
                return "Unknown CPU";
            }
        }

        private static string CMDPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\cmd.exe";

        public static void RunCMDCommand(string Command, out string OutPut)
        {
            using (Process pc = new Process())
            {
                Command = Command.Trim().TrimEnd('&') + "&exit";

                pc.StartInfo.FileName = CMDPath;
                pc.StartInfo.CreateNoWindow = true;
                pc.StartInfo.RedirectStandardError = true;
                pc.StartInfo.RedirectStandardInput = true;
                pc.StartInfo.RedirectStandardOutput = true;
                pc.StartInfo.UseShellExecute = false;

                pc.Start();

                pc.StandardInput.WriteLine(Command);
                pc.StandardInput.AutoFlush = true;

                OutPut = pc.StandardOutput.ReadToEnd();
                int P = OutPut.IndexOf(Command) + Command.Length;
                OutPut = OutPut.Substring(P, OutPut.Length - P - 3);
                pc.WaitForExit();
                pc.Close();
            }
        }
    }
}
