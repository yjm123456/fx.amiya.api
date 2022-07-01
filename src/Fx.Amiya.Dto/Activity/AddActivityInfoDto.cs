using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Activity
{
   public class AddActivityInfoDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
