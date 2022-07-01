using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SvcResult:JdObject{
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("errCode")]
public 				int

             errCode
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("data")]
public 				SvcApiVerificationInfo

             data
 { get; set; }
	}
}
