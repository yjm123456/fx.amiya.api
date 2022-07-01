using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DeliverInfo:JdObject{
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("deliverSpot")]
public 				string

             deliverSpot
 { get; set; }
      [JsonProperty("deliverDate")]
public 				DateTime

             deliverDate
 { get; set; }
      [JsonProperty("deliverType")]
public 				int

             deliverType
 { get; set; }
	}
}
