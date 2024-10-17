using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaEmployee
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Valid { get; set; }
        public int AmiyaPositionId { get; set; }
        public string Email { get; set; }
        public bool IsCustomerService { get; set; }

        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime? CodeExpireDate { get; set; }
        /// <summary>
        /// 有效新客提成
        /// </summary>
        public decimal? NewCustomerCommission { get; set; }
        /// <summary>
        /// 潜在新客提成
        /// </summary>
        public decimal? PotentialNewCustomerCommission { get; set; }
        /// <summary>
        /// 老客提成
        /// </summary>
        public decimal? OldCustomerCommission { get; set; }
        /// <summary>
        /// 财务参与稽查后提成
        /// </summary>
        public decimal? InspectionCommission { get; set; }
        /// <summary>
        /// 行政客服参与稽查后提成
        /// </summary>
        public decimal AdministrativeInspection { get; set; }
        /// <summary>
        /// 行政客服稽查提成比例
        /// </summary>
        public decimal AdministrativeInspectionCommission { get; set; }
        /// <summary>
        /// 达人新客提成比例
        /// </summary>
        public decimal CooperateLiveanchorNewCustomerCommission { get; set; }
        /// <summary>
        /// 达人老客提成比例
        /// </summary>
        public decimal CooperateLiveanchorOldCustomerCommission { get; set; }
        /// <summary>
        /// 天猫升单比例
        /// </summary>
        public decimal TmallOrderCommission { get; set; }

        public string LiveAnchorBaseId { get; set; }
        public AmiyaPositionInfo AmiyaPositionInfo { get; set; }
        public List<AmiyaPositionInfo> UpdateByAmiyaPositionInfoList { get; set; }

        public List<ItemInfo> CreateByItemInfoList { get; set; }
        public List<ItemInfo> UpdateByItemInfoList { get; set; }
        public List<RecommendHospitalInfo> CreateByRecommendHospitalInfoList { get; set; }
        public List<RecommendHospitalInfo> UpdateByRecommendHospitalInfoList { get; set; }
        public List<HospitalInfo> CreateByHospitalInfoList { get; set; }
        public List<HospitalInfo> UpdateByHospitalInfoList { get; set; }
        public List<HospitalPositionInfo> UpdateByHospitalPositionInfoList { get; set; }
        public List<SendOrderUpdateRecord> SendOrderUpdateRecordList { get; set; }
        public List<ActivityInfo> CreateByActivityInfoList { get; set; }
        public List<ActivityInfo> UpdateByActivityInfoList { get; set; }
        public List<BindCustomerService> CustoemrServiceBindCustomerServiceList { get; set; }
        public List<BindCustomerService> CreateByBindCustomerServiceList { get; set; }
        public List<SendOrderInfo> SendOrderInfoList { get; set; }
        public List<GiftInfo> CreateByGiftInfoList { get; set; }
        public List<GiftInfo> UpdateByGiftInfoList { get; set; }
        public List<ReceiveGift> ReceiveGiftList { get; set; }
        public List<TrackRecord> TrackRecordList { get; set; }
        public List<WaitTrackCustomer> CreateWaitTrackCustomerList { get; set; }
        public List<WaitTrackCustomer> PlanTrackWaitTrackCustomerList { get; set; }
        public List<LeaveMessage> LeaveMessageList { get; set; }
        public List<InventoryList> InventoryList { get; set; }
        public List<AmiyaOutWarehouse> AmiyaOutWarehouse { get; set; }
        public List<AmiyaOutWarehouse> AmiyaOutWarehouseUsing { get; set; }
        public List<AmiyaInWarehouse> AmiyaInWarehouse { get; set; }
        public List<LiveRequirementInfo> CreateLiveRequirementInfoList { get; set; }
        public List<LiveRequirementInfo> ResponseLiveRequirementInfoList { get; set; }
        public List<LiveRequirementInfo> DecideLiveRequirementInfoList { get; set; }
        public List<LiveRequirementInfo> ExecuteLiveRequirementInfoList { get; set; }
        public List<SendGoodsRecord> SendGoodsRecordList { get; set; }
        public List<SendOrderMessageBoard> SendOrderMessageBoardList { get; set; }
        public List<ContentPlatformOrderSend> ContentPlatformOrderSendList { get; set; }
        public List<ShoppingCartRegistration> ShoppingCartRegistrationList { get; set; }

        public List<ShootingAndClip> ShootingInfo { get; set; }
        public List<ShootingAndClip> ClipInfo { get; set; }

        public List<BeforeLivingTikTokDailyTarget> beforeLivingTikTokDailyTragets { get; set; }
        public List<BeforeLivingXiaoHongShuDailyTarget> beforeLivingXiaoHongShuDailyTragets { get; set; }
        public List<BeforeLivingZhiHuDailyTarget> beforeLivingZhiHuDailyTraget { get; set; }
        public List<BeforeLivingVideoDailyTarget> beforeLivingVideoDailyTarget { get; set; }
        public List<BeforeLivingSinaWeiBoDailyTarget> beforeLivingSinaWeiBoDailyTarget { get; set; }
        public List<LivingDailyTarget> livingDailyTarget { get; set; }
        public List<AfterLivingDailyTarget> afterLivingDailyTarget { get; set; }
        public List<CustomerConsumptionCredentials> CustomerConsumptionCredentialsList { get; set; }
        public List<RecommandDocumentSettle> RecommandDocumentSettleList { get; set; }

        public List<UnCheckOrder> UnCheckOrderList { get; set; }

        public List<Bill> BillList { get; set; }

        public List<BillReturnBackPriceData> BillReturnBackPriceDataList { get; set; }

        public List<ContentPlatFormOrderAddWork> ContentPlatFormOrderAddWorkCreateBy { get; set; }
        public List<ContentPlatFormOrderAddWork> ContentPlatFormOrderAddWorkAcceptBy { get; set; }

        public List<CustomerAppointmentSchedule> CustomerAppointmentScheduleList { get; set; }
        public List<MessageNotice> MessageNoticeList { get; set; }
        public List<BindCustomerRFMLevelUpdateLog> BindCustomerRFMLevelUpdateLogList { get; set; }
        public List<AmiyaWareHouseStorageRacks> AmiyaWareHouseStorageRacks { get; set; }
        public List<LivingDailyTakeGoods> LivingDailyTakeGoodsList { get; set; }

        public List<CustomerServiceCompensation> CustomerServiceCompensationCreateByList { get; set; }
        public List<CustomerServiceCompensation> CustomerServiceCompensationBelongEmpList { get; set; }

        public List<EmployeePerformanceTarget> EmployeePerformanceTargetList { get; set; }
        public List<FansMeetingDetails> FansMeetingDetailsList { get; set; }

        public List<CustomerServiceCheckPerformance> CustomerServiceCheckPerformance { get; set; }

    }
}
