using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.BeautyDiaryTagInfo
{
  public  class BeautyDiaryTagInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public string TypeName { get; set; }
        public bool Valid { get; set; }
    }
}
