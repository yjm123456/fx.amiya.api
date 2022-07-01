using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BeautyDiaryManage
{
    /// <summary>
    /// 日记轮播图新增
    /// </summary>
    public class BeautyDiaryManageBannerImageAddVo
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 轮播顺序
        /// </summary>
        public byte DisplayIndex { get; set; }
    }
}
