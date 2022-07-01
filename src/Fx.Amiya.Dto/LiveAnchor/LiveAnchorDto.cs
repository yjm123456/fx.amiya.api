using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.LiveAnchor
{
   public class LiveAnchorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string HostAccountName { get; set; }

        public string ContentPlateFormId { get; set; }
        public string ContentPlateFormName { get; set; }
        public bool Valid { get; set; }
    }
}
