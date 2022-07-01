using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuResp:JdObject{
      [JsonProperty("packSpecification")]
public 				string

             packSpecification
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("purchaseNum")]
public 				long

             purchaseNum
 { get; set; }
      [JsonProperty("purchasePrice")]
public 				long

             purchasePrice
 { get; set; }
      [JsonProperty("skuPrice")]
public 					string

             skuPrice
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("promotionId")]
public 				long

             promotionId
 { get; set; }
      [JsonProperty("picUrl")]
public 				string

             picUrl
 { get; set; }
      [JsonProperty("industryId")]
public 				long

             industryId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("promotionType")]
public 				int

             promotionType
 { get; set; }
      [JsonProperty("weight")]
public 				double

             weight
 { get; set; }
      [JsonProperty("cat2")]
public 				long

             cat2
 { get; set; }
      [JsonProperty("cat3")]
public 				long

             cat3
 { get; set; }
      [JsonProperty("cat1")]
public 				long

             cat1
 { get; set; }
      [JsonProperty("brandId")]
public 				long

             brandId
 { get; set; }
	}
}
