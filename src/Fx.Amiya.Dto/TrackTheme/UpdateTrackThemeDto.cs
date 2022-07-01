using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TrackTheme
{
  public  class UpdateTrackThemeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrackTypeId { get; set; }
        public bool Valid { get; set; }
    }
}
