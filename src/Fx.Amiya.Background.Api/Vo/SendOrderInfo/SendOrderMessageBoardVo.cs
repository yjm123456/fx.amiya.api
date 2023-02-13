using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.SendOrderInfo
{
    public class SendOrderMessageBoardVo
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// 留言方：0=啊美雅，1=医院
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 留言方名称
        /// </summary>
        public string TypeName { get; set; }

        public int SendOrderInfoId { get; set; }
        /// <summary>
        /// 医院logo
        /// </summary>
        public string HospitalLogo { get; set; }

        public int HospitalId { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string Content { get; set; }
    }
}
