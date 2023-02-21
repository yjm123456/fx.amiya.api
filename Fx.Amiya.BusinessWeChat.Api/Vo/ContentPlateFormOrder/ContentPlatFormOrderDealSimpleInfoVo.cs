using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder
{
    public class ContentPlatFormOrderDealSimpleInfoVo
    {
        
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string ContentPlatFormOrderId { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 是否是重单可深度订单
        /// </summary>
        public bool IsRepeatProfundityOrder { get; set; }
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 是否成交
        /// </summary>
        public bool IsDeal { get; set; }

        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal? DealPrice { get; set; }
        /// <summary>
        /// 新客/老客
        /// </summary>
        public bool IsOldCustomer { get; set; }
        /// <summary>
        /// 面诊状态文本
        /// </summary>
        public string ConsultationTypeText { get; set; }

        /// <summary>
        /// 到院类型文本
        /// </summary>
        public string ToHospitalTypeText { get; set; }

        /// <summary>
        /// 到院时间
        /// </summary>
        public DateTime? TohospitalDate { get; set; }


        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? DealDate { get; set; }

    }
}
