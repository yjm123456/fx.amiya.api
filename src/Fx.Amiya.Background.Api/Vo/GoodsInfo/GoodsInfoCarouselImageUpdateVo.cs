using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsInfo
{
    public class GoodsInfoCarouselImageUpdateVo
    {  /// <summary>
       /// 图片地址
       /// </summary>
        [Required(ErrorMessage = "轮播图链接地址不能为空")]
        public string PicUrl { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public byte DisplayIndex { get; set; }
    }
}
