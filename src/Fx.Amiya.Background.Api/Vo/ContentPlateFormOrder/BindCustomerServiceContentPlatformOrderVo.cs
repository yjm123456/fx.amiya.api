using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    public class BindCustomerServiceContentPlatformOrderVo
    {

        public string Id { get; set; }
        public int OrderType { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderTypeText { get; set; }
        public string ContentPlatformId { get; set; }
        /// <summary>
        /// 内容平台名称
        /// </summary>
        public string ContentPlatformName { get; set; }
        public int? LiveAnchorId { get; set; }
        /// <summary>
        /// 主播
        /// </summary>
        public string LiveAnchorName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string GoodsId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 项目图片
        /// </summary>
        public string ThumbPictureUrl { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 加密电话
        /// </summary>
        public string EncryptPhone { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentDate { get; set; }
        public int? AppointmentHospitalId { get; set; }
        /// <summary>
        /// 预约医院
        /// </summary>
        public string AppointmentHospitalName { get; set; }
        public int OrderStatus { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatusText { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public int CustomerServiceId { get; set; }

        /// <summary>
        /// 绑定客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }
    }
}
