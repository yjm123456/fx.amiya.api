using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.HospitalInfo
{
    public class DocterVo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string Position { get; set; }
        public int WorkYearNumer { get; set; }
        public string Description { get; set; }
    }
}
