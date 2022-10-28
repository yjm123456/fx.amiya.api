using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class OrderItemVo
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]
        public string GoodsId { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]
        public int Quantity { get; set; }

        /// <summary>
        /// 预约城市
        /// </summary>
        public string AppointmentCity { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentDate { get; set; }
        /// <summary>
        /// 门店医院
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 实付款价格
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 是否是美肤卡
        /// </summary>
        public bool IsSkinCare { get; set; }

        ///// <summary>
        ///// 抵扣积分
        ///// </summary>
        //public decimal? IntegrationQuantity { get; set; }
    }
}
