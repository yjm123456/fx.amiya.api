using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TagInfo
{
  public  class TagInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public string TypeName { get; set; }
        public bool Valid { get; set; }
    }
}
