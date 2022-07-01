using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SimpleOrderInfoDTO:JdObject{
      [JsonProperty("deliveryPromiseTime")]
public 				DateTime

             deliveryPromiseTime
 { get; set; }
      [JsonProperty("extendMessageStr")]
public 				string

             extendMessageStr
 { get; set; }
	}
}
