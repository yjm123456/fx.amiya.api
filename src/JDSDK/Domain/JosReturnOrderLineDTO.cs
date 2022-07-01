using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosReturnOrderLineDTO:JdObject{
      [JsonProperty("returnOrderCode")]
public 				string

             returnOrderCode
 { get; set; }
      [JsonProperty("vendorProductId")]
public 				string

             vendorProductId
 { get; set; }
      [JsonProperty("jdSku")]
public 				string

             jdSku
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("productCode")]
public 				string

             productCode
 { get; set; }
      [JsonProperty("quantity")]
public 				int

             quantity
 { get; set; }
      [JsonProperty("pricing")]
public 					string

             pricing
 { get; set; }
      [JsonProperty("salesPrice")]
public 					string

             salesPrice
 { get; set; }
      [JsonProperty("sparePartReturnPrice")]
public 					string

             sparePartReturnPrice
 { get; set; }
      [JsonProperty("discountRate")]
public 					string

             discountRate
 { get; set; }
      [JsonProperty("returnBased")]
public 				string

             returnBased
 { get; set; }
      [JsonProperty("receivingQty")]
public 				int

             receivingQty
 { get; set; }
      [JsonProperty("damagedQty")]
public 				int

             damagedQty
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("idPart")]
public 				string

             idPart
 { get; set; }
      [JsonProperty("damageReason")]
public 				string

             damageReason
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
