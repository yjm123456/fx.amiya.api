using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Integration
{
    public class EditIntegrationgenerationDto
    {
        public string CustomerId { get; set; }
        /// <summary>
        /// 修改数量
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// 客服id
        /// </summary>
        public int  EmployeeId { get; set; }
    }
}
