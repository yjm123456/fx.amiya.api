using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.AmiyaEmployee
{
    public class UpdatePasswordAmiyaVo
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(50, ErrorMessage = "密码最大长度为50个字符")]
        public string OldPassword { get; set; }



        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(50, ErrorMessage = "密码最大长度为50个字符")]
        [RegularExpression("(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{8,}", ErrorMessage = "请输入数字加字母最少8位的密码")]
        public string NewPassword { get; set; }
    }
}
