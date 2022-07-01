using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Activity
{
    public class AddActivityItemDetailVo
    {
        /// <summary>
        /// 活动编号
        /// </summary>
        public int ActivityId { get; set; }

     
        public List<AddActivityItemVo> ActivityItemList { get; set; }
    }

    public class AddActivityItemVo
    { 
        /// <summary>
        /// 项目编号
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 日常价
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 直播价
        /// </summary>
        public decimal LivePrice { get; set; }


    }
}
