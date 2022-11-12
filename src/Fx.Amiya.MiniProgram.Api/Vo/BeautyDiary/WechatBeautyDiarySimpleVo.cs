using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.BeautyDiary
{
    public class WechatBeautyDiarySimpleVo
    {
        /// <summary>
        /// 图文消息标题
        /// </summary>
        public string CoverTitle { get; set; }
        /// <summary>
        /// 图片链接
        /// </summary>
        public string ThumbPictureUrl { get; set; }       
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// 图文页的URL，或者，当获取的列表是图片素材列表时，该字段是图片的URL
        /// </summary>
        public string Url { get; set; }
    }
}
