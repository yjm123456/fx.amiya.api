using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaPositionInfo
{
    public class UpdateAmiyaPositionInfoVo
    {
        /// <summary>
        /// 职位编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 部门编号
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool IsDirector { get; set; }

    }
}
