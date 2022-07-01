using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AdWords:JdObject{
      [JsonProperty("words")]
public 				string

             words
 { get; set; }
      [JsonProperty("url")]
public 				string

             url
 { get; set; }
      [JsonProperty("urlWords")]
public 				string

             urlWords
 { get; set; }
	}
}
