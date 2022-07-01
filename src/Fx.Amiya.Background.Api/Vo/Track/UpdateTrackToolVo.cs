using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    public class UpdateTrackToolVo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "回访工具名称不能为空")]
        public string Name { get; set; }
        public bool Valid { get; set; }
    }
}
