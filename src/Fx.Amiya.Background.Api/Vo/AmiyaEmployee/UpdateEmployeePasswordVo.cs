using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaEmployee
{
    public class UpdateEmployeePasswordVo
    {
        public int Id { get; set; }

        [Required(ErrorMessage =("密码不能为空"))]
        public string Password { get; set; }
    }
}
