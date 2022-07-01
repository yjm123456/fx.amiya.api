using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TmallOrder
{
    public class OrderExpressInfoDto
    {  
        /// <summary>
        /// 返回数据说明
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string ExpressNo { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string ExpressName { get; set; }

        /// <summary>
        /// 快递当前状态
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 物流详情
        /// </summary>
        public List<ExpressDetailsDto> data { get; set; }
    }

    public class ExpressDetailsDto
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime time { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string context { get; set; }
    }
}
