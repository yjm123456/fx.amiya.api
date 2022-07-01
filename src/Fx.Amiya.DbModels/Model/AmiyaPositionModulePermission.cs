using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class AmiyaPositionModulePermission
    {
        public int Id { get; set; }
        public int AmiyaPositionId { get; set; }
        public int ModuleCategoryId { get; set; }
        public int ModuleId { get; set; }

        public AmiyaPositionInfo AmiyaPositionInfo { get; set; }
        public ModuleCategory ModuleCategory { get; set; }
        public Module Module { get; set; }
    }
}
