using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.RequirementType
{
    public class AddRequirementTypeVo
    {
        [Required(ErrorMessage ="需求类型名称不能为空")]
        public string Name { get; set; }
    }
}
