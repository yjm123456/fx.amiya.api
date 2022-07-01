using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Gift
{
    public class GiftInfoVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
        public int Quantity { get; set; }
        public bool Valid { get; set; }
        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
