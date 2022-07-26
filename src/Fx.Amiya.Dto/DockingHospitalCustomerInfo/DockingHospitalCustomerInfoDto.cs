using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.DockingHospitalCustomerInfo
{
    /// <summary>
    /// 对接医院客户/订单绑定信息
    /// </summary>
    public class DockingHospitalCustomerInfoDto
    {
        public int Id { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string AccessToken { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string RefreshToken { get; set; }
        public int HospitalId { get; set; }
        public string BaseUrl { get; set; }
        public string TokenUrl { get; set; }
        public string GetCustomerUrl { get; set; }
        public string GetCustomerOrderUrl { get; set; }

        public string GetOrderUrl { get;set; }

        public string HospitalName { get; set; }
    }
}
