using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchor
{
    /// <summary>
    /// 主播id和主播名字（平台）
    /// </summary>
    public class LiveAnchorIdAndNameVo
    {
        /// <summary>
        /// 主播id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 主播账号（平台）
        /// </summary>
        public string Name { get; set; }
    }
}
