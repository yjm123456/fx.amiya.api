using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    /// <summary>
    /// 慧收钱退款公共请求参数
    /// </summary>
    public class HuiShouQianRefundCommonParam
    {
        //方法名 POLYMERIZE_MAIN_SWEPTN
        public string Method { get; set; }
        //接口版本：1.0
        public string Version { get; set; }
        //业务请求参数格式，支持：JSON、XML
        public string Format { get; set; }
        //商户在慧收钱的商户号，由慧收钱生成并下发
        public string MerchantNo { get; set; }
        //加密类型	
        public string SignType { get; set; }
        //业务数据	
        public HuiShouQianRefundRequestParam SignContent { get; set; }
        //签名数据	
        public string Sign { get; set; }
        public HuiShouQianRefundCommonParam()
        {
            Method = "POLYMERIZE_REFUND";
            Version = "1.0";
            Format = "JSON";
            MerchantNo = "864001883569";
            SignType = "RSA2";
        }
    }
}
