using Fx.Amiya.BusinessWechat.Api.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlatFormOrderAddWork
{
    public class QueryContentPlatFormOrderAddWorkVo: BaseQueryVo
    {
        /// <summary>
        /// 医院id（空查询所有）
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 审核状态（空查询所有）
        /// </summary>
        public int? CheckState { get; set; }

        /// <summary>
        /// 提交人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public int? AcceptBy { get; set; }
    }
}
