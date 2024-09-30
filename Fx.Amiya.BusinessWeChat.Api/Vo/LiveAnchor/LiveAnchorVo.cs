using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.LiveAnchor
{
    public class LiveAnchorVo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string HostAccountName { get; set; }

        public string ContentPlateFormId { get; set; }
        public string LiveAnchorBaseId { get; set; }
        public string ContentPlateFormName { get; set; }
        public bool Valid { get; set; }
    }
}
