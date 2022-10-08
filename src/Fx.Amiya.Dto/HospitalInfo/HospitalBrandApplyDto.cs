using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalInfo
{
    public class HospitalBrandApplyDto
    {
        public string Id { get; set; }
        public string HospitalName { get; set; }

        /// <summary>
        /// 营业执照名称
        /// </summary>
        public string BusinessLicenseName { get; set; }

        /// <summary>
        /// 医院联系人
        /// </summary>
        public string HospitalLinkMan { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string HospitalLinkManPhone { get; set; }
        public string GoodsId { get; set; }
        public string GoodsType { get; set; }

        public string GoodsUrl { get; set; }
        public int? AllSaleNum { get; set; }

        /// <summary>
        /// 超出预估销量原因
        /// </summary>
        public string ExceededReason { get; set; }
    }
}
