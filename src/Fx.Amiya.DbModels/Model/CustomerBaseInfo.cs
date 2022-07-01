using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class CustomerBaseInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string Occupation { get; set; }
        public string WechatNumber { get; set; }
        public string City { get; set; }
    }
}
