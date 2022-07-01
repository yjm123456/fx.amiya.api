using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TrackTheme
{
    public class AddTrackThemeVo
    {
        public int TrackTypeId { get; set; }

        [Required(ErrorMessage ="回访主题名称不能为空")]
        [StringLength(150,ErrorMessage ="回访主题名称不超过{1}个字符")]
        public string Name { get; set; }
    }
}
