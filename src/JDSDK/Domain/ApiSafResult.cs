using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ApiSafResult:JdObject{
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("resultDescribe")]
public 				string

             resultDescribe
 { get; set; }
	}
}
