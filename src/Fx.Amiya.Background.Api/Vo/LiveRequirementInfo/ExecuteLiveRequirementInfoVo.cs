using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveRequirementInfo
{
    public class ExecuteLiveRequirementInfoVo
    {
        public int Id { get; set; }

        /// <summary>
        /// 执行备注说明
        /// </summary>
        public string ExecuteRemark { get; set; }
    }
}
