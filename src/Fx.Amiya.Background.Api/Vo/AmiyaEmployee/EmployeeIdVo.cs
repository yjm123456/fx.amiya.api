using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaEmployee
{
    public class EmployeeIdVo
    {
        /// <summary>
        /// 员工编号数组
        /// </summary>
        public int[] Ids { get; set; }

        /// <summary>
        /// 员工类型：1=阿美雅员工，2=医院员工
        /// </summary>
        public byte Type { get; set; }
    }
}
