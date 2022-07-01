using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RoDetailDto:JdObject{
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
      [JsonProperty("returnsPrice")]
public 					string

             returnsPrice
 { get; set; }
      [JsonProperty("returnsNum")]
public 				int

             returnsNum
 { get; set; }
      [JsonProperty("factNum")]
public 				int

             factNum
 { get; set; }
      [JsonProperty("totalPrice")]
public 					string

             totalPrice
 { get; set; }
      [JsonProperty("isbn")]
public 				string

             isbn
 { get; set; }
      [JsonProperty("discount")]
public 					string

             discount
 { get; set; }
      [JsonProperty("makePrice")]
public 					string

             makePrice
 { get; set; }
      [JsonProperty("bizCode")]
public 				string

             bizCode
 { get; set; }
	}
}
