﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Partner
{
   public class UpdatePartnerPermissionDto
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string ControlName { get; set; }
        public string ActionName { get; set; }
    }
}
