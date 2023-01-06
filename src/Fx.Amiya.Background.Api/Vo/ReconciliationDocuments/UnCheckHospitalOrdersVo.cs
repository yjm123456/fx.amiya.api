using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments
{
    /// <summary>
    /// 医院未对账订单列表
    /// </summary>
    public class UnCheckHospitalOrdersVo
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        ///医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 未对账总金额
        /// </summary>
        public decimal TotalUnCheckPrice { get; set; }
        /// <summary>
        /// 未对账总单量
        /// </summary>
        public int TotalUnCheckOrderCount { get; set; }

        /// <summary>
        /// 天猫未对账金额
        /// </summary>
        public decimal TmallUnCheckPrice { get; set; }
        /// <summary>
        /// 天猫未对账单量
        /// </summary>
        public int TmallUnCheckOrderCount { get; set; }

        /// <summary>
        /// 内容平台未对账金额
        /// </summary>
        public decimal ContentPlatFormUnCheckPrice { get; set; }
        /// <summary>
        /// 内容平台未对账单量
        /// </summary>
        public int ContentPlatFormUnCheckOrderCount { get; set; }

        /// <summary>
        /// 升单未对账金额
        /// </summary>
        public decimal HospitalCustomerConsumeUnCheckPrice { get; set; }
        /// <summary>
        /// 升单未对账单量
        /// </summary>
        public int HospitalCustomerConsumeUnCheckOrderCount { get; set; }
    }
}
