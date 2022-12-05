using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPayNotify
{
    public class HuiShouQianNotifyCommonParam
    {
        public string method { get; set; }
        public string version { get; set; }
        public string format { get; set; }
        public string merchantNo { get; set; }
        public string signType { get; set; }
        public HuiShouQianNotifyParam signContent { get; set; }
        public string sign { get; set; }
    }
    public class HuiShouQianNotifyParam
    {
        public string transNo { get; set; }
        public string tradeNo { get; set; }
        public string orderAmt { get; set; }
        public string orderStatus { get; set; }
        public string finishedDate { get; set; }
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string payType { get; set; }
        public string goodsInfo { get; set; }
        public string requestDate { get; set; }
        public string buyerName { get; set; }
        public string channelOrderNo { get; set; }
        public string payOrderNo { get; set; }
        public string fundChannel { get; set; }
        public string fundBankCode { get; set; }
        public string extend { get; set; }
    }
    public class HuiShouQianNotifyMemoParam
    {
        public string paylimit { get; set; }
        public string timeExpire { get; set; }
        public string openid { get; set; }
        public string appid { get; set; }
        public string spbillCreateIp { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string areaInfo { get; set; }
        public string appVersion { get; set; }
        public string deviceType { get; set; }
        public string deviceNo { get; set; }
    }
}
