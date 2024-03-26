using Fx.Amiya.Dto.TrackTypeThemeModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Track
{
   public class AddTrackTypeDto
    {
        public string Name { get; set; }
        /// <summary>
        /// 是否需要模板
        /// </summary>
        public bool HasModel { get; set; }
        /// <summary>
        /// true:老客 false:新客
        /// </summary>
        public bool IsOldCustomer { get; set; }

        /// <summary>
        /// 回访模板
        /// </summary>
        public List<AddTrackTypeThemeModelDto> TrackTypeThemeModelDto { get; set; }
    }
}
