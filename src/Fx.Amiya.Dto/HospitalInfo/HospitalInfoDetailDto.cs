using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalInfo
{
   public class HospitalInfoDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SimpleName { get; set; }
        public int Sort { get; set; }
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
        public string ThumbPicUrl { get; set; }

        public string Address { get; set; }
        public DateTime? HospitalCreateDate { get; set; }

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

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 推荐排名
        /// </summary>
        public int? RecommendIndex { get; set; }

        public int? CityId { get; set; }
        public string City { get; set; }
        public DateTime? DueTime { get; set; }
        public string ContractUrl { get; set; }
        public string DescriptionPicture { get; set; }

        /// <summary>
        /// 获得行业荣誉
        /// </summary>
        public string IndustryHonors { get; set; }
        /// <summary>
        /// 当地知名度排名情况
        /// </summary>
        public string ProfileRank { get; set; }
        /// <summary>
        /// 营业时间
        /// </summary>
        public string BusinessHours { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public decimal? Area { get; set; }
        /// <summary>
        /// 医院简介
        /// </summary>

        public string Description { get; set; }

        /// <summary>
        /// 审核状态（0-未审核；1-：审核不通过；2-审核通过）
        /// </summary>
        public int CheckState { get; set; }

        /// <summary>
        /// 审核状态文本
        /// </summary>
        public string CheckStateText { get; set; }

        /// <summary>
        /// 审核人id
        /// </summary>
        public int? CheckBy { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string CheckEmpName { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }

        /// <summary>
        /// 提交状态（0-未提交；1-已提交）
        /// </summary>
        public int SubmitState { get; set; }

        /// <summary>
        /// 提交状态文本
        /// </summary>
        public string SubmitStateText { get; set; }
        /// <summary>
        /// 归属公司
        /// </summary>
        public string BelongCompany { get; set; }
        /// <summary>
        /// 是否在小程序展示
        /// </summary>
        public bool IsShareInMiniProgram { get; set; }

        public List<HospitalTagNameDto> ScaleTagList { get; set; }
        public List<HospitalTagNameDto> FacilityTagList { get; set; }
    }
}
