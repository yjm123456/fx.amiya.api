using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderShouldInvoiceAmount:JdObject{
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("venderId")]
public 				string

             venderId
 { get; set; }
      [JsonProperty("ivcTitle")]
public 				string

             ivcTitle
 { get; set; }
      [JsonProperty("customerTaxNo")]
public 				string

             customerTaxNo
 { get; set; }
      [JsonProperty("ivcContentType")]
public 				int

             ivcContentType
 { get; set; }
      [JsonProperty("ivcContentName")]
public 				string

             ivcContentName
 { get; set; }
      [JsonProperty("customerEmail")]
public 				string

             customerEmail
 { get; set; }
      [JsonProperty("shouldInvoiceAmount")]
public 					string

             shouldInvoiceAmount
 { get; set; }
      [JsonProperty("orderShouldInvoiceAmountDetailList")]
public 				List<string>

             orderShouldInvoiceAmountDetailList
 { get; set; }
	}
}
