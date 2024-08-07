using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ItemInfo
{
    public class ItemInfoVo
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 其他平台商品编号
        /// </summary>
        public string OtherAppItemId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; } 

        /// <summary>
        /// 部位
        /// </summary>
        public string Parts { get; set; }
        /// <summary>
        /// 渠道
        /// </summary>
        public string AppType { get; set; }
        /// <summary>
        /// 渠道名称
        /// </summary>
        public string AppTypeText { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// 品类id
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 品类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 品项id
        /// </summary>
        public string ItemDetailsId { get; set; }
        /// <summary>
        /// 品项名称
        /// </summary>
        public string ItemDetailsName { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal? SalePrice { get; set; }

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
        public string Commitment { get; set; }

        /// <summary>
        /// 保障
        /// </summary>
        public string Guarantee { get; set; }

        /// <summary>
        /// 预约须知
        /// </summary>
        public string AppointmentNotice { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Valid { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 讲解次数
        /// </summary>
        public int ExplainTimes { get; set; }
        /// <summary>
        /// 首次上架时间
        /// </summary>
        public DateTime? FirstTimeOnSell { get; set; }
        /// <summary>
        /// 是否是新品
        /// </summary>
        public bool IsNewGoods { get; set; }
    }
}
