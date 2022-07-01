using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BillCouponMO:JdObject{
      [JsonProperty("couponName")]
public 				string

             couponName
 { get; set; }
      [JsonProperty("effectDate")]
public 				string

             effectDate
 { get; set; }
      [JsonProperty("couponSource")]
public 				string

             couponSource
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("couponType")]
public 				string

             couponType
 { get; set; }
      [JsonProperty("bearerList")]
public 				List<string>

             bearerList
 { get; set; }
      [JsonProperty("couponBatchCode")]
public 				string

             couponBatchCode
 { get; set; }
      [JsonProperty("couponCode")]
public 				string

             couponCode
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
	}
}
