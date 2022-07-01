using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PurchaseOrderSkuJosDO:JdObject{
      [JsonProperty("purchaseId")]
public 				long

             purchaseId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("outerSkuId")]
public 				string

             outerSkuId
 { get; set; }
      [JsonProperty("skuNum")]
public 				int

             skuNum
 { get; set; }
      [JsonProperty("cgPrice")]
public 					string

             cgPrice
 { get; set; }
	}
}
