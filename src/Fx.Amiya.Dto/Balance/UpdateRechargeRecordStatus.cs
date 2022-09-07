using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Balance
{
    /// <summary>
    /// 更新充值记录状态
    /// </summary>
    public class UpdateRechargeRecordStatusDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 记录状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 支付流水号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime CompleteDate { get; set; }
    }
}
