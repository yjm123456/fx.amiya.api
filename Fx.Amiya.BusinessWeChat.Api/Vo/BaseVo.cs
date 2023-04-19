using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo
{
    public class BaseVo
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Valid { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
