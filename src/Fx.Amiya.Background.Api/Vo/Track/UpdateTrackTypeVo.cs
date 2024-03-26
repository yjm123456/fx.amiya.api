using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    public class UpdateTrackTypeVo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "回访类型名称不能为空")]
        public string Name { get; set; }
        public bool HasModel { get; set; }
        public bool Valid { get; set; }
        /// <summary>
        /// true:老客 false:新客
        /// </summary>
        public bool IsOldCustomer { get; set; }
        /// <summary>
        /// 回访模板
        /// </summary>
        public List<TrackTypeThemeModelVo> TrackTypeThemeModelVo { get; set; }
    }
}
