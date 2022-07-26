using Fx.Amiya.Dto.TrackTypeThemeModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Track
{
    public class TrackTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasModel { get; set; }
        public bool Valid { get; set; }

        public List<TrackTypeThemeModelDto> TrackTypeThemeModelDto { get; set; }
    }
}
