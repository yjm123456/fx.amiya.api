using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class FinInvoiceOwnIvcDetail:JdObject{
      [JsonProperty("id")]
public 				string

             id
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("venderId")]
public 				string

             venderId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("invoiceType")]
public 				int

             invoiceType
 { get; set; }
      [JsonProperty("receiverTaxNo")]
public 				string

             receiverTaxNo
 { get; set; }
      [JsonProperty("receiverName")]
public 				string

             receiverName
 { get; set; }
      [JsonProperty("invoiceCode")]
public 				string

             invoiceCode
 { get; set; }
      [JsonProperty("invoiceNo")]
public 				int

             invoiceNo
 { get; set; }
      [JsonProperty("ivcTitle")]
public 				string

             ivcTitle
 { get; set; }
      [JsonProperty("totalPrice")]
public 				string

             totalPrice
 { get; set; }
      [JsonProperty("invoiceTime")]
public 				string

             invoiceTime
 { get; set; }
      [JsonProperty("pdfInfo")]
public 				string

             pdfInfo
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("ivcContentType")]
public 				int

             ivcContentType
 { get; set; }
      [JsonProperty("ivcContentName")]
public 				string

             ivcContentName
 { get; set; }
      [JsonProperty("eiRemark")]
public 				string

             eiRemark
 { get; set; }
      [JsonProperty("receiverAddress")]
public 				string

             receiverAddress
 { get; set; }
      [JsonProperty("receiverPhone")]
public 				string

             receiverPhone
 { get; set; }
      [JsonProperty("receiverBankName")]
public 				string

             receiverBankName
 { get; set; }
      [JsonProperty("receiverBankAccount")]
public 				string

             receiverBankAccount
 { get; set; }
      [JsonProperty("drawer")]
public 				string

             drawer
 { get; set; }
      [JsonProperty("payee")]
public 				string

             payee
 { get; set; }
      [JsonProperty("blueInvoiceCode")]
public 				string

             blueInvoiceCode
 { get; set; }
      [JsonProperty("blueInvoiceNo")]
public 				int

             blueInvoiceNo
 { get; set; }
	}
}
