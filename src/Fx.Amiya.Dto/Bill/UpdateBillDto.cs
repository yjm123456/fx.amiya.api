﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Bill
{
    public class UpdateBillDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal BillPrice { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 税额（发票金额/（（1+税率）*税率）--保留2位小数）
        /// </summary>
        public decimal TaxPrice { get; set; }
        /// <summary>
        /// 不含税金额
        /// </summary>
        public decimal NotInTaxPrice { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal? OtherPrice { get; set; }
        /// <summary>
        /// 费用备注
        /// </summary>
        public string OtherPriceRemark { get; set; }
        /// <summary>
        /// 收款公司id
        /// </summary>
        public string CollectionCompanyId { get; set; }
        /// <summary>
        /// 开票时间
        /// </summary>

        public DateTime CreateBillDate { get; set; }
        /// <summary>
        /// 票据归属时间（起）
        /// </summary>
        public DateTime BelongStartTime { get; set; }
        /// <summary>
        /// 票据归属时间（止）
        /// </summary>
        public DateTime BelongEndTime { get; set; }
        /// <summary>
        /// 票据类型
        /// </summary>
        public int BillType { get; set; }
        /// <summary>
        /// 开票事由
        /// </summary>
        public string CreateBillReason { get; set; }
    }
}
