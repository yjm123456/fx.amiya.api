using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GrowthPoints
{
    public class GrowthPointsRuleDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 任务编码
        /// </summary>
        public string TaskCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 赠送成长值数量
        /// </summary>
        public decimal RewardQuantity { get; set; }
        /// <summary>
        /// 赠送类型,0赠送固定值,1按比例赠送
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 赠送成长值比例
        /// </summary>
        public decimal RewardQuantityPercent { get; set; }
    }
}
