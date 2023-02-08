using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Bill
{
    /// <summary>
    /// 添加票据回款
    /// </summary>
    public class AddBillReturnBackPriceVo
    {
        /// <summary>
        /// 票据编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 回款时间
        /// </summary>

        public DateTime ReturnBackDate { get; set; }
        /// <summary>
        /// 回款备注
        /// </summary>
        public string Remark { get; set; }

    }
}
