using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalInfo
{
   public class AddHospitalInfoDto
    {
        public string Name { get; set; }
        public string SimpleName { get; set; }
        public int Sort { get; set; }
        public string ThumbPicUrl { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        public string Phone { get; set; }


        /// <summary>
        /// 标签编号数组
        /// </summary>
        public int[] TagIds { get; set; }

        public int? CityId { get; set; }


        /// <summary>
        /// 营业时间
        /// </summary>
        public string BusinessHours { get; set; }
        /// <summary>
        /// 合同到期日期
        /// </summary>
        public DateTime? DueTime { get; set; }
        /// <summary>
        /// 合同地址
        /// </summary>
        public string ContractUrl { get; set; }
        /// <summary>
        /// 归属公司
        /// </summary>
        public string BelongCompany { get; set; }
        /// <summary>
        /// 是否在小程序展示
        /// </summary>
        public bool IsShareInMiniProgram { get; set; }

        /// <summary>
        /// 派单顺序
        /// </summary>
        public int? SendOrder { get; set; }
        /// <summary>
        /// 新诊佣金比例
        /// </summary>
        public decimal? NewCustomerCommissionRatio { get; set; }
        /// <summary>
        /// 复诊佣金比例
        /// </summary>
        public decimal? OldCustomerCommissionRatio { get; set; }
        /// <summary>
        /// 重单规则
        /// </summary>
        public string RepeatOrderRule { get; set; }
        /// <summary>
        /// 年服务费缴纳状态
        /// </summary>
        public int? YearServiceFee { get; set; }
        
        /// <summary>
        /// 保证金缴纳状态
        /// </summary>
        public int? SecurityDeposit { get; set; }
        /// <summary>
        /// 年服务费金额
        /// </summary>
        public decimal YearServiceMoney { get; set; }
        /// <summary>
        /// 保证金金额
        /// </summary>
        public decimal SecurityDepositMoney { get; set; }

    }
}
