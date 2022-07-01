using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosCoupon:JdObject{
      [JsonProperty("couponId")]
public 				long

             couponId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("lockType")]
public 				int

             lockType
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("bindType")]
public 				int

             bindType
 { get; set; }
      [JsonProperty("grantType")]
public 				int

             grantType
 { get; set; }
      [JsonProperty("num")]
public 				int

             num
 { get; set; }
      [JsonProperty("discount")]
public 					string

             discount
 { get; set; }
      [JsonProperty("quota")]
public 					string

             quota
 { get; set; }
      [JsonProperty("validityType")]
public 				int

             validityType
 { get; set; }
      [JsonProperty("days")]
public 				int

             days
 { get; set; }
      [JsonProperty("beginTime")]
public 				long

             beginTime
 { get; set; }
      [JsonProperty("endTime")]
public 				long

             endTime
 { get; set; }
      [JsonProperty("password")]
public 				string

             password
 { get; set; }
      [JsonProperty("rfId")]
public 				long

             rfId
 { get; set; }
      [JsonProperty("member")]
public 				int

             member
 { get; set; }
      [JsonProperty("takeBeginTime")]
public 				long

             takeBeginTime
 { get; set; }
      [JsonProperty("takeEndTime")]
public 				long

             takeEndTime
 { get; set; }
      [JsonProperty("takeRule")]
public 				int

             takeRule
 { get; set; }
      [JsonProperty("takeNum")]
public 				int

             takeNum
 { get; set; }
      [JsonProperty("link")]
public 				string

             link
 { get; set; }
      [JsonProperty("activityRfId")]
public 				long

             activityRfId
 { get; set; }
      [JsonProperty("activityLink")]
public 				string

             activityLink
 { get; set; }
      [JsonProperty("usedNum")]
public 				int

             usedNum
 { get; set; }
      [JsonProperty("sendNum")]
public 				int

             sendNum
 { get; set; }
      [JsonProperty("deleted")]
public 				bool

             deleted
 { get; set; }
      [JsonProperty("display")]
public 				int

             display
 { get; set; }
      [JsonProperty("created")]
public 				long

             created
 { get; set; }
      [JsonProperty("platformType")]
public 				int

             platformType
 { get; set; }
      [JsonProperty("platform")]
public 				string

             platform
 { get; set; }
      [JsonProperty("imgUrl")]
public 				string

             imgUrl
 { get; set; }
      [JsonProperty("boundStatus")]
public 				int

             boundStatus
 { get; set; }
      [JsonProperty("jdNum")]
public 				int

             jdNum
 { get; set; }
      [JsonProperty("itemId")]
public 				long

             itemId
 { get; set; }
      [JsonProperty("shareType")]
public 				int

             shareType
 { get; set; }
      [JsonProperty("extMapInfo")]
public 					Dictionary<string, object>

             extMapInfo
 { get; set; }
	}
}
