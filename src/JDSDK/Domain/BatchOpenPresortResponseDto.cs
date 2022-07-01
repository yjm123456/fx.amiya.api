using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BatchOpenPresortResponseDto:JdObject{
      [JsonProperty("responseCode")]
public 				int

             responseCode
 { get; set; }
      [JsonProperty("responseMessage")]
public 				string

             responseMessage
 { get; set; }
      [JsonProperty("successCount")]
public 				int

             successCount
 { get; set; }
      [JsonProperty("failCount")]
public 				int

             failCount
 { get; set; }
      [JsonProperty("successResponseDtoList")]
public 				List<string>

             successResponseDtoList
 { get; set; }
      [JsonProperty("failRequestDtoList")]
public 				List<string>

             failRequestDtoList
 { get; set; }
	}
}
