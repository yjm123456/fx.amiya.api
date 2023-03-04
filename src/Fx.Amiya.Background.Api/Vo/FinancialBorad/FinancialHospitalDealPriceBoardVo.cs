using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.FinancialBorad
{
    public class FinancialHospitalDealPriceBoardVo
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 对账业绩
        /// </summary>
        public decimal DealPrice { get; set; }
        /// <summary>
        /// 服务费合计
        /// </summary>
        public decimal TotalServicePrice { get; set; }
        /// <summary>
        /// 信息服务费
        /// </summary>
        public decimal InformationPrice { get; set; }
        /// <summary>
        /// 系统使用费
        /// </summary>
        public decimal SystemUsePrice { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 未回款金额
        /// </summary>
        public decimal UnReturnBackPrice { get; set; }
    }
}
