using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveType
{
    public class AddLiveTypeVo
    {
        [Required(ErrorMessage ="直播类型名称不能为空")]
        public string Name { get; set; }

    }
}
