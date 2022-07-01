using Fx.Amiya.Dto.GoodsDemand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalInfo
{
    public class AddHospitalBrandApplyDto
    {
        public string HospitalName { get; set; }
        public string GoodsId { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string GoodsType { get; set; }

        public string GoodsUrl { get; set; }
        /// <summary>
        /// 预估销量
        /// </summary>
        public int? AllSaleNum { get; set; }

        /// <summary>
        /// 超出预估销量原因
        /// </summary>
        public string ExceededReason { get; set; }


        public List<AddTmallGoodsSkuDto> TmallGoodsSkuDto { get; set; }
    }
}
