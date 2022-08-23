using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GrowthPoints
{
    public class UpdateGrowthPointsAccountDto
    {
        public string CustomerId { get; set; }
        /// <summary>
        /// 增加值
        /// </summary>
        public decimal IncreaseCount { get; set; }
    }
}
