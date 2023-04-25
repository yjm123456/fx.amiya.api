using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class HospitalBoardOrderDataDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }
        /// <summary>
        /// 是否上门
        /// </summary>
        public bool IsToHospital { get; set; }
        /// <summary>
        /// 是否成交
        /// </summary>
        public bool IsDeal { get; set; }
        /// <summary>
        /// 是否复购
        /// </summary>
        public bool IsRepurchase { get; set; }
    }
}
