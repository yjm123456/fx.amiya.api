using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.ItemInfo
{
  public  class WxItemInfoDto
    {
        public int Id { get; set; }
        public string OtherAppItemId { get; set; }
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }
        public string Commitment { get; set; }
        public string Guarantee { get; set; }
        public string AppointmentNotice { get; set; }

        public string ItemDetailHtml { get; set; }

    }
}
