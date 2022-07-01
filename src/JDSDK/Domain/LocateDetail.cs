using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LocateDetail:JdObject{
      [JsonProperty("locateSkuNo")]
public 				string

             locateSkuNo
 { get; set; }
      [JsonProperty("locateSkuName")]
public 				string

             locateSkuName
 { get; set; }
      [JsonProperty("plannedQty")]
public 				int

             plannedQty
 { get; set; }
      [JsonProperty("locateShippedQty")]
public 				int

             locateShippedQty
 { get; set; }
      [JsonProperty("locateIsvLotattrs")]
public 				string

             locateIsvLotattrs
 { get; set; }
      [JsonProperty("locateUnit")]
public 				string

             locateUnit
 { get; set; }
	}
}
