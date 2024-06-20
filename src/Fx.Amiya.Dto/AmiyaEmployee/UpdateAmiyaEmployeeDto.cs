using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
   public class UpdateAmiyaEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public bool Valid { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        public bool IsCustomerService { get; set; }

        /// <summary>
        /// 主播基础信息id
        /// </summary>
        public string LiveAnchorBaseId { get; set; }

        /// <summary>
        /// 当为客服/运营咨询情况下上传绑定主播ID
        /// </summary>
        public List<int> LiveAnchorIds { get; set; }
        /// <summary>
        /// 有效新客提成
        /// </summary>
        public decimal? NewCustomerCommission { get; set; }
        /// <summary>
        /// 潜在新客提成
        /// </summary>
        public decimal? PotentialNewCustomerCommission { get; set; }
        /// <summary>
        /// 老客提成
        /// </summary>
        public decimal? OldCustomerCommission { get; set; }
        /// <summary>
        /// 财务参与稽查后提成
        /// </summary>
        public decimal? InspectionCommission { get; set; }
        /// <summary>
        /// 行政客服参与稽查后提成
        /// </summary>
        public decimal AdministrativeInspection { get; set; }
        /// <summary>
        /// 行政客户稽查提成比例
        /// </summary>
        public decimal AdministrativeInspectionCommission { get; set; }
        /// <summary>
        /// 达人新客提成比例
        /// </summary>
        public decimal CooperateLiveanchorNewCustomerCommission { get; set; }
        /// <summary>
        /// 达人老客提成比例
        /// </summary>
        public decimal CooperateLiveanchorOldCustomerCommission { get; set; }
        /// <summary>
        /// 天猫升单比例
        /// </summary>
        public decimal TmallOrderCommission { get; set; }
    }
}
