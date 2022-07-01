using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReportInfo:JdObject{
      [JsonProperty("MappedAreaName")]
public 				string

             MappedAreaName
 { get; set; }
      [JsonProperty("Impressions")]
public 				string

             Impressions
 { get; set; }
      [JsonProperty("Clicks")]
public 				string

             Clicks
 { get; set; }
      [JsonProperty("CTR")]
public 				string

             CTR
 { get; set; }
      [JsonProperty("Cost")]
public 				string

             Cost
 { get; set; }
      [JsonProperty("CPM")]
public 				string

             CPM
 { get; set; }
      [JsonProperty("CPC")]
public 				string

             CPC
 { get; set; }
      [JsonProperty("DirectOrderCnt")]
public 				string

             DirectOrderCnt
 { get; set; }
      [JsonProperty("DirectOrderSum")]
public 				string

             DirectOrderSum
 { get; set; }
      [JsonProperty("IndirectOrderCnt")]
public 				string

             IndirectOrderCnt
 { get; set; }
      [JsonProperty("IndirectOrderSum")]
public 				string

             IndirectOrderSum
 { get; set; }
      [JsonProperty("TotalOrderCnt")]
public 				string

             TotalOrderCnt
 { get; set; }
      [JsonProperty("TotalOrderSum")]
public 				string

             TotalOrderSum
 { get; set; }
      [JsonProperty("DirectCartCnt")]
public 				string

             DirectCartCnt
 { get; set; }
      [JsonProperty("IndirectCartCnt")]
public 				string

             IndirectCartCnt
 { get; set; }
      [JsonProperty("TotalCartCnt")]
public 				string

             TotalCartCnt
 { get; set; }
      [JsonProperty("TotalOrderCVS")]
public 				string

             TotalOrderCVS
 { get; set; }
      [JsonProperty("TotalOrderROI")]
public 				string

             TotalOrderROI
 { get; set; }
	}
}
