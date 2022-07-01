using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class NormalInvoiceResp:JdObject{
      [JsonProperty("invoiceTitle")]
public 				int

             invoiceTitle
 { get; set; }
      [JsonProperty("invoiceContent")]
public 				int

             invoiceContent
 { get; set; }
      [JsonProperty("bookInvoiceContent")]
public 				int

             bookInvoiceContent
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("taxPayerId")]
public 				string

             taxPayerId
 { get; set; }
	}
}
