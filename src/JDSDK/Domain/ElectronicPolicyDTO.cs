using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ElectronicPolicyDTO:JdObject{
      [JsonProperty("purchaseOrderCode")]
public 				string

             purchaseOrderCode
 { get; set; }
      [JsonProperty("mark")]
public 				int

             mark
 { get; set; }
      [JsonProperty("brand")]
public 				string

             brand
 { get; set; }
      [JsonProperty("category")]
public 				string

             category
 { get; set; }
      [JsonProperty("sku")]
public 				string

             sku
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("orderAmount")]
public 				double

             orderAmount
 { get; set; }
      [JsonProperty("payAmount")]
public 				double

             payAmount
 { get; set; }
      [JsonProperty("orderCreateTime")]
public 				DateTime

             orderCreateTime
 { get; set; }
      [JsonProperty("orderLeaveStockTime")]
public 				DateTime

             orderLeaveStockTime
 { get; set; }
      [JsonProperty("payTime")]
public 				DateTime

             payTime
 { get; set; }
      [JsonProperty("finishOrderTime")]
public 				DateTime

             finishOrderTime
 { get; set; }
      [JsonProperty("serialNumber")]
public 				string

             serialNumber
 { get; set; }
	}
}
