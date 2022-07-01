using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaiterDailyEvaStat:JdObject{
      [JsonProperty("date")]
public 				string

             date
 { get; set; }
      [JsonProperty("waiter")]
public 				string

             waiter
 { get; set; }
      [JsonProperty("score")]
public 				int

             score
 { get; set; }
      [JsonProperty("count")]
public 				int

             count
 { get; set; }
	}
}
