using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Address
{
    public class AddressVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ReceiveName { get; set; }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ReceivePhone { get; set; }
      
    }
}
