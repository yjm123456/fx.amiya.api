using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeiFenXiao.WeiFenXiaoAppInfoConfig
{
    public class WeiFenXiaoOrderResult
    {
        public List<WeiFenXiaoOrderInfo> orderList { get; set; }
        public int total { get; set; }
        public int page_no { get; set; }
        public int page_size { get; set; }
    }
    public class WeiFenXiaoOrderInfo
    {
        public string order_id { get; set; }
        public string order_no { get; set; }
        public string user_id { get; set; }
        public string payment { get; set; }
        public string balance_fee { get; set; }
        public string total_fee { get; set; }
        public string tax_fee { get; set; }
        public string address_id { get; set; }
        public string receiver_name { get; set; }
        public string receiver_mobile { get; set; }
        public string receiver_zip { get; set; }
        public string post_fee { get; set; }
        public string points { get; set; }
        public string point_fee { get; set; }
        public string coupon_fee { get; set; }
        public string adjust_fee { get; set; }
        public string status { get; set; }
        public string create_time { get; set; }
        public string pay_time { get; set; }
        public string delivery_time { get; set; }
        public string end_time { get; set; }
        public string message { get; set; }
        public string remark { get; set; }
        public string express { get; set; }
        public string express_name { get; set; }
        public string express_no { get; set; }
        public string join_level_discount { get; set; }
        public string superior_user_id { get; set; }
        public string top_user_id { get; set; }
        public string three_user_id { get; set; }
        public string superior_commission { get; set; }
        public string top_commission { get; set; }
        public string three_commission { get; set; }
        public string superior_dls_id { get; set; }
        public string top_dls_id { get; set; }
        public string three_dls_id { get; set; }
        public string superior_dls_commission { get; set; }
        public string top_dls_commission { get; set; }
        public string three_dls_commission { get; set; }
        public string is_del { get; set; }
        public string del_type { get; set; }
        public string have_balance { get; set; }
        public string pay_trade_no { get; set; }
        public string pay_type { get; set; }
        public string order_update_time { get; set; }
        public string is_presale { get; set; }
        public string presale_status { get; set; }
        public string receiver_address { get; set; }
        public string group_shopping_id { get; set; }
        public string shipping_type { get; set; }
        public string is_send_gift { get; set; }
        public string store_id { get; set; }
        public string first_remission_price { get; set; }
        public string virtual_currency { get; set; }
        public string virtual_currency_fee { get; set; }
        public string backed_order_type { get; set; }
        public string is_dhs_virtual { get; set; }
        public string dls_id { get; set; }
        public string is_self_take { get; set; }
        public string self_address_id { get; set; }
        public string self_take_address { get; set; }
        public string real_openid { get; set; }
        public string mobile { get; set; }
        public string card { get; set; }
        public string full_subtract_money { get; set; }
        public string marketing_order_source { get; set; }
        public string receiver_province { get; set; }
        public string receiver_city { get; set; }
        public string receiver_area { get; set; }
        public string self_take_storeid { get; set; }
        public string self_take_store_name { get; set; }
        public string user_nickname { get; set; }
        public string unionid { get; set; }

        public List<WeiFenXiaoGoodsInfo> childList { get; set; }
    }

    public class WeiFenXiaoGoodsInfo
    {
        public string order_item_id { get; set; }
        public string item_id { get; set; }
        public string item_title { get; set; }
        public string current_price { get; set; }
        public string item_tax_fee { get; set; }
        public string sku_id { get; set; }
        public string sku_name { get; set; }
        public string num { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public string supplier_express { get; set; }
        public string supplier_express_no { get; set; }
        public string supplier_post_fee { get; set; }
        public string supplier_cost_price { get; set; }
        public string deposit_money { get; set; }
        public string item_cycle_buy_id { get; set; }
        public string item_miao_id { get; set; }
        public string item_limit_discount_id { get; set; }
        public string item_bargin_id { get; set; }
        public string item_packageprice_active_id { get; set; }
        public string sku_no { get; set; }
        public string goods_no { get; set; }
        public string new_supplier_id { get; set; }
        public string item_url { get; set; }
        public string item_img { get; set; }
        public string supplier_name { get; set; }
    }

    public class WeiFenXiaoUserInfo
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        ///  创建时间（时间戳）
        /// </summary>
        public string create_time { get; set; }

        /// <summary>
        /// 虚拟币
        /// </summary>
        public string virtual_currency { get; set; }

        /// <summary>
        /// 当前积分
        /// </summary>
        public string points { get; set; }

        /// <summary>
        /// 直属上级ID
        /// </summary>
        public string superior_user_id { get; set; }

        /// <summary>
        /// 二级上级ID
        /// </summary>
        public string top_user_id { get; set; }

        /// <summary>
        /// 三级上级ID
        /// </summary>
        public string three_user_id { get; set; }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 微信unionid
        /// </summary>
        public string unionid { get; set; }
        /// <summary>
        /// 是否关注公众号（0:未关注；1:已关注）	
        /// </summary>

        public string subscribe { get; set; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        ///  性别（1:男性；2：女性；0:未知）	
        /// </summary>
        public string sex { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        public string headimgurl { get; set; }

        /// <summary>
        /// 直属上级unionid
        /// </summary>
        public string superior_user_unionid { get; set; }

        /// <summary>
        /// 二级上级unionid
        /// </summary>
        public string top_user_unionid { get; set; }

        /// <summary>
        /// 三级上级unionid
        /// </summary>
        public string three_user_unionid { get; set; }

        /// <summary>
        /// 是否为分销商
        /// </summary>
        public string is_agent { get; set; }

        /// <summary>
        /// 总订单笔数
        /// </summary>
        public string total_count { get; set; }

        /// <summary>
        /// 总消费金额
        /// </summary>
        public string total_price { get; set; }

        /// <summary>
        /// 总共获得的积分
        /// </summary>
        public string total_points { get; set; }

        /// <summary>
        /// 会员等级id
        /// </summary>
        public string rank_id { get; set; }

        /// <summary>
        /// 会员等级名称
        /// </summary>
        public string rank_name { get; set; }

        /// <summary>
        /// 买家账户余额
        /// </summary>
        public string balance { get; set; }

        /// <summary>
        /// 佣金余额
        /// </summary>
        public string remaining_commission { get; set; }

        /// <summary>
        /// 会员信息最近更新时间
        /// </summary>
        public string user_update_time { get; set; }

    }
}
