using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Order
{
    /// <summary>
    /// 小程序物流公司信息
    /// </summary>
    public class DeliveryInfoDto
    {
        public int errcode { get; set; }
        public List<DeliveryItemInfo> delivery_list { get; set; }
    }
    public class DeliveryItemInfo {
        public string delivery_id { get; set; }
        public string delivery_name { get; set; }
    }
}
