﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.PermissionModule
{
   public class ModuleCategoryVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public bool Valid { get; set; }
        public int Sort { get; set; }
    }
}
