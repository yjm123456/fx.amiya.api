using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo
{
    public class BaseVo
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool Valid { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
