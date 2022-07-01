using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class POPGroup:JdObject{
      [JsonProperty("shopName")]
public 				string

             shopName
 { get; set; }
      [JsonProperty("shopUrl")]
public 				string

             shopUrl
 { get; set; }
      [JsonProperty("waiterCount")]
public 				int

             waiterCount
 { get; set; }
      [JsonProperty("waiterList")]
public 				List<string>

             waiterList
 { get; set; }
	}
}
