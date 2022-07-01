using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PoExtResp:JdObject{
      [JsonProperty("extKey")]
public 				string

             extKey
 { get; set; }
      [JsonProperty("dbVersion")]
public 				int

             dbVersion
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("snapShotType")]
public 				int

             snapShotType
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("extValue")]
public 				string

             extValue
 { get; set; }
      [JsonProperty("properties")]
public 				string

             properties
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
