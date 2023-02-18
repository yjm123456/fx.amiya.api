using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.OrderCheckPicture
{
    /// <summary>
    /// 照片审核基础类
    /// </summary>
    public class OrderCheckPictureVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int OrderFrom { get; set; }
        /// <summary>
        /// 照片地址
        /// </summary>
        public string PictureUrl { get; set; }
    }
}
