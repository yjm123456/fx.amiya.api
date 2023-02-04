using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.UnCheckOrder
{
    public class UpdateUnCheckOrderDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 信息服务费比例
        /// </summary>
        public decimal InformationPricePercent { get; set; }
        /// <summary>
        /// 系统使用费比例
        /// </summary>
        public decimal SystemUpdatePercent { get; set; }
        /// <summary>
        /// 信息服务费(计算获取)
        /// </summary>
        public decimal InformationPrice { get; set; }
        /// <summary>
        /// 系统使用费(计算获取)
        /// </summary>
        public decimal SystemUpdatePrice { get; set; }
        /// <summary>
        /// 结算金额(计算获取)
        /// </summary>
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 是否上传对账单
        /// </summary>
        public bool IsSubmitReconciliationDocuments { get; set; }
    }
}
