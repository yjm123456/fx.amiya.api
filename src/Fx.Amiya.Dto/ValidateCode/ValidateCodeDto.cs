﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.ValidateCode
{
  public  class ValidateCodeDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ExpiredTime { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Valid { get; set; }
    }
}
