using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderQueryResult:JdObject{
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("soNoList")]
public 				List<string>

             soNoList
 { get; set; }
	}
}
