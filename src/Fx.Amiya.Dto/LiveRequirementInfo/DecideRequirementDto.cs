using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LiveRequirementInfo
{
    public class DecideRequirementDto
    {
        public int Id { get; set; }
        public bool IsAcceptResponse { get; set; }
        public string DecideRemark { get; set; }
        public int? DepartmentId{get;set;}
    }
}
