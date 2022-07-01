using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ErpOrder:JdObject{
      [JsonProperty("purchaseOrderPrice")]
public 					string

             purchaseOrderPrice
 { get; set; }
      [JsonProperty("consigneeTel")]
public 				string

             consigneeTel
 { get; set; }
      [JsonProperty("sellerName")]
public 				string

             sellerName
 { get; set; }
      [JsonProperty("orderSkuList")]
public 				List<string>

             orderSkuList
 { get; set; }
      [JsonProperty("complateDate")]
public 				DateTime

             complateDate
 { get; set; }
      [JsonProperty("userPin")]
public 				string

             userPin
 { get; set; }
      [JsonProperty("consigneeName")]
public 				string

             consigneeName
 { get; set; }
      [JsonProperty("purchaseOrderTotalPrice")]
public 					string

             purchaseOrderTotalPrice
 { get; set; }
      [JsonProperty("submiteDate")]
public 				DateTime

             submiteDate
 { get; set; }
      [JsonProperty("purchaseOrderId")]
public 				long

             purchaseOrderId
 { get; set; }
      [JsonProperty("erpOrderStatus")]
public 				string

             erpOrderStatus
 { get; set; }
      [JsonProperty("freightPrice")]
public 					string

             freightPrice
 { get; set; }
      [JsonProperty("jdOrderId")]
public 				long

             jdOrderId
 { get; set; }
      [JsonProperty("consigneeAddress")]
public 				string

             consigneeAddress
 { get; set; }
	}
}
