using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder
{
    /// <summary>
    /// 内容平台订单客户照片基础类
    /// </summary>
    public class ContentPlatFormCustomerPictureVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 内容平台订单号
        /// </summary>
        public string ContentPlatFormId { get; set; }
        /// <summary>
        /// 客户照片地址
        /// </summary>
        public string CustomerPicture { get; set; }
    }
}
