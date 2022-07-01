using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SimpleBrandDto:JdObject{
      [JsonProperty("id")]
public 				int

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
	}
}
