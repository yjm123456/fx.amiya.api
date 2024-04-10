using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class GetCustomerAnalizeDataDto
    {
        /// <summary>
        /// 派单数据
        /// </summary>
        public CustomerAnalizeByGroupDto SendNum { get; set; }

        /// <summary>
        /// 上门数据
        /// </summary>
        public CustomerAnalizeByGroupDto VisitNum { get; set; }

        /// <summary>
        /// 成交数据
        /// </summary>
        public CustomerAnalizeByGroupDto DealNum { get; set; }
    }
    /// <summary>
    /// 客户分组运营数据
    /// </summary>
    public class CustomerAnalizeByGroupDto
    {

        /// <summary>
        /// 总人数
        /// </summary>
        public int TotalNum { get; set; }

        /// <summary>
        /// 刀刀组人数
        /// </summary>
        public int GroupDaoDao { get; set; }

        /// <summary>
        /// 吉娜组人数
        /// </summary>
        public int GroupJiNa { get; set; }
    }
}
