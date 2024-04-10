using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class GetCustomerIndexTransformationResultVo
    {
        /// <summary>
        /// 指标名称
        /// </summary>
        public string Name { get; set; }

        public int Value { get; set; }
    }

    /// <summary>
    /// 顾客指标转化数据输出类
    /// </summary>
    public class GetCustomerIndexTransformationDataVo
    {
        /// <summary>
        /// 下卡量
        /// </summary>
        [Description("下卡量")]
        public int AddCardNum { get; set; }

        /// <summary>
        /// 退卡量
        /// </summary>
        [Description("退卡量")]
        public int RefundCardNum { get; set; }

        /// <summary>
        /// 分诊量
        /// </summary>
        [Description("分诊量")]
        public int DistributeConsulationNum { get; set; }

        /// <summary>
        /// 加v量
        /// </summary>
        [Description("加v量")]
        public int AddWechatNum { get; set; }

        /// <summary>
        /// 派单量
        /// </summary>
        [Description("派单量")]
        public int SendOrderNum { get; set; }

        /// <summary>
        /// 上门量
        /// </summary>
        [Description("上门量")]
        public int VisitNum { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        [Description("成交量")]
        public int DealNum { get; set; }
    }
}
