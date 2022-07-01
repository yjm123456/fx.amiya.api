using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TrackShow:JdObject{
      [JsonProperty("msgTime")]
public 				string

             msgTime
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("op")]
public 				string

             op
 { get; set; }
	}
}
