using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ThirdPartContentPlatformInfo
{
    public class QueryIsRepeateByHospitalIdAndThirdPartIdVo
    {
        public string ThirdPartContentplatformInfoId { get; set; }
        public int HospitalId { get; set; }
        public string OrderId { get; set; }

        public int SendOrderId { get; set; }

        /// <summary>
        /// 业务类型（C:查重；P：派单）
        /// </summary>
        public string YWLX { get; set; }
    }
}
