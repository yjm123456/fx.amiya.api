using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ItemInfo
{
    /// <summary>
    /// 医院参与项目情况
    /// </summary>
    public class ItemSimpleListVo
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 是否同意直播价格
        /// </summary>
        public bool IsAgreeLivingPrice { get; set; }
        /// <summary>
        /// 医院价格
        /// </summary>
        public decimal? HospitalPrice { get; set; }
    }
}
