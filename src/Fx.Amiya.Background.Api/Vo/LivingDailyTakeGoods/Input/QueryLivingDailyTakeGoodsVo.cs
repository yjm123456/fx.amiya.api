using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Input
{
    /// <summary>
    /// 查询主播带货基础类
    /// </summary>
    public class QueryLivingDailyTakeGoodsVo:BaseQueryVo
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateBy { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool? Valid { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>

        public string BrandId { get; set; }
        /// <summary>
        /// 品类id
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 品项id
        /// </summary>

        public string ItemDetailsId { get; set; }
    }
}
