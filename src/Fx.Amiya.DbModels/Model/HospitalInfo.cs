﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 医院简称
        /// </summary>
        public string SimpleName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
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
        /// 年服务费
        /// </summary>
        public int? YearServiceFee { get; set; }
        /// <summary>
        /// 保证金
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
        /// <summary>
        /// 医院成立时间
        /// </summary>
        public DateTime? HospitalCreateTime { get; set; }
        public string Address { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Phone { get; set; }
        public bool Valid { get; set; }
        public string ThumbPicUrl { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? CityId { get; set; }

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
        /// 简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 审核状态（0-未审核；1-：审核不通过；2-审核通过）
        /// </summary>
        public int CheckState { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public int? CheckBy { get; set; }
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
        /// 所属公司
        /// </summary>
        public string BelongCompany { get; set; }

        /// <summary>
        /// 是否在小程序展示
        /// </summary>
        public bool IsShareInMiniProgram { get; set; }

        public AmiyaEmployee CreateByAmiyaEmployee { get; set; }
        public AmiyaEmployee UpdateByAmiyaEmployee { get; set; }
        public CooperativeHospitalCity CooperativeHospitalCity { get; set; }

        public List<Doctor> DocterList { get; set; }
        public List<HospitalEmployee> HospitalEmployeeList { get; set; }
        public List<HospitalTagDetail> HospitalTagDetailList { get; set; }
        public List<HospitalAppointmentNumer> HospitalAppointmentNumerList { get; set; }
        public List<AppointmentInfo> AppointmentInfoList { get; set; }
        public List<RecommendHospitalInfo> RecommendHospitalInfoList { get; set; }
        public List<HospitalSurplusAppointment> HospitalSurplusAppointmentList { get; set; }
        public List<SendOrderUpdateRecord> OldSendOrderUpdateRecordList { get; set; }
        public List<SendOrderUpdateRecord> NewSendOrderUpdateRecordList { get; set; }
        public List<HospitalPartakeItem> HospitalPartakeItemList { get; set; }
        public List<HospitalCheckPhoneRecord> HospitalCheckPhoneRecordList { get; set; }
        public List<SendOrderInfo> SendOrderInfoList { get; set; }
        public List<CustomerHospitalConsume> CustomerHospitalConsumeList { get; set; }
        public List<SendOrderMessageBoard> SendOrderMessageBoardList { get; set; }

        public List<ContentPlatformOrder> ContentPlatformOrderList { get; set; }
        public List<GoodsShopCar> GoodsShopCar { get; set; }

        public List<ReconciliationDocuments> ReconciliationDocumentsList { get; set; }
        public List<ContentPlatformOrderSend> ContentPlatformOrderSendList { get; set; }

        public List<DockingHospitalCustomerInfo> HospitalDockingHospitalCustomerInfo { get; set; }
        public List<IndicatorSendHospital> IndicatorSendHospitalList { get; set; }

        public List<GreatHospitalOperationHealth> GreatHospitalOperationHealthList { get; set; }

        public List<HospitalOperationData> HospitalOperationDataList { get; set; }

        public List<HospitalNetWorkConsulationOperationData> HospitalNetWorkConsulationOperationDataList { get; set; }

        public List<HospitalConsulationOperationData> HospitalConsulationOperationDataList { get; set; }

        public List<HospitalDoctorOperationData> HospitalDoctorOperationDataList { get; set; }
        public List<HospitalDealItem> HospitalDealItemList { get; set; }
        public List<HospitalImprovePlanRemark> HospitalImprovePlanRemarkList { get; set; }

        public List<Bill> BillList { get; set; }
        public List<BillReturnBackPriceData> BillReturnBackPriceDataList { get; set; }

        public List<ContentPlatFormOrderAddWork> ContentPlatFormOrderAddWork { get; set; }

        public List<CustomerHospitalDealInfo> CustomerHospitalDealInfoList { get; set; }
    }
}
