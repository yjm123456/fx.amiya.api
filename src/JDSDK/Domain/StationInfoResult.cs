using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StationInfoResult:JdObject{
      [JsonProperty("value")]
public 				string

             value
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
	}
}
