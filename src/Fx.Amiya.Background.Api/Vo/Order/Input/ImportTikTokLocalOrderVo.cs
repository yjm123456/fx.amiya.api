using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order.Input
{
    public class ImportTikTokLocalOrderVo
    {
        
        public string GoodsName { get; set; }
        public string Phone { get; set; }
       
        public string AppointmentHospital { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// 价格（商品正常价格）
        /// </summary>
        public decimal? ActualPayment { get; set; }
        /// <summary>
        /// 应收款（优惠后实际价格，财务用）
        /// </summary>
        public decimal? AccountReceivable { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public string BelongEmp { get; set; }
    }
}
