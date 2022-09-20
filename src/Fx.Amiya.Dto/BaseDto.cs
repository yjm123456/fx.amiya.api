using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto
{
    public class BaseDto
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool Valid { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
