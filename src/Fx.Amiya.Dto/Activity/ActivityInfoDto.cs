using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Activity
{
   public class ActivityInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Valid { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
