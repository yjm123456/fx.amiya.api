using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 获客情况接口返回类
    /// </summary>
    public class GetCustomerDataVo
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
    }
}
