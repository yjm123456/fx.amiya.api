using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderInvoiceResp:JdObject{
      [JsonProperty("invoiceType")]
public 				int

             invoiceType
 { get; set; }
      [JsonProperty("invoiceTitle")]
public 				int

             invoiceTitle
 { get; set; }
      [JsonProperty("invoicePutType")]
public 				int

             invoicePutType
 { get; set; }
      [JsonProperty("normalInvoiceContent")]
public 				int

             normalInvoiceContent
 { get; set; }
      [JsonProperty("bookInvoiceContent")]
public 				int

             bookInvoiceContent
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("provinceId")]
public 				int

             provinceId
 { get; set; }
      [JsonProperty("cityId")]
public 				int

             cityId
 { get; set; }
      [JsonProperty("countyId")]
public 				int

             countyId
 { get; set; }
      [JsonProperty("townId")]
public 				int

             townId
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("companyRegistAddr")]
public 				string

             companyRegistAddr
 { get; set; }
      [JsonProperty("companyRegistPhone")]
public 				string

             companyRegistPhone
 { get; set; }
      [JsonProperty("companyRegistBank")]
public 				string

             companyRegistBank
 { get; set; }
      [JsonProperty("companyRegistBankAccount")]
public 				string

             companyRegistBankAccount
 { get; set; }
      [JsonProperty("taxpayerId")]
public 				string

             taxpayerId
 { get; set; }
	}
}
