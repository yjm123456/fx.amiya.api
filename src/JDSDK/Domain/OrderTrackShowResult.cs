using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderTrackShowResult:JdObject{
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("errorMessage")]
public 				string

             errorMessage
 { get; set; }
      [JsonProperty("trackShowResult")]
public 				TrackShowResult

             trackShowResult
 { get; set; }
	}
}
