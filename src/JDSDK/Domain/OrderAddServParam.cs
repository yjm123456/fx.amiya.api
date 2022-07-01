using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderAddServParam:JdObject{
      [JsonProperty("servCode")]
public 				string

             servCode
 { get; set; }
      [JsonProperty("servName")]
public 				string

             servName
 { get; set; }
      [JsonProperty("servPlanNum")]
public 				int

             servPlanNum
 { get; set; }
      [JsonProperty("servActNum")]
public 				int

             servActNum
 { get; set; }
      [JsonProperty("servDemand")]
public 				string

             servDemand
 { get; set; }
	}
}
