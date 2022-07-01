using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CoResult:JdObject{
      [JsonProperty("wbNo")]
public 				string

             wbNo
 { get; set; }
      [JsonProperty("lwbNo")]
public 				string

             lwbNo
 { get; set; }
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("resultMsg")]
public 				string

             resultMsg
 { get; set; }
      [JsonProperty("resultData")]
public 					Dictionary<string, object>

             resultData
 { get; set; }
	}
}
