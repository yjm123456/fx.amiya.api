using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.UpdateCreateBillAndCompany
{
    public class UpdateCreateBillAndCompanyDto
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 成交订单id
        /// </summary>
        public string OrderDetailInfoId { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool IsCreateBill { get; set; }
        /// <summary>
        /// 开票公司id
        /// </summary>
        public string CreateBillCompanyId { get; set; }
    }
}
