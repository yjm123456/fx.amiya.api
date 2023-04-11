using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.IntegrationGenerateRecord.Result
{
    public class IntegrationGenerateRecordExportVo
    {
       
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string Phone { get; set; }
        //发放时间
        [Description("发放时间")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 积分类型
        /// </summary>
        [Description("积分类型")]
        public string TypeText { get; set; }
        /// <summary>
        /// 发放数量
        /// </summary>
        [Description("发放数量")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        [Description("订单id")]
        public string OrderId { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        [Description("消费金额")]
        public decimal ConsumptionAmount { get; set; }
        /// <summary>
        /// 生成比例
        /// </summary>
        [Description("生成比例")]
        public decimal Percent { get; set; }
        /// <summary>
        /// 该记录剩余的积分
        /// </summary>
        [Description("该记录剩余的积分")]
        public decimal StockQuantity { get; set; }
        /// <summary>
        /// 用户积分余额
        /// </summary>
        [Description("用户积分余额")]
        public decimal AccountBalance { get; set; }
        /// <summary>
        /// 发放人
        /// </summary>
        [Description("发放人")]
        public string HandleBy { get; set; }
    }
}
