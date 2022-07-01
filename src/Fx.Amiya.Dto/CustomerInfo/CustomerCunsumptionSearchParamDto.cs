using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerInfo
{
    public class CustomerCunsumptionSearchParamDto
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 关键字（订单号输入时该板块置灰无法输入）
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 创建开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 创建结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 最新下单渠道（1：下单平台，2：内容平台）
        /// </summary>
        public int Channel { get; set; }


        /// <summary>
        /// 绑定客服的编号，-1查全部
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 消费等级id
        /// </summary>
        public string ConsumptionLevelId { get; set; }

        public int PageNum { get; set; }
        public int PageSize { get; set; }
    }
}
