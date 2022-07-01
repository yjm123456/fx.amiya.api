using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryOrderForJosResultList:JdObject{
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("errorMessage")]
public 				string

             errorMessage
 { get; set; }
      [JsonProperty("errorCode")]
public 				string

             errorCode
 { get; set; }
      [JsonProperty("recordCount")]
public 				int

             recordCount
 { get; set; }
      [JsonProperty("resultDtoList")]
public 				List<string>

             resultDtoList
 { get; set; }
	}
}
