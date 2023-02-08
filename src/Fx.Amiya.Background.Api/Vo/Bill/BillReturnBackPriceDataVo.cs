using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Bill
{
    /// <summary>
    /// 票据回款记录基础类
    /// </summary>
    public class BillReturnBackPriceDataVo
    {
        /// <summary>
        /// 票据编号
        /// </summary>
        [Description("票据编号")]
        public string BillId { get; set; }
        /// <summary>
        /// 客户名称（医院）
        /// </summary>
        [Description("客户名称")]
        public string HospitalName { get; set; }
        /// <summary>
        /// 收款公司名称
        /// </summary>
        [Description("收款公司")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        [Description("发票金额")]
        public decimal BillPrice { get; set; }
        /// <summary>
        /// 发票其他费用
        /// </summary>
        [Description("发票其他费用")]
        public decimal? OtherPrice { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        [Description("回款金额")]
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 回款时间
        /// </summary>
        [Description("回款时间")]
        public DateTime ReturnBackDate { get; set; }
        /// <summary>
        /// 回款状态
        /// </summary>
        [Description("回款状态")]
        public string ReturnBackStateText { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Description("操作人")]
        public string CreateByEmployeeName { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        [Description("操作时间")]
        public DateTime CreateDate { get; set; }
    }
}
