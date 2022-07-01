using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Evaluation:JdObject{
      [JsonProperty("customer")]
public 				string

             customer
 { get; set; }
      [JsonProperty("waiter")]
public 				string

             waiter
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
      [JsonProperty("score")]
public 				int

             score
 { get; set; }
      [JsonProperty("evaTime")]
public 				DateTime

             evaTime
 { get; set; }
	}
}
