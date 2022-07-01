using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ItemInfo:JdObject{
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("outerSkuId")]
public 				string

             outerSkuId
 { get; set; }
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("jdPrice")]
public 				string

             jdPrice
 { get; set; }
      [JsonProperty("giftPoint")]
public 				string

             giftPoint
 { get; set; }
      [JsonProperty("wareId")]
public 				string

             wareId
 { get; set; }
      [JsonProperty("itemTotal")]
public 				string

             itemTotal
 { get; set; }
      [JsonProperty("productNo")]
public 				string

             productNo
 { get; set; }
      [JsonProperty("serviceName")]
public 				string

             serviceName
 { get; set; }
      [JsonProperty("newStoreId")]
public 				string

             newStoreId
 { get; set; }
	}
}
