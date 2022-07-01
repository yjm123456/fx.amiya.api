using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PositionReportVO:JdObject{
      [JsonProperty("openAppPvRate")]
public 					string

             openAppPvRate
 { get; set; }
      [JsonProperty("tagId")]
public 				string

             tagId
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("clicks")]
public 					string

             clicks
 { get; set; }
      [JsonProperty("userName")]
public 				string

             userName
 { get; set; }
      [JsonProperty("grossCashCost")]
public 				string

             grossCashCost
 { get; set; }
      [JsonProperty("queries")]
public 					string

             queries
 { get; set; }
      [JsonProperty("reportDate")]
public 				int

             reportDate
 { get; set; }
      [JsonProperty("positionName")]
public 				string

             positionName
 { get; set; }
      [JsonProperty("ctr")]
public 					string

             ctr
 { get; set; }
	}
}
