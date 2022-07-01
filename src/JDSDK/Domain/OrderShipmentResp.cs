using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderShipmentResp:JdObject{
      [JsonProperty("shipmentType")]
public 				int

             shipmentType
 { get; set; }
      [JsonProperty("shipmentTimeType")]
public 				int

             shipmentTimeType
 { get; set; }
      [JsonProperty("picksiteId")]
public 				long

             picksiteId
 { get; set; }
      [JsonProperty("pickDate")]
public 				DateTime

             pickDate
 { get; set; }
      [JsonProperty("promiseShipment")]
public 				PromiseShipmentResp

             promiseShipment
 { get; set; }
	}
}
