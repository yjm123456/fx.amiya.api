using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SpuBrokerVO:JdObject{
      [JsonProperty("spuId")]
public 				long

             spuId
 { get; set; }
      [JsonProperty("extensionPhone")]
public 				string

             extensionPhone
 { get; set; }
      [JsonProperty("extensionNum")]
public 				string

             extensionNum
 { get; set; }
	}
}
