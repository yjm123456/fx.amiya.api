using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosInvoiceDTO:JdObject{
      [JsonProperty("invoiceNo")]
public 				string

             invoiceNo
 { get; set; }
      [JsonProperty("invoiceCode")]
public 				string

             invoiceCode
 { get; set; }
      [JsonProperty("saveTime")]
public 				string

             saveTime
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
      [JsonProperty("amountWithTax")]
public 					string

             amountWithTax
 { get; set; }
      [JsonProperty("discountAmount")]
public 					string

             discountAmount
 { get; set; }
      [JsonProperty("taxRate")]
public 				string

             taxRate
 { get; set; }
      [JsonProperty("taxAmount")]
public 					string

             taxAmount
 { get; set; }
      [JsonProperty("invoiceType")]
public 				int

             invoiceType
 { get; set; }
      [JsonProperty("verificationStatus")]
public 				int

             verificationStatus
 { get; set; }
      [JsonProperty("verificationTime")]
public 				string

             verificationTime
 { get; set; }
	}
}
