﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderAddWork.Input
{
    public class CheckContentPlatFormOrderAddWorkVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 归属客服id
        /// </summary>
        public int BelongCustomerServiceId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int CheckState { get; set; }
    }
}
