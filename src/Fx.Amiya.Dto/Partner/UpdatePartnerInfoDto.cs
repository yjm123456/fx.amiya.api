using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Partner
{
   public class UpdatePartnerInfoDto
    {
        public int Id { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }
    }
}
