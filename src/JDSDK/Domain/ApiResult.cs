using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ApiResult:JdObject{
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("uuid")]
public 				string

             uuid
 { get; set; }
      [JsonProperty("data")]
public 				bool

             data
 { get; set; }
	}
}
