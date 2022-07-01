using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACES.Common
{
    public class HttpClient
    {
        public static string RequestWebAPI(string url, string sendData)
        {
            string backMsg = "";
            try
            {
                System.Net.WebRequest httpRquest = System.Net.HttpWebRequest.Create(url);
                httpRquest.Method = "POST";
                //这行代码很关键，不设置ContentType将导致后台参数获取不到值  
                httpRquest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                byte[] dataArray = System.Text.Encoding.UTF8.GetBytes(sendData);
                //httpRquest.ContentLength = dataArray.Length;  
                System.IO.Stream requestStream = null;
                if (String.IsNullOrEmpty(sendData) == false)
                {
                    requestStream = httpRquest.GetRequestStream();
                    requestStream.Write(dataArray, 0, dataArray.Length);
                    requestStream.Close();
                }
                System.Net.WebResponse response = httpRquest.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);
                backMsg = reader.ReadToEnd();


                reader.Close();
                reader.Dispose();


                requestStream.Dispose();
                responseStream.Close();
                responseStream.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return backMsg;
        }
    }
}
