using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BeautyDiaryManage
{
    /// <summary>
    /// 美丽日记新增类
    /// </summary>
    public class BeautyDiaryManageAddVo
    {
        /// <summary>
        /// 封面标题
        /// </summary>
        [Required(ErrorMessage = "封面标题不能为空")]
        [StringLength(100, ErrorMessage = "封面标题最多{1}个字符")]
        public string CoverTitle { get; set; }
        /// <summary>
        /// 日记标题
        /// </summary>
        [Required(ErrorMessage = "日记标题不能为空")]
        [StringLength(100, ErrorMessage = "日记标题最多{1}个字符")]
        public string DetailsTitle { get; set; }
        /// <summary>
        /// 发布状态
        /// </summary>
        [Required]
        public bool ReleaseState { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Required]
        public int Views { get; set; }
        /// <summary>
        /// 点赞量
        /// </summary>
        [Required]
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
        [Required(ErrorMessage = "内容不能为空")]
        [StringLength(9999, ErrorMessage = "内容最多{1}个字符")]
        public string DetailsDescription { get; set; }

        /// <summary>
        /// 轮播图
        /// </summary>
        public List<BeautyDiaryManageBannerImageAddVo> BannerImage { get; set; }

        /// <summary>
        /// 标签编号数组
        /// </summary>
        public string[] TagIds { get; set; }
    }
}
