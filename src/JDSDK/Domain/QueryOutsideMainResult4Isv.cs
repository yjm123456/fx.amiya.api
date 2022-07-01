using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryOutsideMainResult4Isv:JdObject{
      [JsonProperty("boxes")]
public 				string

             boxes
 { get; set; }
      [JsonProperty("warehouseIdIn")]
public 				long

             warehouseIdIn
 { get; set; }
      [JsonProperty("productCode")]
public 				string

             productCode
 { get; set; }
      [JsonProperty("chargeMode")]
public 				string

             chargeMode
 { get; set; }
      [JsonProperty("cancelStatus")]
public 				byte

             cancelStatus
 { get; set; }
      [JsonProperty("outsideStatus")]
public 				byte

             outsideStatus
 { get; set; }
      [JsonProperty("warehouseIdOut")]
public 				long

             warehouseIdOut
 { get; set; }
      [JsonProperty("isvOutsideNo")]
public 				string

             isvOutsideNo
 { get; set; }
	}
}
