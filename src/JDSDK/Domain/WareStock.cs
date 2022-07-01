using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareStock:JdObject{
      [JsonProperty("sku")]
public 				long

             sku
 { get; set; }
      [JsonProperty("hasStock")]
public 				bool

             hasStock
 { get; set; }
      [JsonProperty("remainNum")]
public 				int

             remainNum
 { get; set; }
	}
}
