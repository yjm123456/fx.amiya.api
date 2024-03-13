using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OfficialWebsite.Input
{
    public class GetGoodsOrderSignVo
    {
        /// <summary>
        /// 商品id
        /// </summary>
        [Required(ErrorMessage = "商品id不能为空")]
        public string GoodsId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>

        public string Phone { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 预约医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 商品规格id
        /// </summary>
        [Required(ErrorMessage = "商品规格不能为空")]
        public string StandardId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime? AppointmentDate { get; set; }
    }
}
