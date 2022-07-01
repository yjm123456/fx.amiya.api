using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderCheck
{
    public class UpdateOrderCheckPictureVo
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public int OrderFrom { get; set; }
        public string PictureUrl { get; set; }
    }
}
