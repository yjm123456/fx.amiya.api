using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class EsfIdAndSkuIDDTO:JdObject{
      [JsonProperty("houseResourceId")]
public 				long

             houseResourceId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
	}
}
