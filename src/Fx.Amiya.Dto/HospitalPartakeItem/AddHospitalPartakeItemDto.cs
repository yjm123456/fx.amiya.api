using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalPartakeItem
{
   public class AddHospitalPartakeItemDto
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public List<ItemInfoDto> ItemInfoList { get; set; }
        public int ActivityId { get; set; }
    }
    /// <summary>
    /// 参与项目信息
    /// </summary>
    public class ItemInfoDto
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
