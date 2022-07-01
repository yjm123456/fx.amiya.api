using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderCouponDetail:JdObject{
      [JsonProperty("jdCouponId")]
public 				string

             jdCouponId
 { get; set; }
      [JsonProperty("couponTypeDesc")]
public 				string

             couponTypeDesc
 { get; set; }
      [JsonProperty("couponPrice")]
public 				string

             couponPrice
 { get; set; }
      [JsonProperty("couponId")]
public 				long

             couponId
 { get; set; }
      [JsonProperty("couponName")]
public 				string

             couponName
 { get; set; }
      [JsonProperty("couponNum")]
public 				int

             couponNum
 { get; set; }
      [JsonProperty("priceDivide")]
public 				bool

             priceDivide
 { get; set; }
      [JsonProperty("venderDivideMoney")]
public 					string

             venderDivideMoney
 { get; set; }
      [JsonProperty("jdDivideMoney")]
public 					string

             jdDivideMoney
 { get; set; }
	}
}
