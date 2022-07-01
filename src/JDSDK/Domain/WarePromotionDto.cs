using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WarePromotionDto:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("ware_id")]
public 				long

                                                                                     wareId
 { get; set; }
      [JsonProperty("ware_name")]
public 				string

                                                                                     wareName
 { get; set; }
      [JsonProperty("promotion_name")]
public 				string

                                                                                     promotionName
 { get; set; }
      [JsonProperty("channels")]
public 				string

             channels
 { get; set; }
      [JsonProperty("fixed_price")]
public 					string

                                                                                     fixedPrice
 { get; set; }
      [JsonProperty("prom_advice_word")]
public 				string

                                                                                                                     promAdviceWord
 { get; set; }
      [JsonProperty("act_link_name")]
public 				string

                                                                                                                     actLinkName
 { get; set; }
      [JsonProperty("act_link_url")]
public 				string

                                                                                                                     actLinkUrl
 { get; set; }
      [JsonProperty("start_time")]
public 				DateTime

                                                                                     startTime
 { get; set; }
      [JsonProperty("end_time")]
public 				DateTime

                                                                                     endTime
 { get; set; }
      [JsonProperty("limit_num")]
public 				int

                                                                                     limitNum
 { get; set; }
      [JsonProperty("rebate_file")]
public 				string

                                                                                     rebateFile
 { get; set; }
      [JsonProperty("jd_price")]
public 					string

                                                                                     jdPrice
 { get; set; }
      [JsonProperty("down_discount")]
public 					string

                                                                                     downDiscount
 { get; set; }
      [JsonProperty("cbj_price")]
public 					string

                                                                                     cbjPrice
 { get; set; }
      [JsonProperty("discount_amount")]
public 					string

                                                                                     discountAmount
 { get; set; }
      [JsonProperty("grossmargin")]
public 					string

             grossmargin
 { get; set; }
      [JsonProperty("error_message")]
public 				string

                                                                                     errorMessage
 { get; set; }
      [JsonProperty("over_lying_suit")]
public 				int

                                                                                                                     overLyingSuit
 { get; set; }
      [JsonProperty("sale_mode")]
public 				int

                                                                                     saleMode
 { get; set; }
	}
}
