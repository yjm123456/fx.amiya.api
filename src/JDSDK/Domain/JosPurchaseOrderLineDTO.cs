using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosPurchaseOrderLineDTO:JdObject{
      [JsonProperty("purchaseOrderCode")]
public 				string

             purchaseOrderCode
 { get; set; }
      [JsonProperty("brandId")]
public 				int

             brandId
 { get; set; }
      [JsonProperty("cate3Id")]
public 				int

             cate3Id
 { get; set; }
      [JsonProperty("vendorSku")]
public 				string

             vendorSku
 { get; set; }
      [JsonProperty("buyerProductId")]
public 				string

             buyerProductId
 { get; set; }
      [JsonProperty("productCode")]
public 				string

             productCode
 { get; set; }
      [JsonProperty("upcCode")]
public 				string

             upcCode
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("encasementRule")]
public 				int

             encasementRule
 { get; set; }
      [JsonProperty("listPrice")]
public 				double

             listPrice
 { get; set; }
      [JsonProperty("quantity")]
public 				int

             quantity
 { get; set; }
      [JsonProperty("salePrice")]
public 				double

             salePrice
 { get; set; }
      [JsonProperty("discountRate")]
public 				double

             discountRate
 { get; set; }
      [JsonProperty("inspectionMode")]
public 				int

             inspectionMode
 { get; set; }
      [JsonProperty("backOrderProcessing")]
public 				string

             backOrderProcessing
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
	}
}
