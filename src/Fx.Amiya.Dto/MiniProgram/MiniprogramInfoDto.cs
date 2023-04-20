using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MiniProgram
{
    public class MiniprogramInfoDto
    {
        /// <summary>
        /// 小程序名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 小程序appid
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 是否是主小程序程序
        /// </summary>
        public bool IsMain { get; set; }
        /// <summary>
        /// 归属的小程序id
        /// </summary>
        public string BelongMiniprogramAppId { get; set; }
        /// <summary>
        /// 小程序归属主播
        /// </summary>
        public int? BelongLiveAnchorId { get; set; }
    }
}
