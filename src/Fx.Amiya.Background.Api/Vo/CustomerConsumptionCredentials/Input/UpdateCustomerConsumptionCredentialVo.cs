using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerConsumptionCredentials.Input
{
    public class UpdateCustomerConsumptionCredentialVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 助理id
        /// </summary>
        public int AssistantId { get; set; }
    }
}
