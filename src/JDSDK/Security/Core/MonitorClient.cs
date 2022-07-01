using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using log4net;
using Jd.ACES.Common;
using Jd.ACES.Utils;
using static Jd.ACES.Common.Constants;

namespace Jd.ACES
{
    public class MonitorClient
    {
        private static ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // key-value: int (event/excpetion code), string (report)
        private TDEConcurrentDictionary<int, string> reports = new TDEConcurrentDictionary<int, string>();
        private TDEClient parent = null;
        private bool setParaAlready = false;
        private string service = "Unknown Service";
        private string tid = "Unknown TID";
        private JosSecretApiReportRequest josSecretApiReportRequest = new JosSecretApiReportRequest();

        public MonitorClient(TDEClient p)
        {
            parent = p;
            InitJosApiRequest();
        }

        public void Task()
        {
            try
            {
                LOGGER.Debug("Monitor scheduler checks report cache.");
                // generate Statistic
                InsertStatisticReport();
                // send all buffered reports
                SendAllReports();
            }
            catch (Exception t)
            {
                // prevent the thread stops when Throwable exception occurs
                LOGGER.Fatal(t);
            }
        }

        public void SendAllReports()
        {
            // using thread-safe way
            ICollection<int> keys = reports.Keys;
            HashSet<int> removing = new HashSet<int>();
            foreach (int key in keys)
            {
                string singleReport = reports[key];
                if (SendReport(singleReport))
                {
                    removing.Add(key);
                }
            }
            reports.Remove(removing);

            if (reports.Count == 0)
            {
                LOGGER.Debug("Monitor flushed all messages.");
            }
            else
            {
                LOGGER.DebugFormat("Monitor buffered {0} messages in queue.", reports.Count);
            }
        }

        private bool SendReport(string report)
        {
            bool ret = false;
            try
            {
                String result = HttpsClientWrapper.PostJson(parent.josSystemParam.serverURL, report);
                JosSecretApiReportResponse josVoucherInfoGetResponse = JsonHelper.FromJson<JosSecretApiReportResponse>(result);
                if (josVoucherInfoGetResponse != null && josVoucherInfoGetResponse.getResponse.reportData.errorCode == 0)
                {
                    LOGGER.Debug("Monitor push reply:" + josVoucherInfoGetResponse.getResponse.reportData.errorMsg);
                    ret = true;
                }
                else
                {
                    LOGGER.Debug("Monitor push failed.");
                }
            }
            catch (Exception e)
            {
                LOGGER.Fatal(e.Message);
            }
            return ret;
        }
        public void InitJosApiRequest()
        {
            string accessToken = parent.josSystemParam.accessToken; ;
            josSecretApiReportRequest.serverUrl = parent.josSystemParam.serverURL;
            josSecretApiReportRequest.accessToken = accessToken;
            josSecretApiReportRequest.appKey = parent.josSystemParam.appKey;
            josSecretApiReportRequest.appSecret = parent.josSystemParam.appSecret;
            if (!string.IsNullOrEmpty(accessToken) && accessToken.StartsWith(Constants.UNDERLINE))
            {
                //添加自有账号逻辑，CustomerUserId为自有账号token
                string customerUserId = accessToken.Substring(1, accessToken.LastIndexOf(Constants.UNDERLINE) - 1);
                try
                {
                    josSecretApiReportRequest.customerUserId = Convert.ToInt64(customerUserId);
                }
                catch (Exception e)
                {
                    LOGGER.Error("token invalid", e);
                }
            }
        }
        private string ConvertToApiRequest(ProduceRequest produceRequest)
        {
            josSecretApiReportRequest.businessId = produceRequest.Messages[0].BusinessId;
            josSecretApiReportRequest.text = produceRequest.Messages[0].Text;
            josSecretApiReportRequest.attribute = JsonHelper.ToJson(produceRequest.Messages[0].Attributes);
            return josSecretApiReportRequest.getParameters();
        }

        public void InsertInitReport()
        {
            ProduceRequest req = ProduceRequest.GetInitRequest(service, tid);
            var report = ConvertToApiRequest(req);
            LOGGER.DebugFormat("add init report: {0}", report);
            // not error report but init report
            reports.Add(MsgType.INIT.GetValue(), report);
        }

        public void InsertStatisticReport()
        {
            long[] stat = null;
            if (parent != null) stat = parent.GetStatistic();

            ProduceRequest req = ProduceRequest.GetStatisticRequest(service, tid, stat);
            var report = ConvertToApiRequest(req);
            LOGGER.DebugFormat("add statistic report: {0}", report);
            // not error report but init report
            reports.Add(MsgType.STATISTIC.GetValue(), report);
        }

