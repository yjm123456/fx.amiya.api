using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchor
{
    public class UpdateLiveAnchorVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get;set; }
        /// <summary>
        /// 主播姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 主播平台账号
        /// </summary>

        public string HostAccountName { get; set; }

        /// <summary>
        /// 平台id
        /// </summary>
        public string ContentPlateFormId { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
    }
}
