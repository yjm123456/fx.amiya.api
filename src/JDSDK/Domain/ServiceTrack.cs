using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceTrack:JdObject{
      [JsonProperty("trackCreateDate")]
public 				DateTime

             trackCreateDate
 { get; set; }
      [JsonProperty("trackContext")]
public 				string

             trackContext
 { get; set; }
      [JsonProperty("createPin")]
public 				string

             createPin
 { get; set; }
      [JsonProperty("createName")]
public 				string

             createName
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
