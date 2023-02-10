using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class Bill:BaseDbModel
    {
        ///// <summary>
        ///// 编号
        ///// </summary>
        //public string Id { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 对账金额
        /// </summary>
        public decimal? DealPrice { get; set; }

        /// <summary>
        /// 信息服务费
        /// </summary>
        public decimal? InformationPrice { get; set; }

        /// <summary>
        /// 系统使用费
        /// </summary>
        public decimal? SystemUpdatePrice { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal BillPrice { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 税额（发票金额/（（1+税率）*税率）--保留2位小数）
        /// </summary>
        public decimal TaxPrice { get; set; }
        /// <summary>
        /// 不含税金额
        /// </summary>
        public decimal NotInTaxPrice { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal? OtherPrice { get; set; }
        /// <summary>
        /// 费用备注
        /// </summary>
        public string OtherPriceRemark { get; set; }
        /// <summary>
        /// 收款公司
        /// </summary>
        public string CollectionCompanyId { get; set; }
        /// <summary>
        /// 票据归属时间（起）
        /// </summary>
        public DateTime BelongStartTime { get; set; }
        /// <summary>
        /// 票据归属时间（止）
        /// </summary>
        public DateTime BelongEndTime { get; set; }
        /// <summary>
        /// 票据类型
        /// </summary>
        public int BillType { get; set; }
        /// <summary>
        /// 开票事由
        /// </summary>
        public string CreateBillReason { get; set; }
        /// <summary>
        /// 回款状态
        /// </summary>
        public int ReturnBackState { get; set; }
        /// <summary>
        /// 累计回款金额
        /// </summary>
        public decimal? ReturnBackPrice { get; set; }
        ///// <summary>
        ///// 开票时间
        ///// </summary>
        //public DateTime CreateDate { get; set; }
        /// <summary>
        /// 开票人
        /// </summary>
        public int CreateBy { get; set; }
        ///// <summary>
        ///// 更新时间
        ///// </summary>
        //public DateTime? UpdateDate { get; set; }
        ///// <summary>
        ///// 是否作废（正常，作废）
        ///// </summary>
        //public bool Valid { get; set; }
        ///// <summary>
        ///// 作废时间
        ///// </summary>
        //public DateTime? DeleteDate { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public CompanyBaseInfo CompanyBaseInfo { get; set; }

        public List<BillReturnBackPriceData> BillReturnBackPriceDataList { get; set; }
    }
}
