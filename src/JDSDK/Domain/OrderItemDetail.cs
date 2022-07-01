using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderItemDetail:JdObject{
      [JsonProperty("skuCode")]
public 				string

             skuCode
 { get; set; }
      [JsonProperty("count")]
public 				int

             count
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("skuPrice")]
public 					string

             skuPrice
 { get; set; }
      [JsonProperty("baseDiscount")]
public 					string

             baseDiscount
 { get; set; }
      [JsonProperty("manJian")]
public 					string

             manJian
 { get; set; }
      [JsonProperty("venderFee")]
public 					string

             venderFee
 { get; set; }
      [JsonProperty("baseFee")]
public 					string

             baseFee
 { get; set; }
      [JsonProperty("remoteFee")]
public 					string

             remoteFee
 { get; set; }
      [JsonProperty("coupon")]
public 					string

             coupon
 { get; set; }
      [JsonProperty("jingDou")]
public 					string

             jingDou
 { get; set; }
      [JsonProperty("balance")]
public 					string

             balance
 { get; set; }
      [JsonProperty("superRedEnvelope")]
public 					string

             superRedEnvelope
 { get; set; }
      [JsonProperty("plus95")]
public 					string

             plus95
 { get; set; }
      [JsonProperty("tuiHuanHuoWuYou")]
public 					string

             tuiHuanHuoWuYou
 { get; set; }
      [JsonProperty("taxFee")]
public 					string

             taxFee
 { get; set; }
      [JsonProperty("luoDiPeiService")]
public 					string

             luoDiPeiService
 { get; set; }
      [JsonProperty("shouldPay")]
public 					string

             shouldPay
 { get; set; }
	}
}
