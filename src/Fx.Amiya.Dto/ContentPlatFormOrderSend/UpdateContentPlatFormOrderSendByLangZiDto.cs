using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlatFormOrderSend
{
    public class UpdateContentPlatFormOrderSendByLangZiDto
    {
        public int Id { get; set; }
        /// <summary>
        /// 医院备注
        /// </summary>
        public string HospitalRemark { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderStatus { get; set; }
        /// <summary>
        /// 是否重单
        /// </summary>
        public bool IsRepeatProfundityOrder { get; set; }
    }
}
