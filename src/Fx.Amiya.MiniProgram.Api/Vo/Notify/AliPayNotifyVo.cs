using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Notify
{
    /// <summary>
    /// 支付宝支付接收回调信息
    /// </summary>
    public class AliPayNotifyVo
    {
        public string notify_id { get; set; }
        public string notify_time { get; set; }

        public string notify_type { get; set; }
        public string sign_type { get; set; }
        public string sign { get; set; }


        public string out_trade_no { get; set; }

        public string subject { get; set; }

        public string payment_type { get; set; }

        public string trade_no { get; set; }

        public string trade_status { get; set; }
        public string gmt_create { get; set; }
        public string gmt_payment { get; set; }
        public string gmt_close { get; set; }
        public string seller_email { get; set; }
        public string buyer_email { get; set; }
        public string seller_id { get; set; }
        public string buyer_id { get; set; }
        public string price { get; set; }
        public string total_fee { get; set; }
        public string quantity { get; set; }
        public string body { get; set; }
        public string discount { get; set; }
        public string is_total_fee_adjust { get; set; }
        public string use_coupon { get; set; }
        public string refund_status { get; set; }
        public string gmt_refund { get; set; }

    }
}
