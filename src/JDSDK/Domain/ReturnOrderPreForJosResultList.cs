using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReturnOrderPreForJosResultList:JdObject{
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
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
