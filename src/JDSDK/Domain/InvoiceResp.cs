using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InvoiceResp:JdObject{
      [JsonProperty("invoiceType")]
public 				int

             invoiceType
 { get; set; }
      [JsonProperty("invoicePutType")]
public 				int

             invoicePutType
 { get; set; }
      [JsonProperty("regAddressId")]
public 				long

             regAddressId
 { get; set; }
      [JsonProperty("normalInvoiceResp")]
public 				NormalInvoiceResp

             normalInvoiceResp
 { get; set; }
      [JsonProperty("vatInvoiceResp")]
public 				VatInvoiceResp

             vatInvoiceResp
 { get; set; }
      [JsonProperty("consigneeResp")]
public 				ConsigneeResp

             consigneeResp
 { get; set; }
	}
}
