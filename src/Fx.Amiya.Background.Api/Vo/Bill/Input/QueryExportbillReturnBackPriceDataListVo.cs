using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Bill.Input
{
    public class QueryExportbillReturnBackPriceDataListVo:BaseQueryVo
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 回款状态（未回款/回款中/已回款）
        /// </summary>
        public int? ReturnBackState { get; set; }
        /// <summary>
        /// 收款公司id
        /// </summary>
        public string CompanyId { get; set; }
    }
}
