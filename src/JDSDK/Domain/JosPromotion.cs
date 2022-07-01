using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosPromotion:JdObject{
      [JsonProperty("vender_id")]
public 				long

                                                                                     venderId
 { get; set; }
      [JsonProperty("promo_id")]
public 				long

                                                                                     promoId
 { get; set; }
      [JsonProperty("promo_name")]
public 				string

                                                                                     promoName
 { get; set; }
      [JsonProperty("promo_type")]
public 				int

                                                                                     promoType
 { get; set; }
      [JsonProperty("favor_mode")]
public 				int

                                                                                     favorMode
 { get; set; }
      [JsonProperty("begin_time")]
public 				string

                                                                                     beginTime
 { get; set; }
      [JsonProperty("end_time")]
public 				string

                                                                                     endTime
 { get; set; }
      [JsonProperty("bound")]
public 				int

             bound
 { get; set; }
      [JsonProperty("member")]
public 				int

             member
 { get; set; }
      [JsonProperty("slogan")]
public 				string

             slogan
 { get; set; }
      [JsonProperty("comment")]
public 				string

             comment
 { get; set; }
      [JsonProperty("promo_status")]
public 				int

                                                                                     promoStatus
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("platform")]
public 				int

             platform
 { get; set; }
      [JsonProperty("link")]
public 				string

             link
 { get; set; }
      [JsonProperty("shop_member")]
public 				int

                                                                                     shopMember
 { get; set; }
      [JsonProperty("qq_member")]
public 				int

                                                                                     qqMember
 { get; set; }
      [JsonProperty("plus_member")]
public 				int

                                                                                     plusMember
 { get; set; }
      [JsonProperty("member_level_only")]
public 					bool

                                                                                                                     memberLevelOnly
 { get; set; }
      [JsonProperty("allow_others_operate")]
public 					bool

                                                                                                                     allowOthersOperate
 { get; set; }
      [JsonProperty("allow_others_check")]
public 					bool

                                                                                                                     allowOthersCheck
 { get; set; }
      [JsonProperty("allow_other_user_operate")]
public 					bool

                                                                                                                                                     allowOtherUserOperate
 { get; set; }
      [JsonProperty("allow_other_user_check")]
public 					bool

                                                                                                                                                     allowOtherUserCheck
 { get; set; }
      [JsonProperty("need_manual_check")]
public 					bool

                                                                                                                     needManualCheck
 { get; set; }
      [JsonProperty("allow_check")]
public 					bool

                                                                                     allowCheck
 { get; set; }
      [JsonProperty("allow_operate")]
public 					bool

                                                                                     allowOperate
 { get; set; }
      [JsonProperty("is_jingdou_required")]
public 					bool

                                                                                                                     isJingdouRequired
 { get; set; }
      [JsonProperty("freq_bound")]
public 				int

                                                                                     freqBound
 { get; set; }
      [JsonProperty("per_max_num")]
public 				int

                                                                                                                     perMaxNum
 { get; set; }
      [JsonProperty("per_min_num")]
public 				int

                                                                                                                     perMinNum
 { get; set; }
      [JsonProperty("prop_type")]
public 				int

                                                                                     propType
 { get; set; }
      [JsonProperty("prop_num")]
public 				int

                                                                                     propNum
 { get; set; }
      [JsonProperty("prop_used_way")]
public 				int

                                                                                                                     propUsedWay
 { get; set; }
      [JsonProperty("coupon_id")]
public 				int

                                                                                     couponId
 { get; set; }
      [JsonProperty("coupon_batch_key")]
public 				string

                                                                                                                     couponBatchKey
 { get; set; }
      [JsonProperty("coupon_valid_days")]
public 				int

                                                                                                                     couponValidDays
 { get; set; }
      [JsonProperty("quota")]
public 				string

             quota
 { get; set; }
      [JsonProperty("rate")]
public 				string

             rate
 { get; set; }
      [JsonProperty("plus")]
public 				string

             plus
 { get; set; }
      [JsonProperty("order_mode_desc")]
public 				string

                                                                                                                     orderModeDesc
 { get; set; }
      [JsonProperty("token_use_num")]
public 				int

                                                                                                                     tokenUseNum
 { get; set; }
      [JsonProperty("user_pins")]
public 				string

                                                                                     userPins
 { get; set; }
      [JsonProperty("promo_area_type")]
public 				int

                                                                                                                     promoAreaType
 { get; set; }
      [JsonProperty("promo_areas")]
public 				string

                                                                                     promoAreas
 { get; set; }
	}
}
