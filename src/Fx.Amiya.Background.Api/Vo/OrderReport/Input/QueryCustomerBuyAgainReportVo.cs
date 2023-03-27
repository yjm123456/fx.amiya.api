using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport.Input
{
    /// <summary>
    /// 客户升单报表查询类
    /// </summary>
    public class QueryCustomerBuyAgainReportVo:BaseQueryVo
    {
        /// <summary>
        /// 渠道
        /// </summary>
        public int? Channel{get;set;}
        /// <summary>
        /// 审核开始时间(可空)
        /// </summary>
        public DateTime? CheckDateStart{get;set;}
        /// <summary>
        /// 审核结束时间(可空)
        /// </summary>
        public DateTime? CheckDateEnd{get;set;}
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState{get;set;}
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId{get;set;} 
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool? IsCreateBill{get;set;}
        /// <summary>
        /// 开票公司id
        /// </summary>
        public string BelongCompanyId{get;set;}
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get;set;} 
    }
}
