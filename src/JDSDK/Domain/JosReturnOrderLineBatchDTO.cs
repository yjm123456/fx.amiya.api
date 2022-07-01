using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosReturnOrderLineBatchDTO:JdObject{
      [JsonProperty("returnOrderCode")]
public 				string

             returnOrderCode
 { get; set; }
      [JsonProperty("jdSku")]
public 				string

             jdSku
 { get; set; }
      [JsonProperty("returnPrice")]
public 					string

             returnPrice
 { get; set; }
      [JsonProperty("returnQuantity")]
public 				int

             returnQuantity
 { get; set; }
      [JsonProperty("purchasePrice")]
public 					string

             purchasePrice
 { get; set; }
      [JsonProperty("purchaseOrderCode")]
public 				string

             purchaseOrderCode
 { get; set; }
      [JsonProperty("purchaseDate")]
public 				DateTime

             purchaseDate
 { get; set; }
      [JsonProperty("comments")]
public 				string

             comments
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
      [JsonProperty("updateTime")]
public 				DateTime

             updateTime
 { get; set; }
	}
}
