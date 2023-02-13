using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.SendOrderInfo
{
    public class AddSendOrderMessageBoardVo
    {
        /// <summary>
        /// 医院编号，啊美雅添加必传，医院添加为空
        /// </summary>
        public int? HospitalId { get; set; }

        /// <summary>
        /// 派单信息编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 内容
        /// </summary>

        [Required(ErrorMessage ="留言内容不能为空")]
        public string Content { get; set; }
    }
}
