using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResultVO:JdObject{
      [JsonProperty("busMsg")]
public 				string

             busMsg
 { get; set; }
      [JsonProperty("busVersion")]
public 				string

             busVersion
 { get; set; }
      [JsonProperty("busCode")]
public 				string

             busCode
 { get; set; }
      [JsonProperty("busData")]
public 				string

             busData
 { get; set; }
      [JsonProperty("busTime")]
public 				string

             busTime
 { get; set; }
	}
}
