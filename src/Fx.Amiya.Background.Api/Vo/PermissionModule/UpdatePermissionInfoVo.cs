using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.PermissionModule
{
    public class UpdatePermissionInfoVo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "按钮权限描述不能为空")]
        public string Descrition { get; set; }


        [Required(ErrorMessage = "按钮权限名称不能为空")]
        public string Name { get; set; }
    }
}
