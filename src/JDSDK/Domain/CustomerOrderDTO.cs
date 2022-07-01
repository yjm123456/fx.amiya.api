using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CustomerOrderDTO:JdObject{
      [JsonProperty("userId")]
public 				string

             userId
 { get; set; }
      [JsonProperty("level")]
public 				string

             level
 { get; set; }
      [JsonProperty("receiveAddress")]
public 				string

             receiveAddress
 { get; set; }
      [JsonProperty("client")]
public 				string

             client
 { get; set; }
      [JsonProperty("orderCode")]
public 				string

             orderCode
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("price")]
public 				double

             price
 { get; set; }
      [JsonProperty("quantity")]
public 				string

             quantity
 { get; set; }
      [JsonProperty("orderAmount")]
public 					string

             orderAmount
 { get; set; }
      [JsonProperty("amountAfterDiscount")]
public 					string

             amountAfterDiscount
 { get; set; }
      [JsonProperty("promotion")]
public 				bool

             promotion
 { get; set; }
      [JsonProperty("groupBuying")]
public 				bool

             groupBuying
 { get; set; }
      [JsonProperty("packageDiscount")]
public 				bool

             packageDiscount
 { get; set; }
      [JsonProperty("fullMinus")]
public 				bool

             fullMinus
 { get; set; }
      [JsonProperty("payTime")]
public 				DateTime

             payTime
 { get; set; }
      [JsonProperty("orderCreateTime")]
public 				DateTime

             orderCreateTime
 { get; set; }
	}
}
