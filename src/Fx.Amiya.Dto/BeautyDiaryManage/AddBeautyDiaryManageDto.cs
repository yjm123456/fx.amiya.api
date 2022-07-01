using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.BeautyDiaryManage
{
   public class AddBeautyDiaryManageDto
    {
        public string CoverTitle { get; set; }
        public string DetailsTitle { get; set; }
        public bool ReleaseState { get; set; }
        public int Views { get; set; }
        public int GivingLikes { get; set; }
        public string ThumbPictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public string DetailsDescription { get; set; }
        /// <summary>
        /// 标签编号数组
        /// </summary>
        public string[] TagIds { get; set; }

        /// <summary>
        /// 轮播图
        /// </summary>
        public List<BeautyDiaryBannerImageDto> BeautyDiaryBannerImage { get; set; }
    }
}
