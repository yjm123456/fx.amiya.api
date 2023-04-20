using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CarouselImage
{
    public class UpdateCarouselImageVo
    {
        public int Id { get; set; }
        public string PicUrl { get; set; }
        public string LinkUrl { get; set; }
        public byte DisplayIndex { get; set; }
        /// <summary>
        /// 归属小程序appId
        /// </summary>
        public string AppId { get; set; }
    }
}
