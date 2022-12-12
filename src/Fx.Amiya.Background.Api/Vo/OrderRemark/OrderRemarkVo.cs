using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderRemark
{
    /// <summary>
    /// 订单备注
    /// </summary>
    public class OrderRemarkVo:BaseVo
    {
        /// <summary>
        /// 归属端口（0：啊美雅端；1：机构端）
        /// </summary>
        public int BelongAuthorize { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 创建人（根据归属端口判断员工）
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string EmployeeName { get; set; }
    }
}
