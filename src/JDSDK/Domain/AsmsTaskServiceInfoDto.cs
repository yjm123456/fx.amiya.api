using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AsmsTaskServiceInfoDto:JdObject{
      [JsonProperty("serviceId")]
public 				long

             serviceId
 { get; set; }
      [JsonProperty("serviceState")]
public 				int

             serviceState
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
	}
}
