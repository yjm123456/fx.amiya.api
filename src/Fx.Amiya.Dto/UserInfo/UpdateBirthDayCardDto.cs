﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.UserInfo
{
    public class UpdateBirthDayCardDto
    {
        public string Id { get; set; }
        public DateTime BirthDay { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string DetailAddress { get; set; }
        public string Province { get; set; }
    }
}
