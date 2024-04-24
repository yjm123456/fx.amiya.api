using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class CompanyNewCustomerConversionDataVo
    {
        /// <summary>
        /// 分组名
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 派单数
        /// </summary>
        public decimal SendOrderCount { get; set; }
        /// <summary>
        /// 分诊量
        /// </summary>
        public int DistributeConsulationNum { get; set; }
        /// <summary>
        /// 加v
        /// </summary>
        public int AddWechatCount { get; set; }
        /// <summary>
        /// 加v率
        /// </summary>
        public decimal AddWechatRate { get; set; }
        /// <summary>
        /// 派单率
        /// </summary>
        public decimal SendOrderRate { get; set; }
        /// <summary>
        /// 上门数
        /// </summary>
        public int ToHospitalCount { get; set; }
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal ToHospitalRate { get; set; }
        /// <summary>
        /// 成交
        /// </summary>
        public int DealCount { get; set; }
        /// <summary>
        /// 成交率
        /// </summary>
        public decimal DealRate { get; set; }
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal Performance { get; set; }


    }
}
