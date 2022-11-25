using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation
{
    public class AddHospitalDealItemOperationVo
    {
        /// <summary>
        /// 指标id
        /// </summary>
        [Description("指标编号")]
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        [Description("医院编号")]
        public int HospitalId { get; set; }
        /// <summary>
        /// 成交品项名称
        /// </summary>
        [Description("执行品项名称")]
        public string DealItemName { get; set; }
       

        /// <summary>
        /// 成交数量
        /// </summary>
        [Description("执行数量")]
        public int DealCount { get; set; }
        /// <summary>
        /// 执行单价
        /// </summary>
        [Description("执行单价")]
        public decimal DealUnitPrice { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        [Description("执行金额")]
        public decimal DealPrice { get; set; }
        /// <summary>
        /// 业绩占比
        /// </summary>
        [Description("执行占比")]
        public decimal PerformanceRatio { get; set; }
    }
}
