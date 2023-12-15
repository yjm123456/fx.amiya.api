using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AssistantHomePage.Result
{
    public class TodayToHospitalDataVo
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 助理
        /// </summary>
        public string AssistantName { get; set; }
        /// <summary>
        /// 派单机构
        /// </summary>
        public string SendHospital { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public String Status { get; set; }
        /// <summary>
        /// 加密手机号
        /// </summary>
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 下单金额
        /// </summary>
        public decimal? AddOrderPrice { get; set; }

        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal? DealPrice { get; set; }

        /// <summary>
        /// 新客/老客
        /// </summary>
        public string IsOldCustomer { get; set; }
    }
}
