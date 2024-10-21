using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerServiceCheckPerformance.Input
{
   public class AddCustomerServiceCheckPerformanceDto
    {
        /// <summary>
        /// 成交编号
        /// </summary>
        public string DealInfoId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 订单来源
        /// </summary>
        public int OrderFrom { get; set; }

        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal DealPrice { get; set; }

        /// <summary>
        /// 成交创建时间
        /// </summary>
        public DateTime DealCreateDate { get; set; }

        /// <summary>
        /// 助理薪资业绩类型
        /// </summary>
        public int PerformanceType { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }

        /// <summary>
        /// 薪资点数
        /// </summary>
        public decimal Point { get; set; }

        /// <summary>
        /// 助理业绩提成
        /// </summary>
        public decimal PerformanceCommision { get; set; }

        /// <summary>
        /// 行政客服业绩提成
        /// </summary>
        public decimal PerformanceCommisionCheck { get; set; }


        /// <summary>
        /// 稽查人员id
        /// </summary>
        public int? CheckEmpId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 助理薪资id
        /// </summary>
        public string BillId { get; set; }

        /// <summary>
        /// 稽查人员薪资id
        /// </summary>
        public string CheckBillId { get; set; }
    }
}
