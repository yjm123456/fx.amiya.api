using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderHistory:JdObject{
      [JsonProperty("orderCode")]
public 				string

             orderCode
 { get; set; }
      [JsonProperty("orderStatus")]
public 				int

             orderStatus
 { get; set; }
      [JsonProperty("clientId")]
public 				string

             clientId
 { get; set; }
      [JsonProperty("clientBusinessNo")]
public 				string

             clientBusinessNo
 { get; set; }
      [JsonProperty("orderTime")]
public 				string

             orderTime
 { get; set; }
	}
}
