using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CouponDetailVo:JdObject{
      [JsonProperty("promotionList")]
public 				List<string>

             promotionList
 { get; set; }
      [JsonProperty("couponList")]
public 				List<string>

             couponList
 { get; set; }
      [JsonProperty("skuList")]
public 				List<string>

             skuList
 { get; set; }
      [JsonProperty("totalItemPrice")]
public 					string

             totalItemPrice
 { get; set; }
      [JsonProperty("totalBaseDiscount")]
public 					string

             totalBaseDiscount
 { get; set; }
      [JsonProperty("totalManJian")]
public 					string

             totalManJian
 { get; set; }
      [JsonProperty("totalVenderFee")]
public 					string

             totalVenderFee
 { get; set; }
      [JsonProperty("totalBaseFee")]
public 					string

             totalBaseFee
 { get; set; }
      [JsonProperty("totalRemoteFee")]
public 					string

             totalRemoteFee
 { get; set; }
      [JsonProperty("totalCoupon")]
public 					string

             totalCoupon
 { get; set; }
      [JsonProperty("totalJingDou")]
public 					string

             totalJingDou
 { get; set; }
      [JsonProperty("totalBalance")]
public 					string

             totalBalance
 { get; set; }
      [JsonProperty("totalSuperRedEnvelope")]
public 					string

             totalSuperRedEnvelope
 { get; set; }
      [JsonProperty("totalPlus95")]
public 					string

             totalPlus95
 { get; set; }
      [JsonProperty("totalTuiHuanHuoWuYou")]
public 					string

             totalTuiHuanHuoWuYou
 { get; set; }
      [JsonProperty("totalTaxFee")]
public 					string

             totalTaxFee
 { get; set; }
      [JsonProperty("totalLuoDiPeiService")]
public 					string

             totalLuoDiPeiService
 { get; set; }
      [JsonProperty("totalShouldPay")]
public 					string

             totalShouldPay
 { get; set; }
	}
}
