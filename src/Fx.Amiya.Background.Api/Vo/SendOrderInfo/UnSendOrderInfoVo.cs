using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.SendOrderInfo
{
    public class UnSendOrderInfoVo
    {
        public string ThumbPicUrl { get; set; }
        public string OrderId { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }
        public decimal? ActualPayment { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string AppointmentHospital { get; set; }
        public string StatusCode { get; set; }
        public string StatusText { get; set; }

        /// <summary>
        /// 平台类型
        /// </summary>
        public byte AppType { get; set; }

        /// <summary>
        /// 平台类型名称
        /// </summary>
        public string AppTypeText { get; set; }


    }
}
