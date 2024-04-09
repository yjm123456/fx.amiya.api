using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    /// <summary>
    /// 获取客户运营情况输出数据
    /// </summary>
    public class GetCustomerAnalizeDataVo
    {
        /// <summary>
        /// 派单数据
        /// </summary>
        public CustomerAnalizeByGroup SendNum { get; set; }

        /// <summary>
        /// 上门数据
        /// </summary>
        public CustomerAnalizeByGroup VisitNum { get; set; }

        /// <summary>
        /// 成交数据
        /// </summary>
        public CustomerAnalizeByGroup DealNum { get; set; }
    }

    /// <summary>
    /// 客户分组运营数据
    /// </summary>
    public class CustomerAnalizeByGroup
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
