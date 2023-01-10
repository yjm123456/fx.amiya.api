using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.WxAppInfo
{
    public class WxNoticeDto
    {
        public string Name { get; set; }
        public string ActivityName { get; set; }
        public string AddCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal TotalCount { get; set; }
        public string OpenId { get; set; }
    }
}
