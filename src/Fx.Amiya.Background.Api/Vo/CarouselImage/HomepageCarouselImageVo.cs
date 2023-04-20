using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CarouselImage
{
    public class HomepageCarouselImageVo
    {
        public int Id { get; set; }
        public string PicUrl { get; set; }
        public byte DisplayIndex { get; set; }
        public string LinkUrl { get; set; }
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 小程序appid
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 小程序名称
        /// </summary>
        public string AppName { get; set; }
    }
}
