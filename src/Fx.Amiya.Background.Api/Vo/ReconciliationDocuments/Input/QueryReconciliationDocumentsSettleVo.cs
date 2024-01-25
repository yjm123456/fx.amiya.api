﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments.Input
{
    public class QueryReconciliationDocumentsSettleVo : BaseQueryVo
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public int? ChooseHospitalId { get; set; }

        /// <summary>
        /// 新/老客业绩
        /// </summary>
        public bool? IsOldCustoemr { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public int? BelongEmpId { get; set; }
        /// <summary>
        /// 稽查客服
        /// </summary>
        public int? InspectEmpId { get; set; }
        /// <summary>
        /// 上传人
        /// </summary>
        public int? CreateEmpId { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState { get; set; }
        /// <summary>
        /// 是否生成薪资单(1,未生成,2已生成)
        /// </summary>
        public int? IsGenerateSalry { get; set; }
    }
}
