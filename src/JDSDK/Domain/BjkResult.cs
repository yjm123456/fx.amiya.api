using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BjkResult:JdObject{
      [JsonProperty("errorCode")]
public 				int

             errorCode
 { get; set; }
      [JsonProperty("errorMsg")]
public 				string

             errorMsg
 { get; set; }
      [JsonProperty("serviceNo")]
public 				string

             serviceNo
 { get; set; }
	}
}
