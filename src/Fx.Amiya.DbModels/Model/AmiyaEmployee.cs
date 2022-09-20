using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class AmiyaEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Valid { get; set; }
        public int AmiyaPositionId { get; set; }
        public string Email { get; set; }
        public bool IsCustomerService { get; set; }

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
    }
}
