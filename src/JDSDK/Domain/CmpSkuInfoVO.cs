using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CmpSkuInfoVO:JdObject{
      [JsonProperty("skuName")]
public 				string

             skuName
 { get; set; }
      [JsonProperty("productImageUrl")]
public 				string

             productImageUrl
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("price")]
public 				double

             price
 { get; set; }
      [JsonProperty("commission")]
public 				double

             commission
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("ImagePrefix")]
public 				string

             ImagePrefix
 { get; set; }
	}
}
