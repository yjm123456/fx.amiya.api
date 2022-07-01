using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StateResult:JdObject{
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("errorMsg")]
public 				string

             errorMsg
 { get; set; }
      [JsonProperty("key")]
public 				string

             key
 { get; set; }
      [JsonProperty("t")]
public 				List<string>

             t
 { get; set; }
      [JsonProperty("total")]
public 				long

             total
 { get; set; }
	}
}
