using Fx.Amiya.DbModels.DBModelConfigs;
using Fx.Amiya.DbModels.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels
{
    public class AmiyaDbContext : DbContext
    {
        public AmiyaDbContext(DbContextOptions<AmiyaDbContext> options) : base(options)
        {

        }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<WxMiniUserInfo> WxMiniUserInfo { get; set; }
        public virtual DbSet<AmiyaWareHouse> AmiyaWareHouse { get; set; }
        public virtual DbSet<ShootingAndClip> ShootingAndClip { get; set; }
        public virtual DbSet<AmiyaLessonApply> AmiyaLessonApply { get; set; }
        public virtual DbSet<AmiyaInWarehouse> AmiyaInWarehouse { get; set; }
        public virtual DbSet<GreatHospitalDataWrite> GreatHospitalDataWrite { get; set; }
        public virtual DbSet<CustomerTagInfo> CustomerTagInfo { get; set; }
        public virtual DbSet<HospitalNetWorkConsulationOperationData> HospitalNetWorkConsulationOperationData { get; set; }
        public virtual DbSet<HospitalConsulationOperationData> HospitalConsulationOperationData { get; set; }
        public virtual DbSet<AmiyaOutWarehouse> AmiyaOutWarehouse { get; set; }
        public virtual DbSet<LiveAnchorBaseInfo> LiveAnchorBaseInfo { get; set; }
        public virtual DbSet<LiveAnchorWeChatInfo> LiveAnchorWeChatInfo { get; set; }
        public virtual DbSet<AmiyaWareHouseNameManage> AmiyaWareHouseNameManage { get; set; }
        public virtual DbSet<DockingHospitalCustomerInfo> DockingHospitalCustomerInfo { get; set; }
        public virtual DbSet<GreatHospitalOperationHealth> GreatHospitalOperationHealth { get; set; }
        public virtual DbSet<HospitalOperationData> HospitalOperationData { get; set; }
        public virtual DbSet<BeforeLivingTikTokDailyTarget> BeforeLivingTikTokDailyTraget { get; set; }
        public virtual DbSet<BeforeLivingXiaoHongShuDailyTarget> BeforeLivingXiaoHongShuDailyTraget { get; set; }
        public virtual DbSet<BeforeLivingZhiHuDailyTarget> BeforeLivingZhiHuDailyTraget { get; set; }
        public virtual DbSet<BeforeLivingVideoDailyTarget> BeforeLivingVideoDailyTraget { get; set; }
        public virtual DbSet<BeforeLivingSinaWeiBoDailyTarget> BeforeLivingSinaWeiBoDailyTraget { get; set; }
        public virtual DbSet<LivingDailyTarget> LivingDailyTarget { get; set; }
        public virtual DbSet<AfterLivingDailyTarget> AfterLivingDailyTarget { get; set; }
        public virtual DbSet<WxMpUserInfo> WxMpUserInfo { get; set; }
        public virtual DbSet<HospitalFeedBack> HospitalFeedBack { get; set; }
        public virtual DbSet<CustomerConsumptionCredentials> CustomerConsumptionCredentials { get; set; }
        public virtual DbSet<InventoryList> InventoryList { get; set; }
        public virtual DbSet<CustomerIntegralOrderRefund> CustomerIntegralOrderRefund { get; set; }
        public virtual DbSet<MpUserSubscribeDetail> MpUserSubscribeDetail { get; set; }
        public virtual DbSet<HospitalInfo> HospitalInfo { get; set; }
        public virtual DbSet<TrackReported> TrackReported { get; set; }
        public virtual DbSet<HospitalAppointmentNumer> HospitalAppointmentNumer { get; set; }
        public virtual DbSet<TagInfo> TagInfo { get; set; }
        public virtual DbSet<HospitalTagDetail> HospitalTagDetail { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<AmiyaEmployee> AmiyaEmployee { get; set; }
        public virtual DbSet<HospitalEnvironment> HospitalEnvironment { get; set; }
        public virtual DbSet<HospitalBrandApply> HospitalBrandApply { get; set; }
        public virtual DbSet<TmallGoodsSku> TmallGoodsSku { get; set; }
        public virtual DbSet<OrderCheckPicture> OrderCheckPicture { get; set; }
        public virtual DbSet<ConsumptionLevel> ConsumptionLevel { get; set; }
        public virtual DbSet<AmiyaPositionInfo> AmiyaPositionInfo { get; set; }
        public virtual DbSet<HospitalEmployee> HospitalEmployee { get; set; }
        public virtual DbSet<GoodsShopCar> GoodsShopCar { get; set; }
        public virtual DbSet<GoodsHospitalPrice> GoodsHospitalPrices { get; set; }
        public virtual DbSet<HospitalPositionInfo> HospitalPositionInfo { get; set; }
        public virtual DbSet<ItemInfo> ItemInfo { get; set; }
        public virtual DbSet<HomepageCarouselImage> HomepageCarouselImage { get; set; }
        public virtual DbSet<AppointmentInfo> AppointmentInfo { get; set; }
        public virtual DbSet<ValidateCode> ValidateCode { get; set; }
        public virtual DbSet<RecommendHospitalInfo> RecommendHospitalInfo { get; set; }
        public virtual DbSet<LiveAnchorMonthlyTarget> LiveAnchorMonthlyTarget { get; set; }
        public virtual DbSet<AfterLiveAnchorDailyTarget> LiveAnchorDailyTarget { get; set; }
        public virtual DbSet<ModuleCategory> ModuleCategory { get; set; }
        public virtual DbSet<HospitalDoctorOperationData> HospitalDoctorOperationData { get; set; }
        public virtual DbSet<BeautyDiaryTagInfo> BeautyDiaryTagInfo { get; set; }
        public virtual DbSet<BeautyDiaryTagDetail> BeautyDiaryTagDetail { get; set; }
        public virtual DbSet<BeautyDiaryBannerImage> BeautyDiaryBannerImage { get; set; }
        public virtual DbSet<BeautyDiaryManage> BeautyDiaryManage { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<AmiyaPositionDefaultRoute> AmiyaPositionDefaultRoute { get; set; }
        public virtual DbSet<AmiyaPositionModulePermission> AmiyaPositionModulePermission { get; set; }
        public virtual DbSet<HospitalPositionDefaultRoute> HospitalPositionDefaultRoute { get; set; }
        public virtual DbSet<ContentPlatFormCustomerPicture> ContentPlatFormCustomerPicture { get; set; }
        public virtual DbSet<HospitalPositionModulePermission> HospitalPositionModulePermission { get; set; }
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<WxAppInfo> WxAppInfo { get; set; }
        public virtual DbSet<WxEventResponseSetting> WxEventResponseSetting { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<CooperativeHospitalCity> CooperativeHospitalCity { get; set; }
        public virtual DbSet<AmiyaHospitalDepartment> AmiyaHospitalDepartment { get; set; }
        public virtual DbSet<PermissionInfo> PermissionInfo { get; set; }
        public virtual DbSet<ShoppingCartRegistration> ShoppingCartRegistration { get; set; }
        public virtual DbSet<AmiyaPositionPermission> AmiyaPositionPermission { get; set; }
        public virtual DbSet<ContentPlatformOrderDealInfo> ContentPlatformOrderDealInfo { get; set; }
        public virtual DbSet<HospitalSurplusAppointment> HospitalSurplusAppointment { get; set; }
        public virtual DbSet<SendOrderUpdateRecord> SendOrderUpdateRecord { get; set; }
        public virtual DbSet<ActivityInfo> ActivityInfo { get; set; }
        public virtual DbSet<ActivityItemDetail> ActivityItemDetail { get; set; }
        public virtual DbSet<HospitalPartakeItem> HospitalQuotedPriceItemInfo { get; set; }
        public virtual DbSet<HospitalCheckPhoneRecord> HospitalCheckPhoneRecord { get; set; }
        public virtual DbSet<BindCustomerService> BindCustomerService { get; set; }
        public virtual DbSet<SendOrderInfo> SendOrderInfo { get; set; }
        public virtual DbSet<GiftInfo> GiftInfo { get; set; }
        public virtual DbSet<OrderAppInfo> TaobaoAppInfo { get; set; }
        public virtual DbSet<OrderWriteOffInfo> OrderWriteOffInfo { get; set; }
        public virtual DbSet<ReceiveGift> ReceiveGift { get; set; }
        public virtual DbSet<LeaveMessage> LeaveMessage { get; set; }
        public virtual DbSet<TrackType> TrackType { get; set; }
        public virtual DbSet<TrackTool> TrackTool { get; set; }
        public virtual DbSet<TrackTheme> TrackTheme { get; set; }
        public virtual DbSet<TrackTypeThemeModel> TrackTypeThemeModel { get; set; }
        public virtual DbSet<TrackRecord> TrackRecord { get; set; }
        public virtual DbSet<WaitTrackCustomer> WaitTrackCustomer { get; set; }
        public virtual DbSet<Initializer> OrderInitializer { get; set; }
        public virtual DbSet<LiveType> LiveType { get; set; }
        public virtual DbSet<RequirementType> RequirementType { get; set; }
        public virtual DbSet<GoodsInfo> GoodsInfo { get; set; }
        public virtual DbSet<AmiyaDepartment> AmiyaDepartment { get; set; }
        public virtual DbSet<LiveRequirementInfo> LiveRequirementInfo { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<CustomerBaseInfo> CustomerBaseInfo { get; set; }
        public virtual DbSet<CustomerHospitalConsume> CustomerHospitalConsume { get; set; }
        public virtual DbSet<Contentplatform> Contentplatform { get; set; }
        public virtual DbSet<LiveAnchor> LiveAnchor { get; set; }
        public virtual DbSet<UserInfoUpdateRecord> UserInfoUpdateRecord { get; set; }
        public virtual DbSet<OrderTrade> OrderTrade { get; set; }
        public virtual DbSet<HospitalEnvironmentPicture> HospitalEnvironmentPicture { get; set; }
        public virtual DbSet<SendGoodsRecord> SendGoodsRecord { get; set; }
        public virtual DbSet<SendOrderMessageBoard> SendOrderMessageBoard { get; set; }
        public virtual DbSet<ContentPlatformOrder> ContentPlatformOrder { get; set; }
        public virtual DbSet<ContentPlatformOrderSend> ContentPlatformOrderSend { get; set; }
        public virtual DbSet<TikTokOrderInfo> TikTokOrderInfo { get; set; }
        public virtual DbSet<TikTokUserInfo> TikTokUserInfo { get; set; }

        public virtual DbSet<GrowthPointsAccount> GrowthPointsAccount { get; set; }
        public virtual DbSet<GrowthPointsRecord> GrowthPointsRecord { get; set; }
        public virtual DbSet<ConsumptionVoucher> ConsumptionVoucher { get; set; }
        public virtual DbSet<CustomerConsumptionVoucher> CustomerConsumptionVoucher { get; set; }
        public virtual DbSet<GoodsMemberRankPrice> GoodsMemberRankPrice { get; set; }
        public virtual DbSet<MemberCardRankInfo> MemberCard { get; set; }
        public virtual DbSet<MemberCardSendRecord> MemberCardSendRecord { get; set; }
        public virtual DbSet<MemberCardHandle> MemberCardHandle { get; set; }
        public virtual DbSet<BalanceAccount> BalanceAccounts { get; set; }
        public virtual DbSet<BalanceRechargeRecord> BalanceRechargeRecords { get; set; }
        public virtual DbSet<BalanceUseRecord> BalanceUseRecords { get; set; }
        public virtual DbSet<RechargeRewardRule> RechargeRewardRules { get; set; }
        public virtual DbSet<RechargeAmount> RechargeAmounts { get; set; }
        public virtual DbSet<GrowthPointsRule> GrowthPointsRules { get; set; }
        public virtual DbSet<GoodsConsumptionVoucher> GoodsConsumptionVouchers { get; set; }
        public virtual DbSet<HospitalOperationalIndicator> HospitalOperationalIndicator { get; set; }
        public virtual DbSet<IndicatorSendHospital> IndicatorSendHospital { get; set; }
        public virtual DbSet<ExcellentHospitalOperationsbeRemark> ExcellentHospitalOperationsbeRemark { get; set; }
        public virtual DbSet<Remark> Remark { get; set; }
        public virtual DbSet<HospitalDealItem> HospitalDealItem { get; set; }
        public virtual DbSet<HospitalImprovePlanRemark> HospitalImprovePlanRemark { get; set; }
        public virtual DbSet<OrderRefund> OrderRefund { get; set; }
        public virtual DbSet<DiaryWechat> DiaryWechats { get; set; }
        public virtual DbSet<IndicatorOrderData> IndicatorOrderDatas { get; set; }
        public virtual DbSet<ImprovePlanAndRemark> ImprovePlanAndRemarks { get; set; }
        public virtual DbSet<AmiyaRemark> AmiyaRemarks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WxMiniUserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerInfoConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaEmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ConsumptionLevelConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerTagInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ContentPlatFormCustomerPictureConfiguration());
            modelBuilder.ApplyConfiguration(new DockingHospitalCustomerInfoConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalFeedBackConfiguration());
            modelBuilder.ApplyConfiguration(new GreatHospitalDataWriteConfiguration());
            modelBuilder.ApplyConfiguration(new LiveAnchorBaseInfoConfiguration());
            modelBuilder.ApplyConfiguration(new LiveAnchorWechatInfoConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaWareHouseConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaInWarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaOutWarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaWareHouseNameManageConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalNetWorkConsulationOperationDataConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeBindLiveAnchorConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryListConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartRegistrationConfiguration());
            modelBuilder.ApplyConfiguration(new LiveAnchorMonthlyTargetConfiguration());
            modelBuilder.ApplyConfiguration(new TrackReportedConfiguration());
            modelBuilder.ApplyConfiguration(new LiveAnchorDailyTargetConfiguration());
            modelBuilder.ApplyConfiguration(new OrderCheckPictureConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaGoodsDemandConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaHospitalDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaPositionInfoConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalPositionInfoConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalEmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new BeautyDiaryTagInfoConfiguration());
            modelBuilder.ApplyConfiguration(new BeautyDiaryTagDetailConfiguration());
            modelBuilder.ApplyConfiguration(new BeautyDiaryBannerImageConfiguration());
            modelBuilder.ApplyConfiguration(new BeautyDiaryManageConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsInfoConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalInfoConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalEnvironmentConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalEnvironmentPictureConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new ExpressConfiguration());
            modelBuilder.ApplyConfiguration(new TagInfoConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalTagDetailConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsShopCarConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsHospitalPriceConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalAppointmentNumerConfiguration());
            modelBuilder.ApplyConfiguration(new TmallGoodsSkuConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalBrandApplyConfiguration());
            modelBuilder.ApplyConfiguration(new ItemInfoConfiguration());
            modelBuilder.ApplyConfiguration(new HomepageCarouselImageConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ValidateCodeConfiguration());
            modelBuilder.ApplyConfiguration(new RecommendHospitalInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerIntegralOrderRefundConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaPositionDefaultRouteConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalConsulationOperationDataConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaPositionModulePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new ShootingAndClipConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalPositionDefaultRouteConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalPositionModulePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalOperationDataConfiguration());
            modelBuilder.ApplyConfiguration(new ContentPlatFormOrderDealInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ConfigConfiguration());
            modelBuilder.ApplyConfiguration(new WxAppInfoConfiguration());
            modelBuilder.ApplyConfiguration(new WxMpUserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new MpUserSubscribeDetailConfiguration());
            modelBuilder.ApplyConfiguration(new WxEventResponseSettingConfiguration());
            modelBuilder.ApplyConfiguration(new OrderInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CooperativeHospitalCityConfiguration());
            modelBuilder.ApplyConfiguration(new ContentplatformConfiguration());
            modelBuilder.ApplyConfiguration(new BeforeLivingTikTokDailyTragetConfiguration());
            modelBuilder.ApplyConfiguration(new BeforeLivingXiaoHongShuDailyTragetConfiguration());
            modelBuilder.ApplyConfiguration(new BeforeLivingZhiHuDailyTargetConfiguration());
            modelBuilder.ApplyConfiguration(new BeforeLivingVideoDailyTargetConfiguration());
            modelBuilder.ApplyConfiguration(new BeforeLivingSinaWeiBoDailyTargetConfiguration());
            modelBuilder.ApplyConfiguration(new LivingDailyTargetConfiguration());
            modelBuilder.ApplyConfiguration(new AfterLivingDailyTargetConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionInfoConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaPositionPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalSurplusAppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new SendOrderUpdateRecordConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityItemDetailConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalPartakeItemConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalCheckPhoneRecordConfiguration());
            modelBuilder.ApplyConfiguration(new BindCustomerServiceConfiguration());
            modelBuilder.ApplyConfiguration(new BeautyDiaryTagInfoConfiguration());

            modelBuilder.ApplyConfiguration(new BeautyDiaryBannerImageConfiguration());
            modelBuilder.ApplyConfiguration(new BeautyDiaryManageConfiguration());
            modelBuilder.ApplyConfiguration(new BeautyDiaryTagDetailConfiguration());
            modelBuilder.ApplyConfiguration(new NoticeConfigConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConsumptionCredentialsConfiguration());
            modelBuilder.ApplyConfiguration(new SendOrderInfoConfiguration());
            modelBuilder.ApplyConfiguration(new GiftInfoConfiguration());
            modelBuilder.ApplyConfiguration(new OrderAppInfoConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaLessonApplyConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiveGiftConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveMessageConfiguration());
            modelBuilder.ApplyConfiguration(new TrackTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TrackToolConfiguration());
            modelBuilder.ApplyConfiguration(new TrackThemeConfiguration());
            modelBuilder.ApplyConfiguration(new TrackRecordConfiguration());
            modelBuilder.ApplyConfiguration(new WaitTrackCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TrackTypeThemeModelConfiguration());
            modelBuilder.ApplyConfiguration(new OrderInitializerConfiguration());
            modelBuilder.ApplyConfiguration(new LiveTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RequirementTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalDoctorOperationDataConfiguration());
            modelBuilder.ApplyConfiguration(new LiveRequirementInfoConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerBaseInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerHospitalConsumeConfiguration());
            modelBuilder.ApplyConfiguration(new LiveAnchorConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoUpdateRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTradeConfiguration());
            modelBuilder.ApplyConfiguration(new SendGoodsRecordConfiguration());
            modelBuilder.ApplyConfiguration(new SendOrderMessageBoardConfiguration());
            modelBuilder.ApplyConfiguration(new OrderWriteOffInfoConfiguration());
            modelBuilder.ApplyConfiguration(new ContentPlatformOrderConfiguration());
            modelBuilder.ApplyConfiguration(new ContentPlatformOrderSendConfiguration());
            modelBuilder.ApplyConfiguration(new TikTokOrderInfoConfiguration());
            modelBuilder.ApplyConfiguration(new TikTokUserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new GrowthPointsAccountConfiguration());
            modelBuilder.ApplyConfiguration(new GrowthPointsRecordConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConsumptionVoucherConfiguration());
            modelBuilder.ApplyConfiguration(new GreatHospitalOperationHealthConfiguration());
            modelBuilder.ApplyConfiguration(new ConsumptionVoucherConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsMemberRankPriceConfiguration());
            modelBuilder.ApplyConfiguration(new MemberCardRankInfoConfiguration());
            modelBuilder.ApplyConfiguration(new MemberCardHandleConfiguration());
            modelBuilder.ApplyConfiguration(new MemberCardSendRecordConfiguration());
            modelBuilder.ApplyConfiguration(new BalanceAccountConfiguration());
            modelBuilder.ApplyConfiguration(new BalanceRechargeRecordConfiguration());
            modelBuilder.ApplyConfiguration(new BalanceUseRecordConfiguration());
            modelBuilder.ApplyConfiguration(new RechargeRewardRuleConfiguration());
            modelBuilder.ApplyConfiguration(new RechargeAmountConfiguration());
            modelBuilder.ApplyConfiguration(new GrowthpointsRuleConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsConsumptionVoucherConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalOperationalIndicatorConfiguration());
            modelBuilder.ApplyConfiguration(new IndicatorSendHospitalConfiguration());
            modelBuilder.ApplyConfiguration(new ExcellentHospitalOperationsbeRemarkConfiguration());
            modelBuilder.ApplyConfiguration(new RemarkConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalImprovePlanRemarkConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalDealItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderRefundConfiguration());
            modelBuilder.ApplyConfiguration(new DiaryWechatConfiguration());
            modelBuilder.ApplyConfiguration(new IndicatorOrderDataConfiguration());
            modelBuilder.ApplyConfiguration(new ImprovePlanAndRemarkConfiguration());
            modelBuilder.ApplyConfiguration(new AmiyaRemarkConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
