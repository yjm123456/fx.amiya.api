using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Gift
{
    public class ReceiveGiftInfoSimpleVo
    {
        public int Id { get; set; }
        public int GiftId { get; set; }
        public string GiftName { get; set; }
        public string ThumbPicUrl { get; set; }
    }
}
