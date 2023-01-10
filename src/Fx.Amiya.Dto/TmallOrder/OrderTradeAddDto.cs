using Fx.Amiya.Dto.TikTokOrder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public class OrderTradeAddDto
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerId { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 收货地址编号
        /// </summary>
        public int? AddressId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否管理员录单
        /// </summary>
        public bool IsAdminAdd { get; set; } = false;
        /// <summary>
        /// 全局使用抵用券
        /// </summary>
        public string VoucherId { get; set; }
        public List<OrderInfoAddDto> OrderInfoAddList { get; set; }
        public List<TikTokOrderAddDto> TikTokOrderInfoAddList { get; set; }
    }
}
