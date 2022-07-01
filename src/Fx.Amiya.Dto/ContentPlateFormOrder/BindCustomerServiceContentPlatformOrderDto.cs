using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
   public class BindCustomerServiceContentPlatformOrderDto
    {
        public string Id { get; set; }
        public int OrderType { get; set; }
        public string OrderTypeText { get; set; }
        public string ContentPlatformId { get; set; }
        public string ContentPlatformName { get; set; }
        public int? LiveAnchorId { get; set; }
        public string LiveAnchorName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string ThumbPictureUrl { get; set; }
        public string CustomerName { get; set; }
        public string EncryptPhone { get; set; }
        public string Phone { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? AppointmentHospitalId { get; set; }
        public string AppointmentHospitalName { get; set; }
        public int OrderStatus { get; set; }
        public string OrderStatusText { get; set; }
        public string Remark { get; set; }
        public int CustomerServiceId { get; set; }
        public string CustomerServiceName { get; set; }
    }
}
