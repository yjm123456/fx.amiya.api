using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LiveRequirementInfo
{
   public class AddLiveRequirementInfoDto
    {
        public int LiveAnchorId { get; set; }
        public int LiveTypeId { get; set; }
        public int RequirementTypeId { get; set; }
        public string FansInfo { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public byte PriorityLevel { get; set; }
    }
}
