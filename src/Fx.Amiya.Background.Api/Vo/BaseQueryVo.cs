using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo
{
    /// <summary>
    /// 查询基础类
    /// </summary>
    public class BaseQueryVo
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 第/页
        /// </summary>
        public int? PageNum { get; set; }
        /// <summary>
        /// 每页/行
        /// </summary>
        public int? PageSize { get; set; }

    }
}
