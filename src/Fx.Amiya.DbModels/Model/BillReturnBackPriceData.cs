﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BillReturnBackPriceData : BaseDbModel
    {

        /// <summary>
        /// 客户id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 收款公司
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 票据编号
        /// </summary>
        public string BillId { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal BillPrice { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal? OtherPrice { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime ReturnBackDate { get; set; }
        /// <summary>
        /// 回款状态
        /// </summary>
        public int ReturnBackState { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public int CreateBy { get; set; }

        public string Remark { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public CompanyBaseInfo CompanyBaseInfo { get; set; }

        public Bill BillInfo { get; set; }
    }
}
