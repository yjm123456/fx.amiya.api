using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CetusRemoteResult:JdObject{
      [JsonProperty("errorCode")]
public 				string

             errorCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("isSuccess")]
public 					bool

             isSuccess
 { get; set; }
      [JsonProperty("data")]
public 				BrandVO

             data
 { get; set; }
	}
}
