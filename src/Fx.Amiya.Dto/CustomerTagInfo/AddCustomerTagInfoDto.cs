using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerTagInfo
{
    public class AddCustomerTagInfoDto
    {
        public string TagName { get; set; }
        /// <summary>
        /// 标签类别
        /// </summary>
        public int TagCategory { get; set; }
    }
}
