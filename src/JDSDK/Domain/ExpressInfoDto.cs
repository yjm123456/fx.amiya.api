using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ExpressInfoDto:JdObject{
      [JsonProperty("customOrderId")]
public 				string

             customOrderId
 { get; set; }
      [JsonProperty("receiveName")]
public 				string

             receiveName
 { get; set; }
      [JsonProperty("deliveryId")]
public 				string

             deliveryId
 { get; set; }
	}
}
