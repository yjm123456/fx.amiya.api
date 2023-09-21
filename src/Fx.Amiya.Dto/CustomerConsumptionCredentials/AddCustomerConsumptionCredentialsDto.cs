using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerConsumptionCredentials
{
    public class AddCustomerConsumptionCredentialsDto
    {
        /// <summary>
        /// 基础主播id
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string ToHospitalPhone { get; set; }

        public string LiveAnchor { get; set; }

        public DateTime ConsumeDate { get; set; }

        public string PayVoucherPicture1 { get; set; }
        public string PayVoucherPicture2 { get; set; }
        public string PayVoucherPicture3 { get; set; }
        public string PayVoucherPicture4 { get; set; }
        public string PayVoucherPicture5 { get; set; }

    }
}
