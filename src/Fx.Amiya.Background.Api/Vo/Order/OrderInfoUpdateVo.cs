using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    /// <summary>
    /// 修改录单基础类
    /// </summary>
    public class OrderInfoUpdateVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Required]
        public string OrderId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        [Required]
        public string GoodsId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// 预约城市
        /// </summary>
        public string AppointmentCity { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentDate { get; set; }
        /// <summary>
        /// 预约门店
        /// </summary>
        public string AppointmentHospital { get; set; }
        /// <summary>
        /// 订单状态(SEEK_ADVICE:咨询，BARGAIN_MONEY:定金)
        /// </summary>
        [Required]
        public string StatusCode { get; set; }
        /// <summary>
        /// 实付金额
        /// </summary>
        [Required]
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 买家昵称
        /// </summary>
        [Required]
        public string BuyerNick { get; set; }
        /// <summary>
        /// 下单平台
        /// </summary>
        [Required]
        public byte AppType { get; set; }
        /// <summary>
        /// 是否预约
        /// </summary>
        [Required]
        public bool IsAppointment { get; set; }
        /// <summary>
        /// 订单类型（0虚拟订单，1实物订单）
        /// </summary>
        [Required]
        public byte? OrderType { get; set; }

        /// <summary>
        /// 订单性质（0正常下单，1朋友推荐，2私域合作）
        /// </summary>
        [Required]
        public byte? OrderNature { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int? Quantity { get; set; }


        /// <summary>
        /// 交易类型：0=积分
        /// </summary>
        public byte? ExchangeType { get; set; }

        public string Remark { get; set; }
    }
}
