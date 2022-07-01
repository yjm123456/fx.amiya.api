using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.PermissionModule
{
    public class UpdateModuleVo
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="模块名称不能为空")]
        public string Name { get; set; }


        [Required(ErrorMessage = "模块描述不能为空")]
        public string Description { get; set; }


        [Required(ErrorMessage = "模块路径不能为空")]
        public string Path { get; set; }
        public bool Valid { get; set; }

        /// <summary>
        /// 上级菜单
        /// </summary>
        [Required(ErrorMessage = "上级菜单不能为空")]
        public int ModuleCategoryId { get; set; }
    }
}
