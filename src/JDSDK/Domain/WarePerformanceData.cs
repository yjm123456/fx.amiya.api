using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WarePerformanceData:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("sku")]
public 				string

             sku
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("financialSaleNum")]
public 				int

             financialSaleNum
 { get; set; }
      [JsonProperty("income")]
public 				double

             income
 { get; set; }
      [JsonProperty("cost")]
public 				double

             cost
 { get; set; }
      [JsonProperty("grossProfit")]
public 				double

             grossProfit
 { get; set; }
      [JsonProperty("couponDeduction")]
public 				double

             couponDeduction
 { get; set; }
      [JsonProperty("integralDeduction")]
public 				double

             integralDeduction
 { get; set; }
      [JsonProperty("fullSubtraction")]
public 				double

             fullSubtraction
 { get; set; }
      [JsonProperty("inventoryDays")]
public 				int

             inventoryDays
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
	}
}
