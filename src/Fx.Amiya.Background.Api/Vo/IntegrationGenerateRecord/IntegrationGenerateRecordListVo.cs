using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.IntegrationGenerateRecord
{
    /// <summary>
    /// 积分记录列表
    /// </summary>
    public class IntegrationGenerateRecordListVo
    {
        public long Id { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        //发放时间
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 积分类型
        /// </summary>
        public string TypeText { get; set; }
        /// <summary>
        /// 发放数量
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal ConsumptionAmount { get; set; }
        /// <summary>
        /// 生成比例
        /// </summary>
        public decimal Percent { get; set; }
        /// <summary>
        /// 该记录剩余的积分
        /// </summary>
        public decimal StockQuantity { get; set; }
        /// <summary>
        /// 用户积分余额
        /// </summary>
        public decimal AccountBalance { get; set; }
        /// <summary>
        /// 发放人
        /// </summary>
        public string HandleBy { get; set; }
    }
}
