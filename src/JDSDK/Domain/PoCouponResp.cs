using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PoCouponResp:JdObject{
      [JsonProperty("dbVersion")]
public 				int

             dbVersion
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("couponId")]
public 				long

             couponId
 { get; set; }
      [JsonProperty("limitType")]
public 				int

             limitType
 { get; set; }
      [JsonProperty("useDiscount")]
public 					string

             useDiscount
 { get; set; }
      [JsonProperty("couponState")]
public 				int

             couponState
 { get; set; }
      [JsonProperty("couponDiscount")]
public 					string

             couponDiscount
 { get; set; }
      [JsonProperty("couponType")]
public 				int

             couponType
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("couponRemark")]
public 				string

             couponRemark
 { get; set; }
      [JsonProperty("beginTime")]
public 				DateTime

             beginTime
 { get; set; }
      [JsonProperty("endTime")]
public 				DateTime

             endTime
 { get; set; }
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("properties")]
public 				string

             properties
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
