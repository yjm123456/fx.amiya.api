using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ExperimentDTO:JdObject{
      [JsonProperty("experimentId")]
public 				long

             experimentId
 { get; set; }
      [JsonProperty("subExpType")]
public 				int

             subExpType
 { get; set; }
      [JsonProperty("startTime")]
public 					DateTime

             startTime
 { get; set; }
      [JsonProperty("endTime")]
public 					DateTime

             endTime
 { get; set; }
	}
}
