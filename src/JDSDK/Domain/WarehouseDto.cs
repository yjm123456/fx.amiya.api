using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WarehouseDto:JdObject{
      [JsonProperty("deliver_center_id")]
public 				int

                                                                                                                     deliverCenterId
 { get; set; }
      [JsonProperty("deliver_center_name")]
public 				string

                                                                                                                     deliverCenterName
 { get; set; }
	}
}
