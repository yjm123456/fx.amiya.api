using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosSpuResponse:JdObject{
      [JsonProperty("sysCode")]
public 				string

             sysCode
 { get; set; }
      [JsonProperty("sysMsg")]
public 				string

             sysMsg
 { get; set; }
      [JsonProperty("data")]
public 				List<string>

             data
 { get; set; }
      [JsonProperty("totalCount")]
public 				int

             totalCount
 { get; set; }
	}
}
