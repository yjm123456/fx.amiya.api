using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaEmployee
{
    public class AddAmiyaEmployeeVo
    {
        [Required(ErrorMessage ="姓名不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }

        public int PositionId { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>

        [Required(ErrorMessage = "邮箱不能为空")]
        public string Email { get; set; }
        /// <summary>
        /// 是否是客服
        /// </summary>
        public bool IsCustomerService { get; set; }
        /// <summary>
        /// 绑定的主播id
        /// </summary>
        public string LiveAnchorBaseId { get; set; }
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
