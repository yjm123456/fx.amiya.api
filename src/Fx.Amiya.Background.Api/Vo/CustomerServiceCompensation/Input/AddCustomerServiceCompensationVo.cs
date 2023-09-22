using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerServiceCompensation.Input
{
    /// <summary>
    /// 创建助理薪资单基础类
    /// </summary>
    public class AddCustomerServiceCompensationVo
    {
        /// <summary>
        /// 账单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal OtherPrice { get; set; }
        /// <summary>
        /// 费用备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 对账单审核记录id集合
        /// </summary>
        public List<string> RecommandDocumentSettleIdList { get; set; }
    }
}
