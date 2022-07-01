using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PickupTimeRangeDTO:JdObject{
      [JsonProperty("pickupStartTime")]
public 				string

             pickupStartTime
 { get; set; }
      [JsonProperty("pickupEndTime")]
public 				string

             pickupEndTime
 { get; set; }
	}
}
