﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalPosition
{
   public class HospitalPositionInfoDto
    {
           public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }

    }
}
