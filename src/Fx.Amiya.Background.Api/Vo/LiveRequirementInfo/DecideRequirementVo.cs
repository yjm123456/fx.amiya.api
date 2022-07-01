using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveRequirementInfo
{
    public class DecideRequirementVo
    {
        public int Id { get; set; }

        /// <summary>
        /// 是否同意响应
        /// </summary>
        public bool IsAcceptResponse { get; set; }

        /// <summary>
        /// 评判备注说明
        /// </summary>
       public string DecideRemark { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public int? DepartmentId { get; set; }
    }
}
