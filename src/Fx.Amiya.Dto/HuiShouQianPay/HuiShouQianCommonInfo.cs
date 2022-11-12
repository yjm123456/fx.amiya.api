using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class HuiShouQianCommonInfo
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
        public HuiShouQianPayRequestInfo SignContent { get; set; }
        //签名数据	
        public string Sign { get; set; }
        public HuiShouQianCommonInfo() {
            Method = "POLYMERIZE_MAIN_SWEPTN";
            Version = "1.0";
            Format = "json";
            MerchantNo = "";
            SignType = "RSA2";
        }
    }
}
