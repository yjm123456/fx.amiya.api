﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto
{
    public class BaseIdAndNameDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class BaseIdAndNameDto<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
