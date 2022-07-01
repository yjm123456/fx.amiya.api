using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class PermissionInfo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public List<AmiyaPositionPermission> AmiyaPositionPermissionList { get; set; }
    }
}
