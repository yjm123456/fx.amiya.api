using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 新老客横向堆叠柱状图输出类
    /// </summary>
    public class NewOrOldCustomerPerformanceDataVo
    {
        /// <summary>
        /// 区分助理与机构（employee=助理，hospital=机构）
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public List<int> NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public List<int> OldCustomerPerformance { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public List<string> Name { get; set; }
    }
}
