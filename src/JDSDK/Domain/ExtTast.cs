using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ExtTast:JdObject{
      [JsonProperty("extOrderCompleteDate")]
public 				string

             extOrderCompleteDate
 { get; set; }
      [JsonProperty("changeMainSkuQty")]
public 				int

             changeMainSkuQty
 { get; set; }
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("saleOrderNo")]
public 				string

             saleOrderNo
 { get; set; }
      [JsonProperty("mainSkuSn")]
public 				string

             mainSkuSn
 { get; set; }
      [JsonProperty("settleSkuQty")]
public 				int

             settleSkuQty
 { get; set; }
      [JsonProperty("bindType")]
public 				string

             bindType
 { get; set; }
      [JsonProperty("settleSku")]
public 				string

             settleSku
 { get; set; }
      [JsonProperty("mainSkuQty")]
public 				int

             mainSkuQty
 { get; set; }
      [JsonProperty("orderCompleteDate")]
public 				string

             orderCompleteDate
 { get; set; }
      [JsonProperty("mainSku")]
public 				string

             mainSku
 { get; set; }
      [JsonProperty("changeOrderNo")]
public 				string

             changeOrderNo
 { get; set; }
      [JsonProperty("extOrderNo")]
public 				string

             extOrderNo
 { get; set; }
      [JsonProperty("changeMainSkuSn")]
public 				string

             changeMainSkuSn
 { get; set; }
      [JsonProperty("extinsuranceType")]
public 				string

             extinsuranceType
 { get; set; }
      [JsonProperty("mainSkuName")]
public 				string

             mainSkuName
 { get; set; }
      [JsonProperty("settleSkuName")]
public 				string

             settleSkuName
 { get; set; }
	}
}
