using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockState:JdObject{
      [JsonProperty("areaId")]
public 				string

             areaId
 { get; set; }
      [JsonProperty("remainNum")]
public 				int

             remainNum
 { get; set; }
      [JsonProperty("stockStateId")]
public 				string

             stockStateId
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
	}
}
