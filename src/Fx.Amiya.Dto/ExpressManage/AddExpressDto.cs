using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ExpressManage
{
    public class AddExpressDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 物流公司名称
        /// </summary>

        public string ExpressName { get; set; }
        /// <summary>
        /// 物流公司编码
        /// </summary>
        public string ExpressCode { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Valid { get; set; }
    }
}
