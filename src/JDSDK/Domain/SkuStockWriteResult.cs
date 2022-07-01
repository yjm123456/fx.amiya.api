using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SkuStockWriteResult:JdObject{
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("stockRf")]
public 				StockRf

             stockRf
 { get; set; }
      [JsonProperty("detailCode")]
public 				string

             detailCode
 { get; set; }
      [JsonProperty("detailMsg")]
public 				string

             detailMsg
 { get; set; }
	}
}
