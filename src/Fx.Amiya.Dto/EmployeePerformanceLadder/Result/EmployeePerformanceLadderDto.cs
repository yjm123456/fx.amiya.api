using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.EmployeePerformanceLadder.Result
{
    public class EmployeePerformanceLadderDto:BaseDto
    {
        /// <summary>
        /// 助理id（若为私人配置则有值）
        /// </summary>
        public int? CustomerServiceId { get; set; }
        /// <summary>
        /// 是否为私人配置
        /// </summary>
        public bool IsPersonalConfig { get; set; }
        /// <summary>
        /// 业绩阶梯下限（包含）
        /// </summary>
        public decimal PerformanceLowerLimit { get; set; }
        /// <summary>
        /// 业绩阶梯上限（不包含）
        /// </summary>
        public decimal PerformanceUpperLimit { get; set; }
        /// <summary>
        /// 提成点数
        /// </summary>
        public decimal Point { get; set; }
        /// <summary>
        /// 底薪
        /// </summary>
        public decimal BasePerformance { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
