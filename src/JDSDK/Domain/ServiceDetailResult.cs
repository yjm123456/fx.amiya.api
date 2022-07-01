using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceDetailResult:JdObject{
      [JsonProperty("servicesNo")]
public 				string

             servicesNo
 { get; set; }
      [JsonProperty("servicesStatus")]
public 				string

             servicesStatus
 { get; set; }
      [JsonProperty("warehouseNo")]
public 				string

             warehouseNo
 { get; set; }
      [JsonProperty("warehouseName")]
public 				string

             warehouseName
 { get; set; }
      [JsonProperty("serviceItemInfos")]
public 				List<string>

             serviceItemInfos
 { get; set; }
	}
}
