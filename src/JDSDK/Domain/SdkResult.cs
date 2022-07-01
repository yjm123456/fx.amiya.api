using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SdkResult:JdObject{
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("resultMessage")]
public 				string

             resultMessage
 { get; set; }
      [JsonProperty("reqId")]
public 				string

             reqId
 { get; set; }
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("result")]
public 				List<string>

             result
 { get; set; }
	}
}
