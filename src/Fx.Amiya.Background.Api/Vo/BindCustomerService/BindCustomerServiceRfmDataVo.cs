using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BindCustomerService
{
    public class BindCustomerServiceRfmDataVo
    {
        /// <summary>
        /// rfm类型
        /// </summary>
        public int RFMType { get; set; }

        /// <summary>
        /// rfm类型文本
        /// </summary>

        public string RFMTypeText { get; set; }

        /// <summary>
        /// 客户数量
        /// </summary>
        public int CustomerCount { get; set; }
        /// <summary>
        /// 较昨日增长/下降
        /// </summary>
        public int CustomerIncreaseFromYesterday { get; set; }
        /// <summary>
        /// 累计消费金额
        /// </summary>

        public decimal TotalConsumptionPrice { get; set; }
    }
}
