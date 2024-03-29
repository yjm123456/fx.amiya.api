﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Partner.Api.Vo.Hospital
{
    public class HospitalAccountVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool Valid { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }

        public bool IsCreateSubAccount { get; set; }
        public int HospitalPositionId { get; set; }
        public string HospitalPositionName { get; set; }
        public bool IsCustomerService { get; set; }
    }
}
