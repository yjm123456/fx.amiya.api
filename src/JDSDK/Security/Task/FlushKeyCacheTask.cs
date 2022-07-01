using System;
using System.Timers;
using log4net;
using Jd.ACES.Common.Exceptions;
using System.Collections.Generic;


namespace Jd.ACES.Task
{
    public class FlushKeyCacheTask
    {
        private static ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Task(Object obj, ElapsedEventArgs e)
        {
            LOGGER.Info("Key Management Thread Performs Key Updating...");
            // catch all exceptions
            try
            {
                Dictionary<string, TDEClient> clientPool = TDEClient.clientPool;
                LOGGER.Info("Key Management Thread Performs Key Updating..."+clientPool.Count);

                foreach (KeyValuePair<string, TDEClient> kvp in clientPool)
                {
                    TDEClient tdeClient = kvp.Value;
                    tdeClient.GetKMClient().Flush();
                    Console.WriteLine("accesstoken：{0}", kvp.Key);
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
