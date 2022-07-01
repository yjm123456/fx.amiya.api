using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DeliveryAddressInfo:JdObject{
      [JsonProperty("addressId")]
public 				int

             addressId
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
	}
}
