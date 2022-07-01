using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ConfirmAcceptOrderResult:JdObject{
      [JsonProperty("code")]
public 				string

             code
 { get; set; }
      [JsonProperty("msg")]
public 				string

             msg
 { get; set; }
      [JsonProperty("data")]
public 				bool

             data
 { get; set; }
      [JsonProperty("uuid")]
public 				string

             uuid
 { get; set; }
	}
}
