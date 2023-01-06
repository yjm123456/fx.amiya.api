using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    public class UnCheckHospitalOrderDto
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 未对账总金额
        /// </summary>
        public decimal TotalUnCheckPrice { get; set; }
        /// <summary>
        /// 未对账总单量
        /// </summary>
        public int TotalUnCheckOrderCount { get; set; }
    }
}
