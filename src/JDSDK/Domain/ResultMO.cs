using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResultMO:JdObject{
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("values")]
public 				List<string>

             values
 { get; set; }
      [JsonProperty("totalElements")]
public 				long

             totalElements
 { get; set; }
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
	}
}
