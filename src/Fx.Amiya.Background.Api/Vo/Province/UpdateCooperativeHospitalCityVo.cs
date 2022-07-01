using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Province
{
    public class UpdateProvinceVo
    {
        public string Id { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [Required(ErrorMessage ="省份名称不能为空")]
        [StringLength(20,ErrorMessage ="省份名称最多{1}个字符")]
        public string Name { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
    }
}
