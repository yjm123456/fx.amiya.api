using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class StockInfoDTO:JdObject{
      [JsonProperty("shopId")]
public 				long

             shopId
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("canOrder")]
public 				bool

             canOrder
 { get; set; }
	}
}
