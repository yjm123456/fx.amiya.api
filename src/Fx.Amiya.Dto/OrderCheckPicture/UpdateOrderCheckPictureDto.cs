using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderCheckPicture
{
    public class UpdateOrderCheckPictureDto
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public int OrderFrom { get; set; }
        public string PictureUrl { get; set; }
    }
}
