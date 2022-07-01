using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PromiseShipmentResp:JdObject{
      [JsonProperty("bigItemShipmentDate")]
public 				DateTime

             bigItemShipmentDate
 { get; set; }
      [JsonProperty("bigItemInstallDate")]
public 				DateTime

             bigItemInstallDate
 { get; set; }
      [JsonProperty("promiseDate")]
public 				string

             promiseDate
 { get; set; }
      [JsonProperty("promiseTimeRange")]
public 				string

             promiseTimeRange
 { get; set; }
	}
}
