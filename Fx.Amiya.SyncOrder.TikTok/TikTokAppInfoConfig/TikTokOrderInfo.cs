using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.TikTok.TikTokAppInfoConfig
{
    public class TikTokOrderResult
    {
        public int err_no { get; set; }
        public Order data { get; set; }
        
        
    }
    public class Order {
        public List<TikTokOrderInfo> shop_order_list { get; set; }
        public long total { get; set; }
        public long page { get; set; }
        public long size { get; set; }
    }
    public class TikTokOrderInfo
    {

        public long shop_id { get; set; }
        public string shop_name { get; set; }
        public string open_id { get; set; }
        public string order_id { get; set; }
        public long order_level { get; set; }
        public long biz { get; set; }
        public string biz_desc { get; set; }
        public long order_type { get; set; }
        public string order_type_desc { get; set; }
        public long trade_type { get; set; }
        public string trade_type_desc { get; set; }
        public long order_status { get; set; }
        public string order_status_desc { get; set; }
        public long main_status { get; set; }
        public string main_status_desc { get; set; }
        public string pay_time { get; set; }
        public long order_expire_time { get; set; }
        public long finish_time { get; set; }
        public long create_time { get; set; }
        public long update_time { get; set; }
        public string cancel_reason { get; set; }
        public string buyer_words { get; set; }
        public string seller_words { get; set; }
        public long b_type { get; set; }
        public string b_type_desc { get; set; }
        public long sub_b_type { get; set; }
        public string sub_b_type_desc { get; set; }
        public long app_id { get; set; }
        public long pay_type { get; set; }
        public string channel_payment_no { get; set; }
        public long order_amount { get; set; }
        public long pay_amount { get; set; }
        public long post_amount { get; set; }
        public long post_insurance_amount { get; set; }
        public long modify_amount { get; set; }
        public long modify_post_amount { get; set; }
        public long promotion_amount { get; set; }
        public long promotion_shop_amount { get; set; }
        public long promotion_platform_amount { get; set; }
        public long shop_cost_amount { get; set; }
        public long platform_cost_amount { get; set; }
        public long promotion_talent_amount { get; set; }
        public long promotion_pay_amount { get; set; }
        public string encrypt_post_tel { get; set; }
        public string encrypt_post_receiver { get; set; }
        public long exp_ship_time { get; set; }
        public long ship_time { get; set; }
        public long seller_remark_stars { get; set; }
        public string doudian_open_id { get; set; }
        public List<string> serial_number_list { get; set; }
        public long promotion_redpack_amount { get; set; }
        public long promotion_redpack_platform_amount { get; set; }
        public long promotion_redpack_talent_amount { get; set; }
        public long appolongment_ship_time { get; set; }
        public long total_promotion_amount { get; set; }
        public long post_origin_amount { get; set; }
        public long post_promotion_amount { get; set; }
        public long author_cost_amount { get; set; }
        public long only_platform_cost_amount { get; set; }
        public string promise_info { get; set; }
        public List<TikTokUserTagUi> user_tag_ui { get; set; }
        public List<TikTokShopOrderTagUi> shop_order_tag_ui { get; set; }
        public TikTokDCarShopBizData d_car_shop_biz_data { get; set; }
        public TikTokUserIdInfo user_id_info { get; set; }
        public List<TikTokOrderPhaseList> order_phase_list { get; set; }
        public TikTokPostAddressInfo post_addr { get; set; }
        public List<TikTokLogistics> logistics_info { get; set; }
        public List<TikTokSkuOrderList> sku_order_list { get; set; }
    }
    public class TikTokUserTagUi
    {
        public string key { get; set; }
        public string text { get; set; }
    }

    public class TikTokShopOrderTagUi
    {
        public string key { get; set; }
        public string text { get; set; }
        public string help_doc { get; set; }
    }
    public class TikTokDCarShopBizData
    {
        public string poi_id { get; set; }
        public string poi_name { get; set; }
        public string poi_addr { get; set; }
        public string poi_tel { get; set; }
        public string poi_pname { get; set; }
        public string poi_city_name { get; set; }
        public string poi_adname { get; set; }
        public List<TikTokCouponRight> coupon_right { get; set; }
    }
    public class TikTokCouponRight
    {
        public long right_type { get; set; }
        public string right_name { get; set; }
        public long quota { get; set; }
    }
    public class TikTokUserIdInfo
    {
        public string encrypt_id_card_no { get; set; }
        public string encrypt_id_card_name { get; set; }
    }
    public class TikTokOrderPhaseList
    {
        public string phase_order_id { get; set; }
        public long total_phase { get; set; }
        public long current_phase { get; set; }
        public bool pay_success { get; set; }
        public string sku_order_id { get; set; }
        public long campaign_id { get; set; }
        public long phase_payable_price { get; set; }
        public long phase_pay_type { get; set; }
        public long phase_open_time { get; set; }
        public long phase_pay_time { get; set; }
        public long phase_close_time { get; set; }
        public string channel_payment_no { get; set; }
        public long phase_order_amount { get; set; }
        public long phase_sum_amount { get; set; }
        public long phase_post_amount { get; set; }
        public long phase_pay_amount { get; set; }
        public long phase_promotion_amount { get; set; }
        public string current_phase_status_desc { get; set; }
        public long sku_price { get; set; }
    }


    public class TikTokPostAddressInfo
    {
        public TikTokAddressProvince province { get; set; }
        public TikTokAddressCity city { get; set; }
        public TikTokAddressTown town { get; set; }
        public TikTokAddressStreet street { get; set; }
        public string encrypt_detail { get; set; }
    }
    public class TikTokAddressProvince
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    public class TikTokAddressCity
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class TikTokAddressTown
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class TikTokAddressStreet
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class TikTokLogistics
    {
        public string tracking_no { get; set; }
        public string company { get; set; }
        public long ship_time { get; set; }
        public string delivery_id { get; set; }
        public string company_name { get; set; }
        public List<TikTokProductInfo> product_info { get; set; }
    }
    public class TikTokProductInfo
    {
        public string product_name { get; set; }
        public long price { get; set; }
        public string outer_sku_id { get; set; }
        public long sku_id { get; set; }
        public long product_id { get; set; }
        public string sku_order_id { get; set; }
        public string product_id_str { get; set; }
        public List<TikTokSkuSpecs> sku_specs { get; set; }
    }
    public class TikTokSkuSpecs
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class TikTokSkuOrderList
    {
        public string order_id { get; set; }
        public string parent_order_id { get; set; }
        public long order_level { get; set; }
        public long biz { get; set; }
        public string biz_desc { get; set; }
        public long order_type { get; set; }
        public string order_type_desc { get; set; }
        public long trade_type { get; set; }
        public string trade_type_desc { get; set; }
        public long order_status { get; set; }
        public string order_status_desc { get; set; }
        public long main_status { get; set; }
        public string main_status_desc { get; set; }
        public long pay_time { get; set; }
        public long order_expire_time { get; set; }
        public long finish_time { get; set; }
        public long create_time { get; set; }
        public long update_time { get; set; }
        public string cancel_reason { get; set; }
        public long b_type { get; set; }
        public string b_type_desc { get; set; }
        public long sub_b_type { get; set; }
        public string sub_b_type_desc { get; set; }
        public long send_pay { get; set; }
        public string send_pay_desc { get; set; }
        public long author_id { get; set; }
        public string author_name { get; set; }
        public string theme_type { get; set; }
        public string theme_type_desc { get; set; }
        public long app_id { get; set; }
        public long room_id { get; set; }
        public string content_id { get; set; }
        public string video_id { get; set; }
        public string origin_id { get; set; }
        public long cid { get; set; }
        public long c_biz { get; set; }
        public string c_biz_desc { get; set; }
        public long page_id { get; set; }
        public long pay_type { get; set; }
        public string channel_payment_no { get; set; }
        public long order_amount { get; set; }
        public long pay_amount { get; set; }
        public long post_insurance_amount { get; set; }
        public long modify_amount { get; set; }
        public long modify_post_amount { get; set; }
        public long promotion_amount { get; set; }
        public long promotion_shop_amount { get; set; }
        public long promotion_platform_amount { get; set; }
        public long shop_cost_amount { get; set; }
        public long platform_cost_amount { get; set; }
        public long promotion_talent_amount { get; set; }
        public long promotion_pay_amount { get; set; }
        public string code { get; set; }
        public string encrypt_post_tel { get; set; }
        public string encrypt_post_receiver { get; set; }
        public long exp_ship_time { get; set; }
        public long ship_time { get; set; }
        public long logistics_receipt_time { get; set; }
        public long confirm_receipt_time { get; set; }
        public long goods_type { get; set; }
        public long product_id { get; set; }
        public long sku_id { get; set; }
        public long first_cid { get; set; }
        public long second_cid { get; set; }
        public long third_cid { get; set; }
        public long fourth_cid { get; set; }
        public string out_sku_id { get; set; }
        public string supplier_id { get; set; }
        public string out_product_id { get; set; }
        public string inventory_type { get; set; }
        public string inventory_type_desc { get; set; }
        public long reduce_stock_type { get; set; }
        public string reduce_stock_type_desc { get; set; }
        public long origin_amount { get; set; }
        public bool has_tax { get; set; }
        public long item_num { get; set; }
        public long sum_amount { get; set; }
        public string source_platform { get; set; }
        public string product_pic { get; set; }
        public long is_comment { get; set; }
        public string product_name { get; set; }
        public long post_amount { get; set; }
        public long pre_sale_type { get; set; }
        public long promotion_redpack_amount { get; set; }
        public long promotion_redpack_platform_amount { get; set; }
        public long promotion_redpack_talent_amount { get; set; }
        public long receive_type { get; set; }
        public bool need_serial_number { get; set; }
        public string ad_env_type { get; set; }
        public string product_id_str { get; set; }
        public long appointment_ship_time { get; set; }
        public string room_id_str { get; set; }
        public string given_product_type { get; set; }
        public string master_sku_order_id { get; set; }
        public long author_cost_amount { get; set; }
        public long only_platform_cost_amount { get; set; }
        public string promise_info { get; set; }
        public TikTokAccountList account_list { get; set; }
        public List<TikTokBundleSkuInfo> bundle_sku_info { get; set; }
        public TikTokCardVoucher card_voucher { get; set; }
        public List<TikTokSkuOrderTagUi> sku_order_tag_ui { get; set; }
        public TikTokAfterSaleInfo after_sale_info { get; set; }
        public List<string> out_warehouse_ids { get; set; }
        public TikTokPostAddressInfo post_addr { get; set; }
        public List<TikTokSkuSpecs> spec { get; set; }
        public List<TikTokInventoryList> inventory_list { get; set; }
        public List<TikTokSkuCustomizationInfo> sku_customization_info { get; set; }
    }
    public class TikTokSkuCustomizationInfo
    {
        public TikTokCustomizationDetail detail { get; set; }
    }
    public class TikTokCustomizationDetail
    {
        public string extra { get; set; }
        public List<TikTokCustomizationPic> pic { get; set; }
        public List<TikTokCustomizationText> text { get; set; }
    }
    public class TikTokCustomizationPic
    {
        public long id { get; set; }
        public string url { get; set; }
    }
    public class TikTokCustomizationText
    {
        public long id { get; set; }
        public string key { get; set; }
        public string content { get; set; }
    }
    public class TikTokAccountList
    {
        public List<TikTokAccountInfo> account_info { get; set; }
    }
    public class TikTokAccountInfo
    {
        public string account_name { get; set; }
        public string account_type { get; set; }
        public string encrypt_account_id { get; set; }
    }
    public class TikTokBundleSkuInfo
    {
        public string product_id { get; set; }
        public string sku_id { get; set; }
        public string product_name { get; set; }
        public long item_num { get; set; }
        public string picture_url { get; set; }
        public string code { get; set; }
    }
    public class TikTokCardVoucher
    {
        public long valid_days { get; set; }
        public long valid_start { get; set; }
        public long valid_end { get; set; }
    }
    public class TikTokSkuOrderTagUi
    {
        public string key { get; set; }
        public string text { get; set; }
        public string hover_text { get; set; }
        public string tag_type { get; set; }
        public string help_doc { get; set; }
        public long sort { get; set; }
        public string extra { get; set; }

    }
    public class TikTokAfterSaleInfo
    {
        public long after_sale_status { get; set; }
        public long after_sale_type { get; set; }
        public long refund_status { get; set; }
    }
    public class TikTokInventoryList
    {
        public string warehouse_id { get; set; }
        public string out_warehouse_id { get; set; }
        public long inventory_type { get; set; }
        public string inventory_type_desc { get; set; }
        public long count { get; set; }
        public long warehouse_type { get; set; }
    }
}
