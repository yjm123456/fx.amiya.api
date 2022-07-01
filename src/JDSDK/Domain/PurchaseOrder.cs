using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PurchaseOrder:JdObject{
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
      [JsonProperty("purchaseOrderStatus")]
public 				int

             purchaseOrderStatus
 { get; set; }
      [JsonProperty("complateDate")]
public 				DateTime

             complateDate
 { get; set; }
      [JsonProperty("erpOrders")]
public 				List<string>

             erpOrders
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
      [JsonProperty("isLock")]
public 				int

             isLock
 { get; set; }
      [JsonProperty("freightPrice")]
public 					string

             freightPrice
 { get; set; }
      [JsonProperty("consigneeAddress")]
public 				string

             consigneeAddress
 { get; set; }
	}
}
