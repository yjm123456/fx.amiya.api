using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InvoiceApplyBillMO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("venderId")]
public 				string

             venderId
 { get; set; }
      [JsonProperty("accountId")]
public 				long

             accountId
 { get; set; }
      [JsonProperty("shopName")]
public 				string

             shopName
 { get; set; }
      [JsonProperty("companyName")]
public 				string

             companyName
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("totalAmount")]
public 					string

             totalAmount
 { get; set; }
      [JsonProperty("settleAmount")]
public 					string

             settleAmount
 { get; set; }
      [JsonProperty("currency")]
public 				string

             currency
 { get; set; }
      [JsonProperty("invoiceDirection")]
public 				int

             invoiceDirection
 { get; set; }
      [JsonProperty("orgName")]
public 				string

             orgName
 { get; set; }
      [JsonProperty("excelUrl")]
public 				string

             excelUrl
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("beginDate")]
public 				DateTime

             beginDate
 { get; set; }
      [JsonProperty("endDate")]
public 				DateTime

             endDate
 { get; set; }
      [JsonProperty("dailyNum")]
public 				int

             dailyNum
 { get; set; }
      [JsonProperty("invoiceFinishTime")]
public 				DateTime

             invoiceFinishTime
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("rfBillType")]
public 				string

             rfBillType
 { get; set; }
      [JsonProperty("rejectReason")]
public 				string

             rejectReason
 { get; set; }
      [JsonProperty("shopId")]
public 				int

             shopId
 { get; set; }
      [JsonProperty("companyId")]
public 				long

             companyId
 { get; set; }
      [JsonProperty("invoiceOrg")]
public 				string

             invoiceOrg
 { get; set; }
	}
}
