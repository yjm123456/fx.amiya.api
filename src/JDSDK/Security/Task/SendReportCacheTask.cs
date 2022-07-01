using System;
using System.Timers;
using log4net;
using Jd.ACES.Common.Exceptions;
using System.Collections.Generic;


namespace Jd.ACES.Task
{
    public class SendReportCacheTask
    {
        private static ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Task(Object obj, ElapsedEventArgs e)
        {
            LOGGER.Info("send reports...");
            // catch all exceptions
            try
            {
                Dictionary<string, TDEClient> clientPool = TDEClient.clientPool;
                foreach (KeyValuePair<string, TDEClient> kvp in clientPool)
                {
                    TDEClient tdeClient = kvp.Value;
                    tdeClient.GetMonitorClient().Task();
                    Console.WriteLine("accesstoken：{0}, send report:", kvp.Key);
                }
            }
            catch (MalformedException ex)
            {
                LOGGER.Fatal(ex.Message);
            }
            catch (NoValidKeyException ex)
            {
                LOGGER.Fatal(ex.Message);
            }
            catch (InvalidTokenException ex)
            {
                LOGGER.Fatal(ex.Message);
            }
            catch (Exception ex)
            {
                LOGGER.Fatal(ex.Message);
            }
        }

    }
}
