using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseDsjRetVO:JdObject{
      [JsonProperty("spuId")]
public 				long

             spuId
 { get; set; }
      [JsonProperty("skuIds")]
public 				List<string>

             skuIds
 { get; set; }
	}
}
