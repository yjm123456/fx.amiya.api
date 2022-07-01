using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TagInfo
{
   public class UpdateTagInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public bool Valid { get; set; }
    }
}
