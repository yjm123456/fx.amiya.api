using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TraceDetail:JdObject{
      [JsonProperty("extension")]
public 					Dictionary<string, object>

             extension
 { get; set; }
      [JsonProperty("waybillId")]
public 				string

             waybillId
 { get; set; }
      [JsonProperty("content")]
public 				string

             content
 { get; set; }
      [JsonProperty("operationTime")]
public 				string

             operationTime
 { get; set; }
      [JsonProperty("operater")]
public 				string

             operater
 { get; set; }
	}
}
