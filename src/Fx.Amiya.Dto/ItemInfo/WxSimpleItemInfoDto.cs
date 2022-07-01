using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.ItemInfo
{
    public class WxSimpleItemInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
    }

    public class WxSimpleOrderInfoDto
    {
        public string OrderId { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
    }
}
