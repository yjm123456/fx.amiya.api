using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Area:JdObject{
      [JsonProperty("areaId")]
public 				int

             areaId
 { get; set; }
      [JsonProperty("areaName")]
public 				string

             areaName
 { get; set; }
      [JsonProperty("parentId")]
public 				int

             parentId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("level")]
public 				int

             level
 { get; set; }
	}
}
