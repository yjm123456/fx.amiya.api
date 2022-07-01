using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Integration
{
    public record IntegrationUseRecordDto
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 使用类型
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 积分使用类型文本
        /// </summary>
        public string TypeText { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal UseQuantity { get; set; }

        /// <summary>
        /// 该客户的积分账户实时余额（产生这条记录的时候的余额）
        /// </summary>
        public decimal AccountBalance { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate{ get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

    }
}
