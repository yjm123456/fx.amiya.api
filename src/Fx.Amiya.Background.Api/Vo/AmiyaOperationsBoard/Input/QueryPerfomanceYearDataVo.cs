using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Input
{
    public class QueryPerfomanceYearDataVo
    {
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 新/老客（可传空）
        /// </summary>
        public bool? IsOldCustomer { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public int BelongChannel { get; set; }

        /// <summary>
        /// 助理id
        /// </summary>
        public int? AssistantId { get; set; }
    }

    public class QueryMingSuoPerfomanceYearDataVo
    {
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 新/老客（可传空）
        /// </summary>
        public bool? IsOldCustomer { get; set; }


        /// <summary>
        /// 主播基础id（可传空）
        /// </summary>
        public string LiveAnchorBaseIdId { get; set; }
        /// <summary>
        /// 归属部门
        /// </summary>
        public int BelongChannel { get; set; }
    }
}
