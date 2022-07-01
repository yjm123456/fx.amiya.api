using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalInfo
{
    public class HospitalInfoCheckInfoDto
    {
        public int Id { get; set; }
        public int CheckState { get; set; }
        public string Remark { get; set; }
        public int CheckBy { get; set; }
    }
}
