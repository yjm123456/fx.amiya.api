using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokOrder
{
    public class TikTokOrderTradeAddDto
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerId { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 收货地址编号
        /// </summary>
        public int? AddressId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否管理员录单
        /// </summary>
        public bool IsAdminAdd { get; set; } = false;

        public List<TikTokOrderAddDto> OrderInfoAddList { get; set; }
    }
}
