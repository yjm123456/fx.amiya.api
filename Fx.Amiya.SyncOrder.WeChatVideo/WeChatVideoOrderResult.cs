using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeChatVideo
{
    public class WeChatVideoOrderResult
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public Order order { get; set; }
    }
    public class Order {
        public int create_time { get; set; }
        public int update_time { get; set; }
        public string order_id { get; set; }
        public int status { get; set; }
        public string openid { get; set; }
        public string unionid { get; set; }
        public OrderDetail order_detail { get; set; }
        public AfterSaleDetail aftersale_detail { get; set; }
    }
    public class OrderDetail {
        public List<ProductInfo> product_infos { get; set; }
        public PriceInfo price_info { get; set; }
        public PayInfo pay_info { get; set; }
        public DeliveryInfo delivery_info { get; set; }
        public CouponInfo coupon_info { get; set; }
        public ExtInfo ext_info { get; set; }
        public List<CommissionInfo> commission_infos { get; set; }
        public SharerInfo sharer_info { get; set; }
        public SettleInfo settle_info { get; set; }
    }
    public class ProductInfo {
        public string product_id { get; set; }
        public string sku_id { get; set; }
        public string thumb_img { get; set; }
        public int sku_cnt { get; set; }
        public int sale_price { get; set; }
        public string title { get; set; }
        public int on_aftersale_sku_cnt { get; set; }
        public int finish_aftersale_sku_cnt { get; set; }
        public string sku_code { get; set; }
        public int market_price { get; set; }
        public List<AtrrInfo> sku_attrs { get; set; }
        public int real_price { get; set; }
        public string out_product_id { get; set; }
        public string out_sku_id { get; set; }
        public bool is_discounted { get; set; }
        public int estimate_price { get; set; }
        public bool is_change_price { get; set; }
        public int change_price { get; set; }
        public string out_warehouse_id { get; set; }
    }
    public class AtrrInfo {
        public string attr_key { get; set; }
        public string attr_value { get; set; }
    }
    public class PriceInfo {
        public int product_price { get; set; }
        public int order_price { get; set; }
        public int freight { get; set; }
        public int discounted_price { get; set; }
        public bool is_discounted { get; set; }
        public int original_order_price { get; set; }
        public int estimate_product_price { get; set; }
        public int change_down_price { get; set; }
        public int change_freight { get; set; }
        public bool is_change_freight { get; set; }
    }
    public class PayInfo {
        public string prepay_id { get; set; }
        public int prepay_time { get; set; }
        public int pay_time { get; set; }
        public string transaction_id { get; set; }
    }
    public class DeliveryInfo {
        public AddressInfo address_info { get; set; }
        public List<DeliveryProductInfo> delivery_product_info { get; set; }
        public int ship_done_time { get; set; }
        public int deliver_method { get; set; }
    }
    public class AddressInfo {
        public string user_name { get; set; }
        public string postal_code { get; set; }
        public string province_name { get; set; }
        public string city_name { get; set; }
        public string county_name { get; set; }
        public string detail_info { get; set; }
        public string national_code { get; set; }
        public string tel_number { get; set; }
        public string house_number { get; set; }
        public string virtual_order_tel_number { get; set; }
    }
    public class DeliveryProductInfo {
        public string waybill_id { get; set; }
        public string delivery_id { get; set; }
        public List<FreightProductInfo> product_infos { get; set; }
        public string delivery_name { get; set; }
        public int delivery_time { get; set; }
        public int deliver_type { get; set; }
        public AddressInfo delivery_address { get; set; }
    }
    public class FreightProductInfo {
        public string product_id { get; set; }
        public string sku_id { get; set; }
        public int product_cnt { get; set; }
    }
    public class CouponInfo {
        public string user_coupon_id { get; set; }
    }
    public class ExtInfo {
        public string customer_notes { get; set; }
        public string merchant_notes { get; set; }
    }
    public class CommissionInfo {
        public string sku_id { get; set; }
        public string nickname { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public int amount { get; set; }
        public string finder_id { get; set; }
    }
    public class SharerInfo {
        public string sharer_openid { get; set; }
        public string sharer_unionid { get; set; }
        public int sharer_type { get; set; }
        public int share_scene { get; set; }
    }
    public class SettleInfo {
        public int predict_commission_fee { get; set; }
        public int commission_fee { get; set; }
    }
    public class AfterSaleDetail {
        public int on_aftersale_order_cnt { get; set; }
        public List<AfterSaleOrderInfo> aftersale_order_list { get; set; }
    }
    public class AfterSaleOrderInfo {
        public string aftersale_order_id { get; set; }
        public int status { get; set; }
    }
}
