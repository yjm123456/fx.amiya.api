using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalCustomer
{
    public class HospitalCustomerVo
    {
        /// <summary>
        /// 当前订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 是否为我跟进的订单
        /// </summary>
        public bool IsMyFollow { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 联系电话(加密)
        /// </summary>
        public string EncryptCustomerPhone { get; set; }
        /// <summary>
        /// 所在地区
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 整形项目
        /// </summary>
        public string GoodsDemand { get; set; }
        /// <summary>
        /// 首单派单时间
        /// </summary>
        public DateTime FirstSendDate { get; set; }
        /// <summary>
        /// 查重时间
        /// </summary>
        public DateTime? ConfirmOrderDate { get; set; }
        /// <summary>
        /// 上次派单时间
        /// </summary>
        public DateTime? NewSendDate { get; set; }
        /// <summary>
        /// 派单次数
        /// </summary>
        public int SendOrderNum { get; set; }
        /// <summary>
        /// 成交次数
        /// </summary>
        public int DealNum { get; set; }
    }
}
