using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Bill.Input
{
    public class QueryExportBillListVo : BaseQueryVo
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 是否作废（1正常，0作废）
        /// </summary>
        public bool? Valid { get; set; }
        /// <summary>
        /// 票据类型（医美/其他）
        /// </summary>
        public int? BillType { get; set; }
        /// <summary>
        /// 回款状态（未回款/回款中/已回款）
        /// </summary>
        public int? ReturnBackState { get; set; }
        /// <summary>
        /// 收款公司
        /// </summary>
        public string CompanyId { get; set; }
    }
}
