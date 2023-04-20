using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CarouselImage
{
    public class AddCarouselImageVo
    {
        public string PicUrl { get; set; }
        public string LinkUrl { get; set; }
        /// <summary>
        /// 归属小程序apid
        /// </summary>
        public string AppId { get; set; }
    }
}
