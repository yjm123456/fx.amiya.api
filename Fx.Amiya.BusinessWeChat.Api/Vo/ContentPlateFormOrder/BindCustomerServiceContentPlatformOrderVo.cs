using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.ContentPlateFormOrder
{
    public class BindCustomerServiceContentPlatformOrderVo
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 项目图片
        /// </summary>
        public string ThumbPictureUrl { get; set; }
        /// <summary>
        /// 客户昵称
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
        /// 预约医院
        /// </summary>
        public string AppointmentHospitalName { get; set; }
        /// <summary>
        /// 绑定客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }
    }
}
