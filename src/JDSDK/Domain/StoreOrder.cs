using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StoreOrder:JdObject{
      [JsonProperty("storeId")]
public 				long

             storeId
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
	}
}
