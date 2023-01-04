using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Gift
{
    public class AddGiftInfoVo
    {
        /// <summary>
        /// 礼品名称
        /// </summary>
       [Required(ErrorMessage = "礼品名称不能为空")]
       [StringLength(100,ErrorMessage = "礼品名称不能超过{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 礼品类别id
        /// </summary>
        public string CategoryId { get; set; }
    }
}
