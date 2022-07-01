using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveRequirementInfo
{
    public class ProgressBarVo
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 响应时间
        /// </summary>
        public DateTime? ResponseDate { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime? ExecuteDate { get; set; }

        /// <summary>
        /// 响应秒数
        /// </summary>
        public double ResponseSeconds { get; set; }


        /// <summary>
        /// 执行进度秒数
        /// </summary>
        public int ExecuteSeconds { get; set; }
    }
}
