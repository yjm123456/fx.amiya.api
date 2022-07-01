using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InvoiceEasyInfo:JdObject{
      [JsonProperty("invoiceType")]
public 				string

             invoiceType
 { get; set; }
      [JsonProperty("invoiceTitle")]
public 				string

             invoiceTitle
 { get; set; }
      [JsonProperty("invoiceContentId")]
public 				string

             invoiceContentId
 { get; set; }
      [JsonProperty("invoiceConsigneeEmail")]
public 				string

             invoiceConsigneeEmail
 { get; set; }
      [JsonProperty("invoiceConsigneePhone")]
public 				string

             invoiceConsigneePhone
 { get; set; }
      [JsonProperty("invoiceCode")]
public 				string

             invoiceCode
 { get; set; }
	}
}
