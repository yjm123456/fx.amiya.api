using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ItemInfo
{
    public class UpdateItemInfoVo
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 对应天猫的商品编号
        /// </summary>
        public string OtherAppItemId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required(ErrorMessage = "项目名称不能为空")]
        [StringLength(100, ErrorMessage = "项目名称最多{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 科室id
        /// </summary>
        [Required(ErrorMessage = "请选择所属科室")]
        public string HospitalDepartmentId { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [Required(ErrorMessage = "缩略图不能为空")]
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 项目简介
        /// </summary>
        [StringLength(200, ErrorMessage = "项目简介最多{1}个字符")]
        public string Description { get; set; }


        /// <summary>
        /// 项目规格
        /// </summary>
        [Required(ErrorMessage = "项目规格不能为空")]
        [StringLength(100, ErrorMessage = "项目规格最多{1}个字符")]
        public string Standard { get; set; }


        /// <summary>
        /// 治疗部位
        /// </summary>
        [StringLength(100, ErrorMessage = "治疗部位最多{1}个字符")]
        public string Parts { get; set; }
        /// <summary>
        /// 渠道
        /// </summary>
        public int AppType { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }
        /// <summary>
        /// 品类id
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 直播价
        /// </summary>
        public decimal? LivePrice { get; set; }

        /// <summary>
        /// 是否限购
        /// </summary>
        public bool IsLimitBuy { get; set; }

        /// <summary>
        /// 限购数量
        /// </summary>
        public int? LimitBuyQuantity { get; set; }

    

        /// <summary>
        /// 承诺
        /// </summary>
        [StringLength(150, ErrorMessage = "承诺最多{1}个字符")]
        public string Commitment { get; set; }

        /// <summary>
        /// 保障
        /// </summary>
        [StringLength(150, ErrorMessage = "保障最多{1}个字符")]
        public string Guarantee { get; set; }


        /// <summary>
        /// 预约须知
        /// </summary>
        [StringLength(500, ErrorMessage = "预约须知最多{1}个字符")]
        public string AppointmentNotice { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
