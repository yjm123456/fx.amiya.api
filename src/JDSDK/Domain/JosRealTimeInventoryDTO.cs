using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosRealTimeInventoryDTO:JdObject{
      [JsonProperty("productCode")]
public 				string

             productCode
 { get; set; }
      [JsonProperty("orgCode")]
public 				string

             orgCode
 { get; set; }
      [JsonProperty("warehouseCode")]
public 				string

             warehouseCode
 { get; set; }
      [JsonProperty("spotQuantity")]
public 				int

             spotQuantity
 { get; set; }
      [JsonProperty("orderableQuantity")]
public 				int

             orderableQuantity
 { get; set; }
      [JsonProperty("orderBookingNum")]
public 				int

             orderBookingNum
 { get; set; }
      [JsonProperty("ztNum")]
public 				int

             ztNum
 { get; set; }
      [JsonProperty("transferInNum")]
public 				int

             transferInNum
 { get; set; }
      [JsonProperty("transferOutNum")]
public 				int

             transferOutNum
 { get; set; }
      [JsonProperty("unarrivedPurchases")]
public 				int

             unarrivedPurchases
 { get; set; }
      [JsonProperty("appBookingNum")]
public 				int

             appBookingNum
 { get; set; }
	}
}
