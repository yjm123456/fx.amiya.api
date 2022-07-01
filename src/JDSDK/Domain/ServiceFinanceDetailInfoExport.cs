using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceFinanceDetailInfoExport:JdObject{
      [JsonProperty("refundWay")]
public 				int[]

             refundWay
 { get; set; }
      [JsonProperty("refundWayName")]
public 				string

             refundWayName
 { get; set; }
      [JsonProperty("status")]
public 				int[]

             status
 { get; set; }
      [JsonProperty("statusName")]
public 				string

             statusName
 { get; set; }
      [JsonProperty("refundPrice")]
public 					string

             refundPrice
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
	}
}
