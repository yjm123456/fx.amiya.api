using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TrackTheme
{
  public  class TrackThemeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrackTypeId { get; set; }
        public string TrackTypeName { get; set; }
        public bool Valid { get; set; }
    }
}
