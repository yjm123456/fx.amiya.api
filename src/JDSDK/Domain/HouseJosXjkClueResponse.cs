using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosXjkClueResponse:JdObject{
      [JsonProperty("sysMsg")]
public 				string

             sysMsg
 { get; set; }
      [JsonProperty("sysCode")]
public 				string

             sysCode
 { get; set; }
      [JsonProperty("data")]
public 				HouseJosXjkClueVO

             data
 { get; set; }
	}
}
