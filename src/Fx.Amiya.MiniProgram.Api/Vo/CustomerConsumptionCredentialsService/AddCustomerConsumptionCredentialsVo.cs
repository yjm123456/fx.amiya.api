using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.CustomerConsumptionCredentialsService
{
    public class AddCustomerConsumptionCredentialsVo
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 留院电话
        /// </summary>
        public string ToHospitalPhone { get; set; }
        /// <summary>
        /// 归属主播id
        /// </summary>
        public string LiveAnchorBaseId { get; set; }
        /// <summary>
        /// 归属主播
        /// </summary>
        public string LiveAnchor { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>

        public DateTime ConsumeDate { get; set; }
        /// <summary>
        /// 消费凭证截图1
        /// </summary>

        public string PayVoucherPicture1 { get; set; }
        /// <summary>
        /// 消费凭证截图2
        /// </summary>
        public string PayVoucherPicture2 { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int CheckState { get; set; }
        /// <summary>
        /// 审核人id
        /// </summary>
        public int CheckBy { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string CheckByEmpname { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>

        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }
    }
}
