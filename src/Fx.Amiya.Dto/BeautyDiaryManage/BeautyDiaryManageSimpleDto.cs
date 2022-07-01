using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.BeautyDiaryManage
{
    public class BeautyDiaryManageSimpleDto
    {
        public string Id { get; set; }
        public string CoverTitle { get; set; }
        public bool ReleaseState { get; set; }
        public DateTime CreateDate { get; set; }
        public int Views { get; set; }
        public int GivingLikes { get; set; }
        public string ThumbPictureUrl { get; set; }
    }
}
