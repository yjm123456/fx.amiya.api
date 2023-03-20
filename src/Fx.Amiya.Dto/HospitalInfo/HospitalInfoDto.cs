using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalInfo
{
    public class HospitalInfoDto
    {
        public int Id { get; set; }
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

        public bool Valid { get; set; }

        public int CreateBy { get; set; }
        public string CreateName { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        public int CitySort { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        public string BusinessHours { get; set; }
        public DateTime? DueTime { get; set; }

        /// <summary>
        /// 可用日期
        /// </summary>
        public string HasUsedTime { get; set; }
        public string ContractUrl { get; set; }
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
        /// 派单栓徐文本
        /// </summary>
        public string SendOrderText { get; set; }
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
        /// 年服务费缴纳状态
        /// </summary>
        public string YearServiceFeeText { get; set; }
        /// <summary>
        /// 保证金缴纳状态
        /// </summary>
        public int? SecurityDeposit { get; set; }
        /// <summary>
        /// 保证金缴纳状态
        /// </summary>
        public string SecurityDepositText { get; set; }
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
