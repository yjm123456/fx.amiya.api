using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class GiftInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
        public int Quantity { get; set; }
        public bool Valid { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Version { get; set; }
        public string CategoryId { get; set; }
        public AmiyaEmployee CreateByAmiyaEmplooyee { get; set; }
        public AmiyaEmployee UpdateByAmiyaEmplooyee { get; set; }

        public List<ReceiveGift> ReceiveGiftList { get; set; }
    }
}
