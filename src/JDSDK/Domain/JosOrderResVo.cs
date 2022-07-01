using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosOrderResVo:JdObject{
      [JsonProperty("cosPrice")]
public 					string

             cosPrice
 { get; set; }
      [JsonProperty("finishTime")]
public 				string

             finishTime
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("isValid")]
public 				int

             isValid
 { get; set; }
      [JsonProperty("planName")]
public 				string

             planName
 { get; set; }
      [JsonProperty("unionName")]
public 				string

             unionName
 { get; set; }
      [JsonProperty("actName")]
public 				string

             actName
 { get; set; }
      [JsonProperty("orderTime")]
public 				string

             orderTime
 { get; set; }
      [JsonProperty("totalFee")]
public 					string

             totalFee
 { get; set; }
      [JsonProperty("skuId")]
public 				long

             skuId
 { get; set; }
      [JsonProperty("cosFee")]
public 					string

             cosFee
 { get; set; }
      [JsonProperty("skuCount")]
public 				int

             skuCount
 { get; set; }
      [JsonProperty("platformServiceFee")]
public 					string

             platformServiceFee
 { get; set; }
	}
}
