using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GiftCategory
{
    public class GiftCategoryInfoDto:BaseDto
    {
        
        public string Name { get; set; }
        public string SimpleCode { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }

    }
}
