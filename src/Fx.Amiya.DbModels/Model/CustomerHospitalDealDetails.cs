using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class CustomerHospitalDealDetails
    {
        public string Id { get; set; }
        /// <summary>
        /// 客户成交信息编号
        /// </summary>
        public string CustomerHospitalDealId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 项目规格
        /// </summary>
        public string ItemStandard { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal CashAmount { get; set; }

        public DateTime CreateDate { get; set; }

        public CustomerHospitalDealInfo CustomerHospitalDealInfo { get; set; }
    }
}
