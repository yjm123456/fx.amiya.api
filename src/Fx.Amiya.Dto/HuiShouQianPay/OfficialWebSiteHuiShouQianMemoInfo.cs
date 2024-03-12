using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class OfficialWebSiteHuiShouQianMemoInfo
    {
        //订单失效时间，格式[yyyyMMddHHmmss]
        public string TimeExpire { get; set; }
        //限制卡类型	
        //限制不能使用的支付类型
        //微信：no_credit--指定不能使用信用卡支付
        public string paylimit { get; set; }
        //消费者端IP
        public string SpbillCreateIp { get; set; }
        //交易所在地经度 用于交易地点定位
        public string Longitude { get; set; }
        //交易所在地纬度 用于交易地点定位
        public string Latitude { get; set; }
       
        public OfficialWebSiteHuiShouQianMemoInfo()
        {
            TimeExpire = "";
            paylimit = "";
            Longitude = "119.95720242";
            Latitude = "29.15949412";
        }
    }
}
