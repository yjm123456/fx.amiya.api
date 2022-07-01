using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.BeautyDiaryManage
{
    public class BeautyDiaryBannerImageDto
    {
        public string Id { get; set; }
        public string BeautyDiaryId { get; set; }
        public string PicUrl { get; set; }
        public byte DisplayIndex { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
