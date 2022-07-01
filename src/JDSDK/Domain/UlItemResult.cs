using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UlItemResult:JdObject{
      [JsonProperty("orderLine")]
public 				string

             orderLine
 { get; set; }
      [JsonProperty("sellerGoodsNo")]
public 				string

             sellerGoodsNo
 { get; set; }
      [JsonProperty("goodsNo")]
public 				string

             goodsNo
 { get; set; }
      [JsonProperty("goodsName")]
public 				string

             goodsName
 { get; set; }
      [JsonProperty("goodsLevel")]
public 				string

             goodsLevel
 { get; set; }
      [JsonProperty("planQty")]
public 				int

             planQty
 { get; set; }
      [JsonProperty("ulItemBatchResultList")]
public 				List<string>

             ulItemBatchResultList
 { get; set; }
	}
}
