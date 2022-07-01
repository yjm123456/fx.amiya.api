using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DspWeekForeCast:JdObject{
      [JsonProperty("day")]
public 				int

             day
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
	}
}
