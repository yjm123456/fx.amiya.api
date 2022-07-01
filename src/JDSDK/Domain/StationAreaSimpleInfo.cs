using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StationAreaSimpleInfo:JdObject{
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("areaName")]
public 				string

             areaName
 { get; set; }
      [JsonProperty("updateUser")]
public 				string

             updateUser
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
	}
}
