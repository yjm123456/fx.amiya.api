using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OfficialWebsite.Input
{
    public class LoginVo
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [RegularExpression("^1[345789]\\d{9}$", ErrorMessage = "手机号格式错误")]
        public string Phone { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
    }
}
