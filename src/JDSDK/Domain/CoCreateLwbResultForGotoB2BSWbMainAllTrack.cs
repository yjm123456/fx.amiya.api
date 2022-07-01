using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CoCreateLwbResultForGotoB2BSWbMainAllTrack:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("resultMsg")]
public 				string

             resultMsg
 { get; set; }
      [JsonProperty("b2bLwbTrack")]
public 				List<string>

             b2bLwbTrack
 { get; set; }
	}
}
