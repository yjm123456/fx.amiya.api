using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Track:JdObject{
      [JsonProperty("orderCode")]
public 				string

             orderCode
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("creationTime")]
public 				DateTime

             creationTime
 { get; set; }
      [JsonProperty("operator")]
public 				string

             operator1
 { get; set; }
	}
}
