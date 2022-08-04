using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TikTok
{
    /// <summary>
    /// 抖店修改订单信息
    /// </summary>
    public class TikTokOrderInfoUpdateVo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
    }
}
