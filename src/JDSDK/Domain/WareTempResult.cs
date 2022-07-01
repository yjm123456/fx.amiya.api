using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareTempResult:JdObject{
      [JsonProperty("totalCount")]
public 				int

             totalCount
 { get; set; }
      [JsonProperty("currentPage")]
public 				int

             currentPage
 { get; set; }
      [JsonProperty("wareTempList")]
public 				List<string>

             wareTempList
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
