using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.BeautyDiaryTagInfo
{
   public class UpdateBeautyDiaryTagInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public bool Valid { get; set; }
    }
}
