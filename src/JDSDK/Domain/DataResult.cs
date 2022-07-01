using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DataResult:JdObject{
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("result")]
public 				object

             result
 { get; set; }
	}
}
