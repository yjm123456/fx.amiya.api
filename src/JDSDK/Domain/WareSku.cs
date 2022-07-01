using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareSku:JdObject{
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("attributes")]
public 				string

             attributes
 { get; set; }
      [JsonProperty("supplyPrice")]
public 				double

             supplyPrice
 { get; set; }
      [JsonProperty("stock")]
public 				int

             stock
 { get; set; }
      [JsonProperty("imgUri")]
public 				string

             imgUri
 { get; set; }
      [JsonProperty("hsCode")]
public 				string

             hsCode
 { get; set; }
      [JsonProperty("amountCount")]
public 				int

             amountCount
 { get; set; }
      [JsonProperty("lockCount")]
public 				int

             lockCount
 { get; set; }
      [JsonProperty("lockStartTime")]
public 				DateTime

             lockStartTime
 { get; set; }
      [JsonProperty("lockEndTime")]
public 				DateTime

             lockEndTime
 { get; set; }
      [JsonProperty("saleStockAmount")]
public 				int

             saleStockAmount
 { get; set; }
	}
}
