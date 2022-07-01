using System;
using Newtonsoft.Json;


namespace Jd.ACES.Common
{

    public class JosSecretApiReportResponse
    {
        [JsonProperty("jingdong_jos_secret_api_report_get_responce")]
        public JosSecretApiReportResponseData getResponse { get; set; }
    }
    public class JosSecretApiReportResponseData
    {
        [JsonProperty("response")]
        public ReportData reportData { get; set; }

        [JsonProperty("code")]
        public String code { get; set; }

    }

    public class ReportData
    {
        [JsonProperty("errorCode")]
        public int errorCode { get; set; }
        [JsonProperty("errorMsg")]
        public String errorMsg { get; set; }
    }

}
