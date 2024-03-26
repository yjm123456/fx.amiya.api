using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    public class TrackTypeVo
    {

        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 回访类型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
        /// <summary>
        /// 是否存在模板
        /// </summary>
        public bool HasModel { get; set; }
        /// <summary>
        /// true:老客 false:新客
        /// </summary>
        public bool IsOldCustomer { get; set; }
        /// <summary>
        /// 回访模板
        /// </summary>
        public List<TrackTypeThemeModelVo> TrackTypeThemeModel { get; set; }
    }
}
