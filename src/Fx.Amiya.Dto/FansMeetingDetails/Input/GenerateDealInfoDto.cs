using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.FansMeetingDetails.Input
{
    public class GenerateDealInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 成交信息id
        /// </summary>
        public string DealId { get; set; }
        /// <summary>
        /// 是否成交
        /// </summary>
        public bool IsDeal { get; set; }
        /// <summary>
        /// 是否到院
        /// </summary>
        public bool IsToHospital { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal DealPrice { get; set; }
        /// <summary>
        /// 原有成交金额
        /// </summary>
        public decimal OriginalDealPrice { get; set; }
        /// <summary>
        /// 未成交原因
        /// </summary>
        public string UnDealReason { get; set; }

        /// <summary>
        /// 见面会铺垫项目
        /// </summary>
        public string FansMeetingProject { get; set; }

        /// <summary>
        /// 追踪内容
        /// </summary>
        public string FollowUpContent { get; set; }

        /// <summary>
        /// 下次邀约时间
        /// </summary>
        public DateTime? NextAppointmentDate { get; set; }
        /// <summary>
        /// 是否需要机构协助邀约
        /// </summary>
        public bool IsNeedHospitalHelp { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public int EmpId { get; set; }
    }
}