        public void InsertEventReport(int eventCode, string eventDetail)
        {
            ProduceRequest req = ProduceRequest.GetEventRequest(service, tid, eventCode, eventDetail);
            var report = ConvertToApiRequest(req);
            LOGGER.DebugFormat("add event report: {0}", report);
            // v2.0.x send event right the way

            SendReport(report);
        }

        public void InsertKeyUpdateEventReport(int eventcode, string eventDetail, uint major_key_ver, Dictionary<string, int> keylist)
        {
            ProduceRequest req = ProduceRequest.GetKPEventRequest(service, tid, eventcode, eventDetail, major_key_ver, keylist);
            var report = ConvertToApiRequest(req);
            LOGGER.DebugFormat("add keyupdate event report: {0}", report);
            // v2.0.x send event right the way
            // try to get auth token first
            SendReport(report);
        }

        public void InsertErrReport(int errcode, string detail, string stacktrace, MsgLevel level)
        {
            string detailLocal = detail ?? "";

            ProduceRequest req = ProduceRequest.GetErrorRequest(service, tid, level.GetValue(), errcode, detailLocal, stacktrace);
            var report = ConvertToApiRequest(req);
            LOGGER.DebugFormat("add error report: {0}", report);
            if (level.Equals(MsgLevel.ERROR) || level.Equals(MsgLevel.SEVERE))
            {
                // use main thread to send all all cached reports
                LOGGER.Debug("Send urgent messages.");
                SendReport(report);
            }
            else
            {
                // buffer it
                reports.Add(errcode, report);
            }
        }

        public void SetProductionEnv()
        {
            // check parameters set of not
            if (!setParaAlready)
            {
                if (parent != null)
                {
                    service = parent.GetServiceIdentifier();
                    tid = parent.GetTokenIdentifier();
                }
                // send init report for 1st call
                setParaAlready = true;
                this.InsertInitReport();
            }
        }
    }


    public class ProduceRequest
    {
        [JsonProperty("messages")]
        public List<BasicMessage> Messages { get; set; }

        public ProduceRequest(List<BasicMessage> messages)
        {
            this.Messages = messages;
        }
        public static ProduceRequest GetInitRequest(string service, string tid)
        {
            List<BasicMessage> l = new List<BasicMessage>
            {
                new InitMessage(service, tid)
            };
            return new ProduceRequest(l);
        }

        public static ProduceRequest GetEventRequest(string service, string tid, int event_code, string evt)
        {
            List<BasicMessage> l = new List<BasicMessage>
            {
                new EventMessage(service, tid, event_code, evt)
            };
            return new ProduceRequest(l);
        }

        public static ProduceRequest GetKPEventRequest(string service, string tid, int event_code, string evt, uint major_kver, Dictionary<string, int> keylist)
        {
            List<BasicMessage> l = new List<BasicMessage>
            {
               new KPEventMessage(service, tid, event_code, evt, major_kver, keylist)
            };
            return new ProduceRequest(l);
        }

        public static ProduceRequest GetErrorRequest(string service, string tid, int level, int err_code, string err_msg, string stack_trace)
        {
            List<BasicMessage> l = new List<BasicMessage>
            {
               new ErrorMessage(service, tid, level, err_code, err_msg, stack_trace)
            };
            return new ProduceRequest(l);
        }

        public static ProduceRequest GetStatisticRequest(string service, string tid, long[] stat)
        {
            List<BasicMessage> l = new List<BasicMessage>
            {
               new StatisticMessage(service, tid, stat)
            };
            return new ProduceRequest(l);
        }
    }

    public class BasicMessage
    {
        [JsonProperty("businessId")]
        public string BusinessId { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("attributes")]
        public BasicAttribute Attributes { get; set; }

        public static string GetRandomString()
        {
            Random r = new Random(Environment.TickCount);
            char[] chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz=+-*/_|<>^~@?%&".ToCharArray();
            StringBuilder buffer = new StringBuilder(40);
            for (int i = 0; i < 40; i++)
            {
                int rc = r.Next(40);
                buffer.Append(chars[rc]);
            }
            return buffer.ToString();
        }
    }

