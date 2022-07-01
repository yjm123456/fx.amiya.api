using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.ItemInfo
{
    public class WxSimpleItemInfoVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
    }
    public class WxSimpleOrderInfoVo
    {
        public string OrderId { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
    }
}
