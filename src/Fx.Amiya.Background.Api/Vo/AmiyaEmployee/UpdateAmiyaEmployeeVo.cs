using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaEmployee
{
    public class UpdateAmiyaEmployeeVo
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage ="姓名不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "邮箱不能为空")]
        public string Email { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// 职位编号
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// 是否是客服
        /// </summary>
        public bool IsCustomerService { get; set; }

        /// <summary>
        /// 是否重置密码
        /// </summary>
        public bool IsResetPassword { get; set; }

        /// <summary>
        /// 主播基础信息id
        /// </summary>
        public string LiveAnchorBaseId { get; set; }

        /// <summary>
        /// 当为行政客服/运营咨询情况下上传绑定主播ID
        /// </summary>
        public List<int> LiveAnchorIds { get; set; }
        /// <summary>
        /// 新客提成
        /// </summary>
        public decimal? NewCustomerCommission { get; set; }
        /// <summary>
        /// 老客提成
        /// </summary>
        public decimal? OldCustomerCommission { get; set; }
        /// <summary>
        /// 稽查提成
        /// </summary>
        public decimal? InspectionCommission { get; set; }
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
