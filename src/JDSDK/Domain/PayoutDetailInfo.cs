using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PayoutDetailInfo:JdObject{
      [JsonProperty("payoutDetailId")]
public 				int

             payoutDetailId
 { get; set; }
      [JsonProperty("orderPrice")]
public 					string

             orderPrice
 { get; set; }
      [JsonProperty("payoutPrice")]
public 					string

             payoutPrice
 { get; set; }
      [JsonProperty("payoutCount")]
public 				string

             payoutCount
 { get; set; }
      [JsonProperty("couponNum")]
public 				int

             couponNum
 { get; set; }
      [JsonProperty("couponCode")]
public 				string

             couponCode
 { get; set; }
      [JsonProperty("distributeStatus")]
public 				bool

             distributeStatus
 { get; set; }
      [JsonProperty("couponType")]
public 				int

             couponType
 { get; set; }
      [JsonProperty("couponTypeName")]
public 				string

             couponTypeName
 { get; set; }
	}
}
