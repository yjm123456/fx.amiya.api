using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerHospitalConsume
{
    public class ImportCustomerHospitalConsumeDto
    {
        public DateTime? CreateDate { get; set; }

        public int HospitalId { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
        public byte ConsumeType { get; set; } 
        /// <summary>
        /// 客服id
        /// </summary>
        public int? EmployeeId { get; set; }

        //--新增
        /// <summary>
        /// 客户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 人次
        /// </summary>
        public int PersonTime { get; set; }
        /// <summary>
        /// 是否携带订单
        /// </summary>
        public bool IsAddedOrder { get; set; }
        /// <summary>
        /// 订单号，多个请用逗号隔开
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 核销日期
        /// </summary>
        public DateTime? WriteOffDate { get; set; }
        /// <summary>
        /// 归属自播/外播
        /// </summary>
        public bool IsSelfLiving { get; set; }

        /// <summary>
        /// 升单日期
        /// </summary>
        public DateTime? BuyAgainTime { get; set; }

        /// <summary>
        /// 升单类型
        /// </summary>
        public int BuyAgainType { get; set; }

        /// <summary>
        /// 审核升单金额
        /// </summary>
        public decimal CheckBuyAgainPrice { get; set; }

        public decimal CheckSettlePrice { get; set; }

        public DateTime? CheckDate{ get; set; }
        /// <summary>
        /// 审核状态（0未审核，1审核不通过，2审核通过）
        /// </summary>
        public int CheckState { get; set; } = 2;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
