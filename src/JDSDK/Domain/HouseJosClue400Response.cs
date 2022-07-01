using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosClue400Response:JdObject{
      [JsonProperty("sysMsg")]
public 				string

             sysMsg
 { get; set; }
      [JsonProperty("sysCode")]
public 				string

             sysCode
 { get; set; }
      [JsonProperty("data")]
public 				HouseJos400ClueVO

             data
 { get; set; }
	}
}
