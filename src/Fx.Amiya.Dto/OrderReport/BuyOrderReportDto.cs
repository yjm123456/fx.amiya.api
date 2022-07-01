using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderReport
{
    public class BuyOrderReportDto
    {/// <summary>
     /// 订单号
     /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 下单平台
        /// </summary>
        public string AppTypeText { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        public decimal? ActualPayment { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int? Quantity { get; set; }


        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusText { get; set; }

        /// <summary>
        /// 客户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 预约门店
        /// </summary>
        public string AppointmentHospital { get; set; }

        /// <summary>
        /// 归属客服id
        /// </summary>
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public string BelongEmpName { get; set; }
    }
}
