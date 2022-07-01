using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Activity
{
    public class ActivityInfoSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPartake { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
