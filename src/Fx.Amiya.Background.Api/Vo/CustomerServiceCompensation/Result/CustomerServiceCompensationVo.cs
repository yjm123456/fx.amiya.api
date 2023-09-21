using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerServiceCompensation.Result
{
    /// <summary>
    /// 助理薪资单输出类
    /// </summary>
    public class CustomerServiceCompensationVo : BaseVo
    {

        /// <summary>
        /// 创建人id
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateByEmpName { get; set; }
        /// <summary>
        /// 账单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 归属客服
        /// </summary>
        public int BelongEmpId { get; set; }
        /// <summary>
        /// 归属客服名称
        /// </summary>
        public string BelongEmpName { get; set; }

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
    }
}
