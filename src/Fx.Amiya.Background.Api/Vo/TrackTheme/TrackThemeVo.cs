using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TrackTheme
{
    public class TrackThemeVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrackTypeId { get; set; }
        public string TrackTypeName { get; set; }
        public bool Valid { get; set; }
    }
}
