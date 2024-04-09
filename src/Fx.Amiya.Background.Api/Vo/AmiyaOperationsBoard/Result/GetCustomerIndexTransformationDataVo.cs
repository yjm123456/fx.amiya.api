using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 顾客指标转化数据输出类
    /// </summary>
    public class GetCustomerIndexTransformationDataVo
    {
        /// <summary>
        /// 下卡量
        /// </summary>
        public int AddCardNum { get; set; }

        /// <summary>
        /// 退卡量
        /// </summary>
        public int RefundCardNum { get; set; }

        /// <summary>
        /// 分诊量
        /// </summary>
        public int DistributeConsulationNum { get; set; }

        /// <summary>
        /// 加v量
        /// </summary>
        public int AddWechatNum { get; set; }

        /// <summary>
        /// 派单量
        /// </summary>
        public int SendOrderNum { get; set; }

        /// <summary>
        /// 上门量
        /// </summary>
        public int VisitNum { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public int DealNum { get; set; }
    }
}
