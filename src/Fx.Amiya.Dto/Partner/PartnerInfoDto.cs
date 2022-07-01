using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Partner
{
  public  class PartnerInfoDto
    {
        public int Id { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string Name { get; set; }
        public bool Valid { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreateBy { get; set; }
        public string CreateName { get; set; }
    }
}
