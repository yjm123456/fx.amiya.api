using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuClient:JdObject{
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("goodsType")]
public 				int

             goodsType
 { get; set; }
      [JsonProperty("sku")]
public 				long

             sku
 { get; set; }
      [JsonProperty("num")]
public 				int

             num
 { get; set; }
      [JsonProperty("lowestReferencePrice")]
public 					string

             lowestReferencePrice
 { get; set; }
	}
}
