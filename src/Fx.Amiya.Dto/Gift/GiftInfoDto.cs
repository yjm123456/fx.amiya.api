using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Gift
{
   public class GiftInfoDto
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
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
