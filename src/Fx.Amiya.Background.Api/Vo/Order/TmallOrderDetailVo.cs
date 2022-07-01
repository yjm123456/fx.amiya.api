using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class TmallOrderDetailVo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public long GoodsId { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }

   // public string AppointmentHospital { get; set; }

        /// <summary>
        /// 派单医院编号
        /// </summary>
        public int? SendOrderHospitalId { get; set; }

        /// <summary>
        /// 派单医院名称
        /// </summary>
        public string SendOrderHospitalName { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 项目描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        /// 部位
        /// </summary>
        public string Parts { get; set; }

        /// <summary>
        /// 派单时间
        /// </summary>
        public DateTime? SendOrderDate { get; set; }

        /// <summary>
        /// 是否已核销
        /// </summary>
        public bool IsVerification { get; set; }
        public decimal? ActualPayment { get; set; }
    }
}
