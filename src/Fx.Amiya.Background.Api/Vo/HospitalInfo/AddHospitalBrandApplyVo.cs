using Fx.Amiya.Background.Api.Vo.GoodsInfo;
using Fx.Amiya.Dto.GoodsDemand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalInfo
{
    /// <summary>
    /// 医院品牌报名新增
    /// </summary>
    public class AddHospitalBrandApplyInHospitalVo
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 医院品牌报名数据
        /// </summary>
        public List<AddHospitalBrandApplyVo> AddHospitalBrandApplyVo { get; set; }
    }
    /// <summary>
    /// 医院品牌报名数据
    /// </summary>
    public class AddHospitalBrandApplyVo
    {
        /// <summary>
        /// 商品Id（12位数字）
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string GoodsType { get; set; }

        /// <summary>
        /// 商品链接
        /// </summary>
        public string GoodsUrl { get; set; }

        /// <summary>
        /// 预估销量
        /// </summary>
        public int? AllSaleNum { get; set; }

        /// <summary>
        /// 超出预估销量原因
        /// </summary>
        public string ExceededReason { get; set; }

        /// <summary>
        /// SKU信息
        /// </summary>
        public List<AddTmallGoodsSkuVo> TmallGoodsSkuVo { get; set; }
    }
}
