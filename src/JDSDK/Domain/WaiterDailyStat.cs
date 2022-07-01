using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaiterDailyStat:JdObject{
      [JsonProperty("date")]
public 				string

             date
 { get; set; }
      [JsonProperty("waiter")]
public 				string

             waiter
 { get; set; }
      [JsonProperty("result")]
public 				string

             result
 { get; set; }
	}
}
