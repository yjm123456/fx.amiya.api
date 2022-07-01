using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderStateInfo:JdObject{
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
	}
}
