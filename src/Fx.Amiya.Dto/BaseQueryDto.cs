using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto
{
    public class BaseQueryDto
    {
        public int CreateBy { get; set; }
        public int? PageNum { get; set; }
        public int? PageSize { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string KeyWord { get; set; }
    }
}
