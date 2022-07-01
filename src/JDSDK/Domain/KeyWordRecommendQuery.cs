using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class KeyWordRecommendQuery:JdObject{
      [JsonProperty("keyWord")]
public 				string

             keyWord
 { get; set; }
      [JsonProperty("pv")]
public 				long

             pv
 { get; set; }
      [JsonProperty("avgBigPrice")]
public 				double

             avgBigPrice
 { get; set; }
      [JsonProperty("ctr")]
public 				double

             ctr
 { get; set; }
      [JsonProperty("cvr")]
public 				double

             cvr
 { get; set; }
      [JsonProperty("starCount")]
public 				int

             starCount
 { get; set; }
	}
}
