using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class RequirementType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }
        public List<LiveRequirementInfo> LiveRequirementInfoList { get; set; }
    }
}
