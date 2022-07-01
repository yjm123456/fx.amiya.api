using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderJingcreditMainInfo:JdObject{
      [JsonProperty("finalScore")]
public 				string

             finalScore
 { get; set; }
      [JsonProperty("summaryYearMonth")]
public 				string

             summaryYearMonth
 { get; set; }
      [JsonProperty("isGoldVender")]
public 				long

             isGoldVender
 { get; set; }
      [JsonProperty("startTime")]
public 				DateTime

             startTime
 { get; set; }
      [JsonProperty("endTime")]
public 				DateTime

             endTime
 { get; set; }
	}
}
