using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Gift
{
   public class ReceiveGiftWrapperOfWxDto
    {
        public string CourierNumber { get; set; }
        public string ExpressId { get; set; }
        public string ReceiverPhone { get; set; }
        public string DeliveryStatus { get; set; }

        public List<ReceiveGiftSimpleOfWxDto> GiftInfos { get; set; }
    }

}
