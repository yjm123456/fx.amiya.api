using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Permission
{
    public class UpdatePermissionsVo
    {
        /// <summary>
        /// 职位id
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// 可用权限id
        /// </summary>
        public int PermissionId { get; set; }
    }
}
