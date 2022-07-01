using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PromotionVO:JdObject{
      [JsonProperty("promo_id")]
public 				long

                                                                                     promoId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("bound")]
public 				int

             bound
 { get; set; }
      [JsonProperty("begin_time")]
public 				string

                                                                                     beginTime
 { get; set; }
      [JsonProperty("end_time")]
public 				string

                                                                                     endTime
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
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("favor_mode")]
public 				int

                                                                                     favorMode
 { get; set; }
      [JsonProperty("rf_Id")]
public 				long

                                                                                     rfId
 { get; set; }
	}
}
