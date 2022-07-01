using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderSkuResp:JdObject{
      [JsonProperty("brandId")]
public 				int

             brandId
 { get; set; }
      [JsonProperty("extFreight")]
public 					string

             extFreight
 { get; set; }
      [JsonProperty("firstCategory")]
public 				int

             firstCategory
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("imgUrl")]
public 				string

             imgUrl
 { get; set; }
      [JsonProperty("nakedPrice")]
public 					string

             nakedPrice
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("num")]
public 				int

             num
 { get; set; }
      [JsonProperty("originalPrice")]
public 					string

             originalPrice
 { get; set; }
      [JsonProperty("parentSkuId")]
public 				long

             parentSkuId
 { get; set; }
      [JsonProperty("pdPin")]
public 				string

             pdPin
 { get; set; }
      [JsonProperty("promotionCode")]
public 				string

             promotionCode
 { get; set; }
      [JsonProperty("promotionType")]
public 				int

             promotionType
 { get; set; }
      [JsonProperty("salesPrice")]
public 					string

             salesPrice
 { get; set; }
      [JsonProperty("secondCategory")]
public 				int

             secondCategory
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("skuType")]
public 				int

             skuType
 { get; set; }
      [JsonProperty("stockType")]
public 				int

             stockType
 { get; set; }
      [JsonProperty("suitId")]
public 				long

             suitId
 { get; set; }
      [JsonProperty("tag")]
public 				int

             tag
 { get; set; }
      [JsonProperty("taxPrice")]
public 					string

             taxPrice
 { get; set; }
      [JsonProperty("taxRate")]
public 					string

             taxRate
 { get; set; }
      [JsonProperty("thirdCategory")]
public 				int

             thirdCategory
 { get; set; }
      [JsonProperty("thirdSkuId")]
public 				string

             thirdSkuId
 { get; set; }
      [JsonProperty("parentId")]
public 				long

             parentId
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("extAttr")]
public 					Dictionary<string, object>

             extAttr
 { get; set; }
	}
}
