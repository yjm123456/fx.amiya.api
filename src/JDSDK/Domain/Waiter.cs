using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Waiter:JdObject{
      [JsonProperty("waiter")]
public 				string

             waiter
 { get; set; }
      [JsonProperty("yn")]
public 				byte

             yn
 { get; set; }
      [JsonProperty("leader")]
public 					bool

             leader
 { get; set; }
      [JsonProperty("level")]
public 				string

             level
 { get; set; }
	}
}
