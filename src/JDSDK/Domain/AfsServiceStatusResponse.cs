using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsServiceStatusResponse:JdObject{
      [JsonProperty("serviceNo")]
public 				string

             serviceNo
 { get; set; }
      [JsonProperty("afsServiceTaskNo")]
public 				string

             afsServiceTaskNo
 { get; set; }
      [JsonProperty("afsServiceStatus")]
public 				int

             afsServiceStatus
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("latestUpdateTime")]
public 				string

             latestUpdateTime
 { get; set; }
	}
}