    public class BasicAttribute
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("host")]
        public string Host { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("service")]
        public string Service { get; set; }
        [JsonProperty("tid")]
        public string Tid { get; set; }
        [JsonProperty("env")]
        public string Env { get; set; }
        [JsonProperty("ts")]
        public long Ts { get; set; }
        [JsonProperty("sdk_ver")]
        public string SdkVer { get; set; }

        public BasicAttribute(int type, int level, string service, string tid)
        {
            this.Type = type;
            this.Host = EnvironmentHelper.GetHost();
            this.Level = level;
            this.Service = service;
            this.Tid = tid;
            this.SdkVer = TDEClient.GetSDKVersion();
            this.Env = EnvironmentHelper.GetSystemInfo();
            this.Ts = EnvironmentHelper.GetCurrentMillis();
        }
    }

    public class EventAttribute : BasicAttribute
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("event")]
        public string Event { get; set; }
        public EventAttribute(int type, int level, string service, string tid, int code, string evt)
            : base(type, level, service, tid)
        {
            this.Code = code;
            this.Event = evt;
        }
    }

    public class KPEventAttribute : EventAttribute
    {
        [JsonProperty("cur_key")]
        public uint CurKey { get; set; }
        [JsonProperty("keylist")]
        public Dictionary<string, int> KeyList { get; set; }
        public KPEventAttribute(int type, int level, string service, string tid, int code, string evt, uint major_kver, Dictionary<string, int> keylist)
            : base(type, level, service, tid, code, evt)
        {
            this.KeyList = keylist;
            this.CurKey = major_kver;
        }
    }

    public class ErrorAttribute : BasicAttribute
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("heap")]
        public string Heap { get; set; }
        public ErrorAttribute(int type, int level, string service, string tid, int err_code, string err_msg, string stacktrace)
                  : base(type, level, service, tid)
        {
            this.Code = err_code;
            this.Msg = err_msg;
            this.Heap = stacktrace;
        }
    }

    public class StatisticAttribute : BasicAttribute
    {
        [JsonProperty("enccnt")]
        public string Enccnt { get; set; }
        [JsonProperty("deccnt")]
        public string Deccnt { get; set; }
        [JsonProperty("encerrcnt")]
        public string Encerrcnt { get; set; }
        [JsonProperty("decerrcnt")]
        public string Decerrcnt { get; set; }
        [JsonProperty("signcnt")]
        public string Signcnt { get; set; }
        [JsonProperty("verifycnt")]
        public string Verifycnt { get; set; }
        [JsonProperty("signerrcnt")]
        public string Signerrcnt { get; set; }
        [JsonProperty("verifyerrcnt")]
        public string Verifyerrcnt { get; set; }
        public StatisticAttribute(int type, int level, string service, string tid, long[] stat)
            : base(type, level, service, tid)
        {
            this.Enccnt = (stat == null) ? "0" : stat[0].ToString();
            this.Deccnt = (stat == null) ? "0" : stat[1].ToString();
            this.Encerrcnt = (stat == null) ? "0" : stat[2].ToString();
            this.Decerrcnt = (stat == null) ? "0" : stat[3].ToString();
            this.Signcnt = (stat == null) ? "0" : stat[4].ToString();
            this.Verifycnt = (stat == null) ? "0" : stat[5].ToString();
            this.Signerrcnt = (stat == null) ? "0" : stat[6].ToString();
            this.Verifyerrcnt = (stat == null) ? "0" : stat[7].ToString();
        }
    }
    public class InitMessage : BasicMessage
    {
        public InitMessage(string service, string tid)
        {
            this.BusinessId = BasicMessage.GetRandomString();
            this.Text = MsgType.INIT.ToString();
            this.Attributes = new BasicAttribute((int)MsgType.INIT, (int)MsgLevel.INFO, service, tid);
        }
    }

    public class EventMessage : BasicMessage
    {
        public EventMessage(string service, string tid, int event_code, string evt)
        {
            this.BusinessId = BasicMessage.GetRandomString();
            this.Text = MsgType.EVENT.ToString();
            this.Attributes = new EventAttribute((int)MsgType.EVENT, (int)MsgLevel.INFO, service, tid, event_code, evt);
        }
    }

    public class KPEventMessage : BasicMessage
    {
        public KPEventMessage(string service, string tid, int event_code, string evt, uint major_kver, Dictionary<string, int> keylist)
        {
            this.BusinessId = BasicMessage.GetRandomString();
            this.Text = MsgType.EVENT.ToString();
            this.Attributes = new KPEventAttribute((int)MsgType.EVENT, (int)MsgLevel.INFO, service, tid, event_code, evt, major_kver, keylist);
        }
    }

    public class ErrorMessage : BasicMessage
    {
        public ErrorMessage(string service, string tid, int level, int err_code, string err_msg, string stacktrace)
        {
            this.BusinessId = BasicMessage.GetRandomString();
            this.Text = MsgType.EXCEPTION.ToString();
            this.Attributes = new ErrorAttribute((int)MsgType.EXCEPTION, level, service, tid, err_code, err_msg, stacktrace);
        }
    }

    public class StatisticMessage : BasicMessage
    {
        public StatisticMessage(string service, string tid, long[] stat)
        {
            this.BusinessId = BasicMessage.GetRandomString();
            this.Text = MsgType.STATISTIC.ToString();
            this.Attributes = new StatisticAttribute((int)MsgType.STATISTIC, (int)MsgLevel.INFO, service, tid, stat);
        }
    }
}