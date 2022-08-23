using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GrowthPoints
{
    public class CreateGrowthPointsAccountDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 成长值
        /// </summary>
        public decimal Balance { get; set; }
    }
}
