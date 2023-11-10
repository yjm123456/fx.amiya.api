using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.SendOrderInfo
{
   public class SendOrderInfoDto
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public decimal PurchaseSinglePrice { get; set; }

        public int PurchaseNum { get; set; }
        public int SendBy { get; set; }
        public string SendName { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsUncertainDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public byte? TimeType { get; set; }
        public string Time { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }

        /// <summary>
        /// 医院是否已查看过电话
        /// </summary>
        public bool IsHospitalCheckPhone { get; set; }
        public string GoodsId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string GoodsName { get; set; }
        public string Description { get; set; }
        public string Standard { get; set; }
        public string Parts { get; set; }
        public decimal? ActualPayment { get; set; }
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

        /// <summary>
        /// 首次留言内容
        /// </summary>
        public string FirstMessageContent { get; set; }
        /// <summary>
        /// 是否为主派医院
        /// </summary>
        public bool IsMainHospital { get; set; }

    }
}
