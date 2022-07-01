using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderShouldInvoiceAmountDetail:JdObject{
      [JsonProperty("shouldInvoiceAmount")]
public 					string

             shouldInvoiceAmount
 { get; set; }
      [JsonProperty("num")]
public 					string

             num
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("productId")]
public 				string

             productId
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
	}
}
