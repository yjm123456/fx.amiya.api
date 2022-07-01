using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ChildOrderInfo:JdObject{
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("groupId")]
public 				int

             groupId
 { get; set; }
      [JsonProperty("skus")]
public 				List<string>

             skus
 { get; set; }
	}
}
