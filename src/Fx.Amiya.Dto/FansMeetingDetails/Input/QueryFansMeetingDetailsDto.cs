using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.FansMeetingDetails.Input
{
    public class QueryFansMeetingDetailsDto:BaseQueryDto
    {
        /// <summary>
        /// 粉丝见面会id
        /// </summary>
        public string FansMeetingId { get; set; }

        /// <summary>
        /// 是否到院（非必填）
        /// </summary>
        public bool? IsToHospital { get; set; }

        /// <summary>
        /// 是否成交（非必填）
        /// </summary>
        public bool? IsDeal { get; set; }
        /// <summary>
        /// 啊美雅助理（非必填）
        /// </summary>
        public int? AmiyaEmployeeId { get; set; }

        /// <summary>
        /// 客户质量（非必填）
        /// </summary>
        public int? CustomerQuantity { get; set; }

        /// <summary>
        /// 新/老客（非必填）
        /// </summary>
        public bool? IsOdCustomer { get; set; }

        /// <summary>
        /// 消费区间（起）-非必填
        /// </summary>
        public decimal? StartDealPrice { get; set; }

        /// <summary>
        /// 消费区间（止）-非必填
        /// </summary>
        public decimal? EndDealPrice { get; set; }

        public bool IsHidePhone { get; set; }
    }
}
