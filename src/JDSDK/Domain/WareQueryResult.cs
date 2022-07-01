using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareQueryResult:JdObject{
      [JsonProperty("totalCount")]
public 				int

             totalCount
 { get; set; }
      [JsonProperty("currentPage")]
public 				int

             currentPage
 { get; set; }
      [JsonProperty("wareList")]
public 				List<string>

             wareList
 { get; set; }
      [JsonProperty("messegeCode")]
public 				string

             messegeCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
	}
}
