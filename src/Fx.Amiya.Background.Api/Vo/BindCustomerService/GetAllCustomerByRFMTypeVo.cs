
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BindCustomerService
{
    public class GetAllCustomerByRFMTypeVo:BaseQueryVo
    {
        /// <summary>
        /// rfm类型
        /// </summary>
        public int rfmType { get; set; }
        /// <summary>
        /// 绑定主播id集合
        /// </summary>
        public string LiveAnchorBaseId { get; set; }

        /// <summary>
        /// 助理id
        /// </summary>
        public int? EmployeeId { get; set; }
    }

    /// <summary>
    /// 根据条件获取客户RFM模型数据查询类
    /// </summary>
    public class GetAllCustomerByRFM
    {
        /// <summary>
        /// 绑定主播id集合
        /// </summary>
        public string  LiveAnchorBaseId { get; set; }

        /// <summary>
        /// 助理id
        /// </summary>
        public int? EmployeeId { get; set; }
    }
}
