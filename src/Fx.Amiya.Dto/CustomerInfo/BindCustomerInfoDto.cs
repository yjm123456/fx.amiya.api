using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.CustomerInfo
{
   public class BindCustomerInfoDto
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public int? CustomerServiceId { get; set; }
        public string CustomerServiceName { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }
}
