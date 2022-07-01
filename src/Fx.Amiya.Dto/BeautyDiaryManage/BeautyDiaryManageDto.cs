using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.BeautyDiaryManage
{
   public class BeautyDiaryManageDto
    {

        public string Id { get; set; }
        public string CoverTitle { get; set; }
        public string DetailsTitle { get; set; }
        public bool ReleaseState { get; set; }
        public DateTime CreateDate { get; set; }
        public int Views { get; set; }
        public int GivingLikes { get; set; }
        public string ThumbPictureUrl { get; set; }
        public string VideoUrl { get; set; }
        public string DetailsDescription { get; set; }

    }
}
