using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PickupReceiveResultDTO:JdObject{
      [JsonProperty("waybillCode")]
public 				string

             waybillCode
 { get; set; }
      [JsonProperty("pickupCode")]
public 				string

             pickupCode
 { get; set; }
	}
}
