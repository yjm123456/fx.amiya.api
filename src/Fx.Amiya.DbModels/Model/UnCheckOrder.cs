using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class UnCheckOrder : BaseDbModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int OrderFrom { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime DealDate { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal DealPrice { get; set; }
        /// <summary>
        /// 信息服务费比例
        /// </summary>
        public decimal InformationPricePercent { get; set; }
        /// <summary>
        /// 系统使用费比例
        /// </summary>
        public decimal SystemUpdatePercent { get; set; }
        /// <summary>
        /// 信息服务费
        /// </summary>
        public decimal InformationPrice { get; set; }
        /// <summary>
        /// 系统使用费
        /// </summary>
        public decimal SystemUpdatePrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 是否上传对账单
        /// </summary>
        public bool IsSubmitReconciliationDocuments { get; set; }
        /// <summary>
        /// 指派医院
        /// </summary>
        public int? SendHospital { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        public AmiyaEmployee UnCheckOrderCreateBy { get; set; }
    }
}
