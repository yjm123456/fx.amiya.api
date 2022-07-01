using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CouponDetail:JdObject{
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("couponType")]
public 				string

             couponType
 { get; set; }
      [JsonProperty("couponPrice")]
public 				string

             couponPrice
 { get; set; }
	}
}
