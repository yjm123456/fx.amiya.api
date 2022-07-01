using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuProductInfo:JdObject{
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("spuId")]
public 				string

             spuId
 { get; set; }
      [JsonProperty("saleAttributes")]
public 				string

             saleAttributes
 { get; set; }
      [JsonProperty("price")]
public 				long

             price
 { get; set; }
      [JsonProperty("imageUrl")]
public 				string

             imageUrl
 { get; set; }
      [JsonProperty("barcode")]
public 				string

             barcode
 { get; set; }
      [JsonProperty("basePrice")]
public 				long

             basePrice
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("jdSpuId")]
public 				long

             jdSpuId
 { get; set; }
      [JsonProperty("jdSkuId")]
public 				long

             jdSkuId
 { get; set; }
	}
}
