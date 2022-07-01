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
        /// 当为客服情况下上传绑定主播ID
        /// </summary>
        public List<int> LiveAnchorIds { get; set; }
    }
}
