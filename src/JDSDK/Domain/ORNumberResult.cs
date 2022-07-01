using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ORNumberResult:JdObject{
      [JsonProperty("result")]
public 				int

             result
 { get; set; }
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
	}
}
