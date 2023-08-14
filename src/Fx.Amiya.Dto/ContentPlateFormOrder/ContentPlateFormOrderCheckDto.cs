using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class ContentPlateFormOrderCheckDto
    {
        /// <summary>
        /// 内容平台订单编号id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 成交情况id
        /// </summary>
        public string OrderDealInfoId { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int CheckState { get; set; }
        /// <summary>
        /// 审核金额
        /// </summary>

        public decimal CheckPrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>

        public decimal SettlePrice { get; set; }
        /// <summary>
        /// 审核客服结算金额
        /// </summary>

        public decimal? CustomerServiceSettlePrice { get; set; }

        /// <summary>
        /// 信息服务费
        /// </summary>
        public decimal InformationPrice { get; set; }
        /// <summary>
        /// 系统使用费
        /// </summary>
        public decimal SystemUpdatePrice { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        public int employeeId { get; set; }
        /// <summary>
        /// 审核信息
        /// </summary>
        public string CheckRemark { get; set; }

        /// <summary>
        /// 审核图片
        /// </summary>
        public List<string> CheckPicture { get; set; }
        /// <summary>
        /// 对账单id
        /// </summary>
        public string ReconciliationDocumentsId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

    }
}
