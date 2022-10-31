using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.AmiyaLessonApply
{
    public class AddAmiyaLessonApplyInfoVo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// 职位
        /// </summary>

        public string Position { get; set; }
        /// <summary>
        /// 所在城市
        /// </summary>
        public string City { get; set; }
    }
}
