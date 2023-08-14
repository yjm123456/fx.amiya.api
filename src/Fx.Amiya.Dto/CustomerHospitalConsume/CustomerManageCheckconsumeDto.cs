﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerHospitalConsume
{
    public class CustomerManageCheckconsumeDto
    {
        /// <summary>
        /// 升单编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int CheckState { get; set; }

        /// <summary>
        /// 审核升单金额
        /// </summary>
        public decimal CheckBuyAgainPrice { get; set; }

        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal CheckSettlePrice { get; set; }
        /// <summary>
        /// 审核助理服务费
        /// </summary>
        public decimal? CustomerServiceSettlePrice { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        public int CheckEmpId { get; set; }
        /// <summary>
        /// 审核信息
        /// </summary>
        public string CheckRemark { get; set; }
        /// <summary>
        /// 审核图片
        /// </summary>
        public List<string> CheckPicture { get; set; }
        /// <summary>
        /// 对账单id
        /// </summary>
        public string ReconciliationDocumentsId { get; set; }
        /// <summary>
        /// 对账医院id
        /// </summary>
        public int HospitalId { get; set; }
    }
}
