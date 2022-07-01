using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BaseAddress:JdObject{
      [JsonProperty("addressId")]
public 				string

             addressId
 { get; set; }
      [JsonProperty("addressName")]
public 				string

             addressName
 { get; set; }
      [JsonProperty("addressLevel")]
public 				int

             addressLevel
 { get; set; }
	}
}
