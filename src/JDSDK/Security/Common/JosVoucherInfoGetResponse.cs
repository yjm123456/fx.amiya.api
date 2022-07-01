using System;
using Newtonsoft.Json;

namespace Jd.ACES.Common
{
    public class JosVoucherInfoGetResponse
    {
        [JsonProperty("jingdong_jos_voucher_info_get_responce")]
        public VoucherInfoResponseData getResult { get; set; }
    }
    public class VoucherInfoResponseData
    {
        [JsonProperty("response")]
        public ResponseData responseData { get; set; }

        [JsonProperty("code")]
        public String code { get; set; }

    }
    public class ResponseData
    {
        [JsonProperty("data")]
        public VoucherEntity voucherEntity { get; set; }
        [JsonProperty("errorCode")]
        public string errorCode { get; set; }
        [JsonProperty("errorMsg")]
        public string errorMsg { get; set; }
    }
    public class VoucherEntity
    {
        [JsonProperty("voucher")]
        public string voucher { get; set; }
    }
}
