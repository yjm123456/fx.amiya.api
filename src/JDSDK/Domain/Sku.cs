using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Sku:JdObject{
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("imageUrl")]
public 				string

             imageUrl
 { get; set; }
      [JsonProperty("price")]
public 				long

             price
 { get; set; }
      [JsonProperty("model")]
public 				string

             model
 { get; set; }
      [JsonProperty("description")]
public 				string

             description
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("articleNumber")]
public 				string

             articleNumber
 { get; set; }
      [JsonProperty("barcode")]
public 				string

             barcode
 { get; set; }
	}
}
