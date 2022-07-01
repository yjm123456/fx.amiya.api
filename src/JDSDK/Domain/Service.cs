using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Service:JdObject{
      [JsonProperty("purchaseId")]
public 				long

             purchaseId
 { get; set; }
      [JsonProperty("serviceId")]
public 				string

             serviceId
 { get; set; }
      [JsonProperty("purchaseOrderPrice")]
public 					string

             purchaseOrderPrice
 { get; set; }
      [JsonProperty("freight")]
public 					string

             freight
 { get; set; }
      [JsonProperty("purchaseOrderTotalPrice")]
public 					string

             purchaseOrderTotalPrice
 { get; set; }
      [JsonProperty("submitDate")]
public 				DateTime

             submitDate
 { get; set; }
      [JsonProperty("applyDate")]
public 				DateTime

             applyDate
 { get; set; }
      [JsonProperty("completeDate")]
public 				DateTime

             completeDate
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("purchaseNum")]
public 				int

             purchaseNum
 { get; set; }
      [JsonProperty("userExpectation")]
public 				int

             userExpectation
 { get; set; }
      [JsonProperty("purchaseOrderStatus")]
public 				int

             purchaseOrderStatus
 { get; set; }
      [JsonProperty("feedbackMsg")]
public 				string

             feedbackMsg
 { get; set; }
      [JsonProperty("orderSku")]
public 				OrderSku

             orderSku
 { get; set; }
      [JsonProperty("sellerShopName")]
public 				string

             sellerShopName
 { get; set; }
      [JsonProperty("sellerId")]
public 				int

             sellerId
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("applyTime")]
public 				string

             applyTime
 { get; set; }
      [JsonProperty("dealTime")]
public 				string

             dealTime
 { get; set; }
      [JsonProperty("serviceStatus")]
public 				int

             serviceStatus
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
	}
}
