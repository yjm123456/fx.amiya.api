using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerConsumptionCredentials
{
    public class CustomerConsumptionCredentialsDto : BaseDto
    {
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

        public int CheckState { get; set; }
        public string CheckStateText { get; set; }
        public int? CheckBy { get; set; }
        public string CheckByEmpname { get; set; }

        public string BaseLiveAnchorId { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckRemark { get; set; }

    }
}
