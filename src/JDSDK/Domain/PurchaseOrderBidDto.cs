using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PurchaseOrderBidDto:JdObject{
      [JsonProperty("status")]
public 				byte

             status
 { get; set; }
      [JsonProperty("vendorName")]
public 				string

             vendorName
 { get; set; }
      [JsonProperty("vendorNameAbbr")]
public 				string

             vendorNameAbbr
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("skuCount")]
public 					string

             skuCount
 { get; set; }
      [JsonProperty("bookBeginTime")]
public 				DateTime

             bookBeginTime
 { get; set; }
      [JsonProperty("channelCode")]
public 				string

             channelCode
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("factoryId")]
public 				long

             factoryId
 { get; set; }
      [JsonProperty("channelDownCode")]
public 				string

             channelDownCode
 { get; set; }
      [JsonProperty("purchaseOrderItemList")]
public 				List<string>

             purchaseOrderItemList
 { get; set; }
	}
}
