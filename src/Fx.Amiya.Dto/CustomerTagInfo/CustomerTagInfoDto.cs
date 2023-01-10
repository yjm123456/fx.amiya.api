using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerTagInfo
{
    public class CustomerTagInfoDto:BaseDto
    {
        public string TagName { get; set; }
        public int? TagCategory { get; set; }
        public string TagCategoryName { get; set; }
    }
}
