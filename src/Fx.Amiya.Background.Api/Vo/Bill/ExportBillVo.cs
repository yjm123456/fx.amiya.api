using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Bill
{
    public class ExportBillVo
    {
        /// <summary>
        /// 发票编号
        /// </summary>
        [Description("发票编号")]
        public string Id { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Description("客户")]
        public string HospitalName { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        [Description("发票金额")]
        public decimal BillPrice { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        [Description("税率(%)")]
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 税额（发票金额/（（1+税率）*税率）--保留2位小数）
        /// </summary>
        [Description("税额")]
        public decimal TaxPrice { get; set; }
        /// <summary>
        /// 不含税金额
        /// </summary>
        [Description("不含税金额")]
        public decimal NotInTaxPrice { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        [Description("其他费用")]
        public decimal? OtherPrice { get; set; }
        /// <summary>
        /// 费用备注
        /// </summary>
        [Description("费用备注")]
        public string OtherPriceRemark { get; set; }
        

        /// <summary>
        /// 收款公司名称
        /// </summary>
        [Description("收款公司")]
        public string CollectionCompanyName { get; set; }

        /// <summary>
        /// 开票时间
        /// </summary>
        [Description("开票时间")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 票据归属时间
        /// </summary>
        [Description("票据归属时间")]
        public string BelongDate { get; set; }
        
        /// <summary>
        /// 票据类型文本（医美/其他）
        /// </summary>
        [Description("票据类型")]
        public string BillTypeText { get; set; }
        /// <summary>
        /// 开票事由
        /// </summary>
        [Description("开票事由")]
        public string CreateBillReason { get; set; }

        /// <summary>
        /// 回款状态文本（未回款/回款中/已回款）
        /// </summary>
        [Description("回款状态")]
        public string ReturnBackStateText { get; set; }

        /// <summary>
        /// 累计回款金额
        /// </summary>
        [Description("已回款金额")]
        public decimal? ReturnBackPrice { get; set; }

        /// <summary>
        /// 回款时间
        /// </summary>
        [Description("回款时间")]
        public DateTime? ReturnBackPriceDate { get; set; }

        /// <summary>
        /// 开票人名称
        /// </summary>
        [Description("开票人")]
        public string CreateByEmployeeName { get; set; }
        /// <summary>
        /// 是否作废文本（正常，作废）
        /// </summary>
        [Description("发票状态")]
        public string ValidText { get; set; }

       
    }
}
