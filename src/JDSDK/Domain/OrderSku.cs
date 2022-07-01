using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderSku:JdObject{
      [JsonProperty("jdSkuId")]
public 				long

             jdSkuId
 { get; set; }
      [JsonProperty("imagePath")]
public 				string

             imagePath
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("num")]
public 				int

             num
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
	}
}
