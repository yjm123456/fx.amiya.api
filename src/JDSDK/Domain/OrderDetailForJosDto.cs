using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderDetailForJosDto:JdObject{
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("upc")]
public 				string

             upc
 { get; set; }
      [JsonProperty("commodityName")]
public 				string

             commodityName
 { get; set; }
      [JsonProperty("commodityNum")]
public 				int

             commodityNum
 { get; set; }
      [JsonProperty("jdPrice")]
public 					string

             jdPrice
 { get; set; }
      [JsonProperty("discount")]
public 					string

             discount
 { get; set; }
      [JsonProperty("cost")]
public 					string

             cost
 { get; set; }
	}
}
