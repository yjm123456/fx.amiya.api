using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HuiShouQianPay
{
    public class HuiShouQianPayRequestInfo
    {
        //商户在支付平台创建生成的门店编号
        /*public string SubMerchantNo { get; private set; }*/
        //商户系统内部订单号，唯一不重复
        public string TransNo { get; set; }
        //ALI_APPLET：支付宝
        //WECHAT_APPLET：微信
        public string PayType { get; set; }
        //用户支付完成后，慧收钱服务器主动通知商户服务器里指定地址
        public string ReturnUrl { get; set; }
        //用户支付完成后，前台页面跳转到指定地址
        public string PageUrl { get; set; }
        //交易金额，单位为：分
        public string OrderAmt { get; set; }
        //商品说明
        public string GoodsInfo { get; set; }
        //请求时间，与当前系统时间相差小于10分钟，格式[yyyyMMddHHmmss]
        public string RequestDate { get; set; }
        //附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用
        public string Extend { get; set; }
        //扩展信息 json格式
        public HuiShouQianMemoInfo Memo { get; set; }
        public HuiShouQianPayRequestInfo()
        {                
            this.ReturnUrl = string.Format("{0}/amiya/wxmini/Notify/hsqPayResult", "http://ymjxui.gnway.cc");
            this.PageUrl ="" ;
        }
    }
}
