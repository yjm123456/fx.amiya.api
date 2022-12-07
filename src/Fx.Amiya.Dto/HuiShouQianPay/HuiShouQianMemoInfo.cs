using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    /// <summary>
    /// 业务请求参数Memo参数域
    /// </summary>
    public class HuiShouQianMemoInfo
    {
        //订单失效时间，格式[yyyyMMddHHmmss]
        public string TimeExpire { get; set; }
        //限制卡类型	
        //限制不能使用的支付类型
        //微信：no_credit--指定不能使用信用卡支付
        public string paylimit { get; set; }
        //微信公众号APPID
        public string appid { get; set; }
        //用户在商户appid下的唯一标识。下单前需获取到用户的Openid，获取详见微信,支付宝
        public string openid { get; set; }
        //消费者端IP
        public string SpbillCreateIp { get; set; }
        //交易所在地经度 用于交易地点定位
        public string Longitude { get; set; }
        //交易所在地纬度 用于交易地点定位
        public string Latitude { get; set; }
        //银联选填 区域信息 长度固定7
        public string AreaInfo { get; set; }
        //银联选填 固定8位，长度不足右补空格
        public string AppVersion { get; set; }
        //银联选填 终端设备类型
        public string DeviceType { get; set; }
        //银联选填 最多50位，终端设备的硬件序列号
        public string DeviceNo { get; set; }
        public HuiShouQianMemoInfo() {
            TimeExpire = "";
            paylimit= "";
            appid ="wx695942e4818de445";
            SpbillCreateIp = "47.114.37.45";
            Longitude = "119.95720242";
            Latitude = "29.15949412";
            AreaInfo = "";
            AppVersion = "";
            DeviceType = "";
            DeviceNo = "";
        }
    }
}
