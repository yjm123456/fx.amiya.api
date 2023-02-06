using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MiniProgramSendMessage
{
    public class SendVoucherMessageDto
    {
        public string CustomerId { get; set; }
        public string VoucherName { get; set; }
        public string DeductMoney { get; set; }
        public string UseageRange { get; set; }
        public string ExpireDate { get; set; }
        public string Remark { get; set; }
    }
}
