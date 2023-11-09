using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Gift
{
    public class CustomerServiceSendGiftDto
    {
        public int Id { get; set; }
        public string ReceiveName { get; set; }
        /// <summary>
        /// 收货号码
        /// </summary>
        public string ReceivePhone { get; set; }
        public string Address { get; set; }
        public int CreateBy { get; set; }
        public int Quantity { get; set; }
        public int GiftId { get; set; }
    }
}
