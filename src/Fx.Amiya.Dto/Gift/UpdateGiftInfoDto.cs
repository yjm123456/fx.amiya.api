using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fx.Amiya.Dto.Gift
{
   public class UpdateGiftInfoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "礼品名称不能为空")]
        [StringLength(100, ErrorMessage = "礼品名称不能超过{1}个字符")]
        public string Name { get; set; }
        public string ThumbPicUrl { get; set; }
        public int Quantity { get; set; }
        public bool Valid { get; set; }
        /// <summary>
        /// 类别id
        /// </summary>
        public string CategoryId { get; set; }
    }
}
