using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SpSourceOut:JdObject{
      [JsonProperty("spSourceNo")]
public 				string

             spSourceNo
 { get; set; }
      [JsonProperty("spSourceName")]
public 				string

             spSourceName
 { get; set; }
      [JsonProperty("website")]
public 				string

             website
 { get; set; }
      [JsonProperty("reserve1")]
public 				string

             reserve1
 { get; set; }
      [JsonProperty("reserve2")]
public 				string

             reserve2
 { get; set; }
      [JsonProperty("reserve3")]
public 				string

             reserve3
 { get; set; }
      [JsonProperty("reserve4")]
public 				string

             reserve4
 { get; set; }
      [JsonProperty("reserve5")]
public 				string

             reserve5
 { get; set; }
	}
}
