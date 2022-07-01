using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CancelOrderVO:JdObject{
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("cancelReason")]
public 				string

             cancelReason
 { get; set; }
      [JsonProperty("cancelDate")]
public 				DateTime

             cancelDate
 { get; set; }
	}
}
