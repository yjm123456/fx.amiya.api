using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SafeCResult:JdObject{
      [JsonProperty("result")]
public 					bool

             result
 { get; set; }
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("rKey")]
public 				string

             rKey
 { get; set; }
      [JsonProperty("resultMessage")]
public 				string

             resultMessage
 { get; set; }
      [JsonProperty("resultObj")]
public 				List<string>

             resultObj
 { get; set; }
	}
}
