using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QuerySingleOrderForJosResultDto:JdObject{
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("errorCode")]
public 				string

             errorCode
 { get; set; }
      [JsonProperty("recordCount")]
public 				int

             recordCount
 { get; set; }
      [JsonProperty("resultSingleDto")]
public 				QueryOrderForJosResultDto

             resultSingleDto
 { get; set; }
	}
}
