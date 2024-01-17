using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.FeishuMultidimensionalTable.Result
{
    public class ShortVideoFansDataInfoVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 统计时间
        /// </summary>
        public DateTime StatsDate { get; set; }
        /// <summary>
        /// 新增粉丝
        /// </summary>
        public int NewFansCount { get; set; }
        /// <summary>
        /// 总粉丝
        /// </summary>
        public int TotalFansCount { get; set; }
        /// <summary>
        /// 归属主播名称
        /// </summary>
        public string LiveAnchorName { get; set; }
    }
}
