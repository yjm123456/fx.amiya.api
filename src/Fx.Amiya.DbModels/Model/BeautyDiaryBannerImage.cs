using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BeautyDiaryBannerImage
    {
        public string Id { get; set; }
        public string BeautyDiaryId { get; set; }
        public string PicUrl { get; set; }
        public byte DisplayIndex { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public BeautyDiaryManage BeautyDiary { get; set; }
    }
}
