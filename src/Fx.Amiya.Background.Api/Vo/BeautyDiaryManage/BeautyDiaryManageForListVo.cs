using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BeautyDiaryManage
{
    /// <summary>
    /// 美丽日记返回类
    /// </summary>
    public class BeautyDiaryManageForListVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 封面标题
        /// </summary>
        public string CoverTitle { get; set; }
        /// <summary>
        /// 日记标题
        /// </summary>
        public string DetailsTitle { get; set; }
        /// <summary>
        /// 发布状态
        /// </summary>
        public bool ReleaseState { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int Views { get; set; }
        /// <summary>
        /// 点赞量
        /// </summary>
        public int GivingLikes { get; set; }
        /// <summary>
        /// 封面图片地址
        /// </summary>
        public string ThumbPictureUrl { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoUrl { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string DetailsDescription { get; set; }
    }
}
