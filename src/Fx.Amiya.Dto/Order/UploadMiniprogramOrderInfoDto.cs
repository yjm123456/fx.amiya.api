using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Order
{
    public class UploadMiniprogramOrderInfoDto
    {
        /// <summary>
        /// 订单，需要上传物流信息的订单
        /// </summary>
        public OrderKey order_key { get; set; }
        /// <summary>
        /// 物流模式，发货方式枚举值：1、实体物流配送采用快递公司进行实体物流配送形式 2、同城配送 3、虚拟商品，虚拟商品，例如话费充值，点卡等，无实体配送形式 4、用户自提
        /// </summary>
        public int logistics_type { get; set; }
        /// <summary>
        /// 发货模式，发货模式枚举值：1、UNIFIED_DELIVERY（统一发货）2、SPLIT_DELIVERY（分拆发货） 示例值: UNIFIED_DELIVERY
        /// </summary>
        public int delivery_mode { get; set; }
        /// <summary>
        /// 分拆发货模式时必填，用于标识分拆发货模式下是否已全部发货完成，只有全部发货完成的情况下才会向用户推送发货完成通知。示例值: true/false
        /// </summary>
        public bool is_all_delivered { get; set; }
        /// <summary>
        /// 物流信息列表，发货物流单列表，支持统一发货（单个物流单）和分拆发货（多个物流单）两种模式，多重性: [1, 10]
        /// </summary>
        public List<ShippingInfo> shipping_list { get; set; }
        /// <summary>
        /// 上传时间，用于标识请求的先后顺序 示例值: `2022-12-15T13:29:35.120+08:00`
        /// </summary>
        public string upload_time { get; set; }
        /// <summary>
        /// 支付者，支付者信息
        /// </summary>
        public PayerInfo payer { get; set; }

    }
    public class OrderKey {
        /// <summary>
        /// 订单单号类型，用于确认需要上传详情的订单。枚举值1，使用下单商户号和商户侧单号；枚举值2，使用微信支付单号。
        /// </summary>
        public int order_number_type { get; set; } = 1;
        /// <summary>
        /// 支付下单商户的商户号，由微信支付生成并下发。
        /// </summary>
        public string mchid { get; set; }
        /// <summary>
        /// 商户系统内部订单号，只能是数字、大小写字母`_-*`且在同一个商户号下唯一
        /// </summary>
        public string out_trade_no { get; set; }
    }
    public class ShippingInfo {
        /// <summary>
        /// 物流单号，物流快递发货时必填，示例值: 323244567777 字符字节限制: [1, 128]
        /// </summary>
        public string tracking_no { get; set; }
        /// <summary>
        /// 物流公司编码，快递公司ID，参见「查询物流公司编码列表」，物流快递发货时必填， 示例值: DHL 字符字节限制: [1, 128]
        /// </summary>
        public string express_company { get; set; }
        /// <summary>
        /// 物流公司编码，快递公司ID，参见「查询物流公司编码列表」，物流快递发货时必填， 示例值: DHL 字符字节限制: [1, 128]
        /// </summary>
        public string item_desc { get; set; }
        /// <summary>
        /// 联系方式，当发货的物流公司为顺丰时，联系方式为必填，收件人或寄件人联系方式二选一
        /// </summary>
        public Contact contact { get; set; }
    }
    /// <summary>
    /// 联系方式，当发货的物流公司为顺丰时，联系方式为必填，收件人或寄件人联系方式二选一
    /// </summary>
    public class Contact {
        /// <summary>
        /// 寄件人联系方式，寄件人联系方式，采用掩码传输，最后4位数字不能打掩码 示例值: `189****1234
        /// </summary>
        public string consignor_contact { get; set; }
        /// <summary>
        /// 收件人联系方式，收件人联系方式为，采用掩码传输，最后4位数字不能打掩码 示例值: `189****1234
        /// </summary>
        public string receiver_contact { get; set; }
    }
    public class PayerInfo {
        /// <summary>
        /// 用户标识，用户在小程序appid下的唯一标识
        /// </summary>
        public string openid { get; set; }
    }
}
