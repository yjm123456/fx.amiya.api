using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PriceChange:JdObject{
      [JsonProperty("sku_id")]
public 				string

                                                                                     skuId
 { get; set; }
      [JsonProperty("price")]
public 				string

             price
 { get; set; }
      [JsonProperty("market_price")]
public 				string

                                                                                     marketPrice
 { get; set; }
	}
}
