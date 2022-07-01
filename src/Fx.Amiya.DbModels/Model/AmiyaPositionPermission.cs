using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class AmiyaPositionPermission
    {
        public int Id { get; set; }
        public int AmiyaPositionId { get; set; }
        public int PermissionId { get; set; }

        public AmiyaPositionInfo AmiyaPositionInfo { get; set; }
        public PermissionInfo PermissionInfo { get; set; }
    }
}
