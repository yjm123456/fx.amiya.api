using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResponseDTO:JdObject{
      [JsonProperty("statusCode")]
public 				int

             statusCode
 { get; set; }
      [JsonProperty("statusMessage")]
public 				string

             statusMessage
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
	}
}
