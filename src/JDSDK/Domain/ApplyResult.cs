using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ApplyResult:JdObject{
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
      [JsonProperty("data")]
public 				ApplyBrief

             data
 { get; set; }
	}
}
