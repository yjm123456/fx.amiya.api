using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosShipmentConfirmationLineDTO:JdObject{
      [JsonProperty("currentRecordCount")]
public 				int

             currentRecordCount
 { get; set; }
      [JsonProperty("vendorSku")]
public 				string

             vendorSku
 { get; set; }
      [JsonProperty("buyerProductId")]
public 				string

             buyerProductId
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("quantity")]
public 				int

             quantity
 { get; set; }
      [JsonProperty("receivingQty")]
public 				int

             receivingQty
 { get; set; }
      [JsonProperty("salePrice")]
public 					string

             salePrice
 { get; set; }
      [JsonProperty("packageNum")]
public 				string

             packageNum
 { get; set; }
      [JsonProperty("packFirmNumber")]
public 				string

             packFirmNumber
 { get; set; }
      [JsonProperty("firmRoyalty")]
public 				string

             firmRoyalty
 { get; set; }
      [JsonProperty("diffDescription")]
public 				string

             diffDescription
 { get; set; }
      [JsonProperty("receivingDate")]
public 				DateTime

             receivingDate
 { get; set; }
      [JsonProperty("comments")]
public 				string

             comments
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
	}
}
