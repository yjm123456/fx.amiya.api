using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LiveRequirementInfo
{
   public class ProgressBarDto
    {
        public DateTime CreateDate { get; set; }
        public string  CreateName { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string ResponseName { get; set; }
        public DateTime? ExecuteDate { get; set; }
        public string ExecuteName { get; set; }

        /// <summary>
        /// 响应秒数
        /// </summary>
        public int ResponseSeconds { get; set; }


        /// <summary>
        /// 执行进度秒数
        /// </summary>
        public int ExecuteSeconds { get; set; }
    }
}
