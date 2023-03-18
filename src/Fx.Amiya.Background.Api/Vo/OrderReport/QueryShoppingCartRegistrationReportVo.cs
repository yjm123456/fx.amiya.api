using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryShoppingCartRegistrationReportVo : BaseQueryVo
    {
        /// <summary>
        /// 重要程度
        /// </summary>
        public int? emergencyLevel { get; set; }
        /// <summary>
        /// 主播id
        /// </summary>
        public int? LiveAnchorId { get; set; }
        /// <summary>
        /// 录单触达
        /// </summary>
        public bool? IsCreateOrder { get; set; }
        /// <summary>
        /// 派单触达
        /// </summary>
        public bool? IsSendOrder { get; set; }
        /// <summary>
        /// 是否加v
        /// </summary>
        public bool? IsAddWechat { get; set; }
        /// <summary>
        /// 是否核销
        /// </summary>
        public bool? IsWriteOff { get; set; }
        /// <summary>
        /// 是否面诊
        /// </summary>
        public bool? IsConsultation { get; set; }
        /// <summary>
        /// 是否回款
        /// </summary>
        public bool? IsReturnBackPrice { get; set; }
        /// <summary>
        /// 内容平台id
        /// </summary>
        public string ContentPlatFormId { get; set; }
    }
}
