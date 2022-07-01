using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderRemarkResult:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("errorMsg")]
public 				string

             errorMsg
 { get; set; }
      [JsonProperty("totleNum")]
public 				long

             totleNum
 { get; set; }
      [JsonProperty("remarkList")]
public 				List<string>

             remarkList
 { get; set; }
	}
}
