using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Bill
{
    public class BillReturnBackPriceDataDto:BaseDto
    {

        /// <summary>
        /// 客户id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 客户名称（医院）
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 收款公司
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 收款公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 票据编号
        /// </summary>
        public string BillId { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal BillPrice { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal? OtherPrice { get; set; }
        /// <summary>
        /// 回款金额
        /// </summary>
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime ReturnBackDate { get; set; }
        /// <summary>
        /// 回款状态
        /// </summary>
        public int ReturnBackState { get; set; }

        /// <summary>
        /// 回款状态文本
        /// </summary>
        public string ReturnBackStateText { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 操作人名称
        /// </summary>
        public string CreateByEmployeeName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
