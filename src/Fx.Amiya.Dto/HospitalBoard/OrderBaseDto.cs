
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalBoard
{
    public class OrderBaseDto
    {
        /// <summary>
        /// 派单量
        /// </summary>
        public decimal SendOrderCount { get; set; }
       
        /// <summary>
        /// 已处理订单数量
        /// </summary>
        public decimal ProcessedOrderCount { get; set; }
        
        /// <summary>
        /// 未处理订单数量
        /// </summary>
        public decimal UntreatedOrderCount { get; set; }
       
        /// <summary>
        /// 派单未上门订单数量
        /// </summary>
        public decimal SendOrderNotToHospitalCount { get; set; }
        
        /// <summary>
        /// 上门未成交订单数量
        /// </summary>
        public decimal ToHospitalNoDealCount { get; set; }
        
        /// <summary>
        /// 成交未复购订单数量
        /// </summary>
        public decimal DealNoRepurchaseCount { get; set; }

        /// <summary>
        /// 累计派单量
        /// </summary>
        public decimal AccumulateSendOrderCount { get; set; }

        /// <summary>
        /// 累计已处理订单数量
        /// </summary>
        public decimal AccumulateProcessedOrderCount { get; set; }

        /// <summary>
        /// 累计未处理订单数量
        /// </summary>
        public decimal AccumulateUntreatedOrderCount { get; set; }

        /// <summary>
        /// 累计派单未上门订单数量
        /// </summary>
        public decimal AccumulateSendOrderNotToHospitalCount { get; set; }

        /// <summary>
        /// 上门未成交订单数量
        /// </summary>
        public decimal AccumulateToHospitalNoDealCount { get; set; }

        /// <summary>
        /// 累计成交未复购订单数量
        /// </summary>
        public decimal AccumulateDealNoRepurchaseCount { get; set; }


    }
}
