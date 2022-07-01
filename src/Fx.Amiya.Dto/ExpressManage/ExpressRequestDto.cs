using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ExpressManage
{
    public class ExpressRequestDto
    {
        public string customer { get; set; }
        public string sign { get; set; }
        public string param { get; set; }
    }
    public class ExpressDetail
    {
        /// <summary>
        /// 快递公司code
        /// </summary>
        public string com { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string num { get; set; }
        /// <summary>
        /// 收件人手机号
        /// </summary>
        public string phone { get; set; }
    }
}
