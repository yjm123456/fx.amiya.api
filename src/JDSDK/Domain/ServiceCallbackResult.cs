using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceCallbackResult:JdObject{
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("resultMsg")]
public 				string

             resultMsg
 { get; set; }
	}
}
