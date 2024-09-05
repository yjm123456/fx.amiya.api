using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalContentplatformCode.Input
{
    public class QueryIsRepeateByHospitalIdAndThirdPartIdVo
    {
        public string ThirdPartContentplatformInfoId { get; set; }
        public int HospitalId { get; set; }
        public string OrderId { get; set; }

        public int SendOrderId { get; set; }
    }
}
