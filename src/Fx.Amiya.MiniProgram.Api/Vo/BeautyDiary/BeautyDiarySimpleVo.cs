using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.BeautyDiary
{
    /// <summary>
    /// 美丽日记基础输出
    /// </summary>
    public class BeautyDiarySimpleVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string CoverTitle { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ThumbPictureUrl { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int Views { get; set; }
        /// <summary>
        /// 点赞量
        /// </summary>
        public int GivingLikes{get;set;}
    }
}
