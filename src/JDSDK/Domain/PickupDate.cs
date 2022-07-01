using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PickupDate:JdObject{
      [JsonProperty("day")]
public 				string

             day
 { get; set; }
      [JsonProperty("pickupTimeRangeList")]
public 				List<string>

             pickupTimeRangeList
 { get; set; }
	}
}
