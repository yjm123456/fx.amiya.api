using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPartakeItem
{
    public class AddHospitalPartakeItemVo
    {
        /// <summary>
        /// 活动编号
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public List<ItemInfoVo> ItemInfoList { get; set; }

    }
    /// <summary>
    /// 参与项目信息
    /// </summary>
    public class ItemInfoVo
    {
        /// <summary>
        /// 项目id
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// 是否同意直播报价
        /// </summary>
        public bool IsAgreeLivingPrice { get; set; }
        /// <summary>
        /// 医院报价
        /// </summary>
        public decimal HospitalPrice { get; set; }
    }
}
