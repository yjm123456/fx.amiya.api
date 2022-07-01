using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Gift
{
    public class AddReceiveGiftDto
    {
        public string OrderId { get; set; }
        public int GiftId { get; set; }
        public int AddressId{get;set;}

    }
}
